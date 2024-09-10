using System.Diagnostics.Tracing;
using System.Globalization;

public class network {
    public class node {
        public double val;
        public double bias;
        public int index; // nodes position in the layer
        public List<double> weights = new List<double>();
        public List<node> connections = new List<node>(); // what the weights point to. used for backprop
        public double costDeriv = 0; // derivative of cost with respect to the nodes output
        public node(int i) {
            this.val = 0;
            this.bias = 0;// funcs.rand.Next(0, 2);
            this.index = i;
        }
    }

    public class layer {
        public node[] nodes;
        public int index; // index of layer in networks layers array
        public layer(int size, int ind) {
            this.nodes = new node[size];
            this.index = ind;
            for(int i = 0; i < size; i++) { // fill layer with node instances
                this.nodes[i] = new node(i);
            }
        }

        public void layermath() { // take all the node values (currently the weighted sum of the previous layer) and add bias then pass through sigmoid
            for(int i = 0; i < nodes.Length; i++) {
                this.nodes[i].val += nodes[i].bias;
                this.nodes[i].val = funcs.sigmoid(nodes[i].val);
            }
        }

        public void passToNextLayer(layer next) { // take current layers values after layermath(), pass them through weights to next layer
            for(int i = 0; i < this.nodes.Length; i++) {
                node curnode = this.nodes[i];

                for(int j = 0; j < next.nodes.Length; j++) { // loop through all the nodes in the next layer
                    next.nodes[j].val += curnode.val * curnode.weights[j]; // take current nodes value, apply it to next.nodes[j]
                }
            }
        }
    }

    public layer[] layers;
    public List<double> errorHistory = new List<double>(); // list of error history for future graphing
    public network(int[] layersizes) {
        this.layers = new layer[layersizes.Length];

        for(int i = 0; i < layersizes.Length; i++) { // fill layer array with layers
            this.layers[i] = new layer(layersizes[i], i);
        }

        for(int layernum = 0; layernum < layersizes.Length - 1; layernum++) { // string together all the nodes by adding weights
            layer curlayer = this.layers[layernum];

            for(int nodenum = 0; nodenum < curlayer.nodes.Length; nodenum++) { // go through every node in curlayer
                node curnode = curlayer.nodes[nodenum];

                for(int j = 0; j < layersizes[layernum + 1]; j++) {
                    curnode.weights.Add(0.5); // a random weight for every node in the next layer
                    curnode.connections.Add(this.layers[layernum + 1].nodes[j]);
                } 
            }
        } // 3 nested for loops is disgusting, I hate myself for coding this.
    }
    public double[] calculateOutput(double[] inputs) {
        for(int i = 0; i < this.layers[0].nodes.Length; i++) { // pass inputs into first layer
            node curnode = this.layers[0].nodes[i];
            curnode.val = inputs[i];
        }

        for(int i = 0; i < this.layers.Length - 1; i++) { // loop through all layers, and call layermath() then passToNextLayer()
            layer curlayer = this.layers[i];
            layer nextlayer = this.layers[i + 1];
            curlayer.layermath();
            for(int j = 0; j < curlayer.nodes.Length; j++) curlayer.nodes[j].val = 0; // reset node values to 0 for the next calculateOutput()
            curlayer.passToNextLayer(nextlayer);
        }

        layer lastLayer = this.layers[this.layers.Length - 1];
        lastLayer.layermath();

        double[] output = new double[lastLayer.nodes.Length];
        for(int i = 0; i < output.Length; i++) { // copy last layers node values into output array
            output[i] = lastLayer.nodes[i].val;
        }

        return output;
    }

    public void backPropogation(double mse, double learnRate) {
        layer lastLayer = this.layers[layers.Length - 1]; // last layer
        for(int i = 0; i < lastLayer.nodes.Length; i++) { // set derivs for last layer
            node curnode = lastLayer.nodes[i];
            curnode.costDeriv = mse / lastLayer.nodes.Length;
        }

        for(int i = this.layers.Length - 1; i >= 0; i--) { // loop through all the layers backward
            layer curlayer = this.layers[i];
            for(int numnode = 0; numnode < curlayer.nodes.Length; numnode++) { // visit every node
                node curnode = curlayer.nodes[numnode];
                curnode.costDeriv = funcs.derivOfNode(curnode);
                for(int numw = 0; numw < curnode.weights.Count; numw++) { // go through every weight of said node
                    double nudgeAmount = curnode.connections[numw].costDeriv * funcs.sigmoidDerivative(curnode.val) * curnode.val;
                    curnode.weights[numw] = curnode.weights[numw] - (learnRate * nudgeAmount);
                }

                curnode.bias = curnode.bias - funcs.sigmoidDerivative(curnode.val) * curnode.costDeriv * learnRate;
            }
        }
    }
    
}