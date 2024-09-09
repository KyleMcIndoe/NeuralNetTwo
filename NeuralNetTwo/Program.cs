namespace NeuralNetTwo {
    internal class Program {
        static void Main(string[] args) {

            data dataSet = new data();
            int[][] trainingIns = dataSet.rgbs;
            int[][] trainingOuts = dataSet.answers;

            int[] layersizes = {3, 4, 6};
            network n = new network(layersizes);

            Console.WriteLine(trainingIns[1][1]);
        }
    }
}
