public class network {
    public class node {
        double val;
        double bias;
        int index; // nodes position in the layer
        List<double> weights = new List<double>();

        public node(int i) {
            this.val = funcs.sigmoid(funcs.rand.Next(-5, 5));
            this.bias = funcs.rand.Next(0, 2);
            this.index = i;
        }
    }

    public class layer {
        node[] nodes;
        int index; // index of layer in networks layers array
        public layer(int size, int ind) {
            this.nodes = new node[size];
            this.index = ind;
            for(int i = 0; i < size; i++) { // fill layer with node instances
                this.nodes[i] = new node(i);
            }
        }
    }

    layer[] layers;

    public network(int[] layersizes) {
        this.layers = new layer[layersizes.Length];

        for(int i = 0; i < layersizes.Length; i++) { // fill layer array with layers
            this.layers[i] = new layer(layersizes[i], i);
        }


    }
}