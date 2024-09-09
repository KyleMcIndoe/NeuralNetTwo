namespace NeuralNetTwo {
    internal class Program {
        static void Main(string[] args) {

            data dataSet = new data();
            double[][] trainingIns = dataSet.rgbs;
            double[][] trainingOuts = dataSet.answers;

            int[] layersizes = {3, 4, 6};
            network n = new network(layersizes);

            funcs.train(n, trainingIns, trainingOuts, 0.01, 30);
            Console.WriteLine(funcs.classify(n.calculateOutput([255, 0, 0])));
            Console.WriteLine(funcs.classify(n.calculateOutput([0, 255, 0])));

            for(int i = 0; i < n.errorHistory.Count; i++) {
                Console.Write(Math.Round(n.errorHistory[i], 2));
            }
        }
    }
}
