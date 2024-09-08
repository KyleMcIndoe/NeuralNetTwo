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
    }

    layer[] layers;
}