using System.Diagnostics.Tracing;

public class network {
    public class node {
        public double val;
        public double bias;
        public int index; // nodes position in the layer
        public List<double> weights = new List<double>();

        public node(int i) {
            this.val = funcs.sigmoid(funcs.rand.Next(-5, 5));
            this.bias = funcs.rand.Next(0, 2);
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

        void layermath() { // take all the node values (currently the weighted sum of the previous layer) and add bias then pass through sigmoid
            for(int i = 0; i < nodes.Length; i++) {
                nodes[i].val += nodes[i].bias;
                nodes[i].val = funcs.sigmoid(nodes[i].val);
            }
        }
    }

    layer[] layers;

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
                    curnode.weights.Add(funcs.rand.NextDouble()); // a random weight for every node in the next layer
                } 
            }
        } // 3 nested for loops is disgusting, I hate myself for coding this.
    }
}