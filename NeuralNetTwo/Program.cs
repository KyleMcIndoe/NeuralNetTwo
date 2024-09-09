namespace NeuralNetTwo {
    internal class Program {
        static void Main(string[] args) {

            data dataSet = new data();
            double[][] trainingIns = dataSet.rgbs;
            double[][] trainingOuts = dataSet.answers;

            int[] layersizes = {3, 4, 6};
            network n = new network(layersizes);

            funcs.train(n, trainingIns, trainingOuts, 0.1, 6);
            Console.WriteLine(funcs.classify(n.calculateOutput([255, 0, 0])));
        }
    }
}
