namespace NeuralNetTwo {
    internal class Program {
        static void Main(string[] args) {
            int[] layersizes = {2, 3, 2};
            network n = new network(layersizes);

            double[] inp = {2.5, 1.6};
            double[] outp = n.calculateOutput(inp);

            Console.WriteLine(outp);
        }
    }
}
