namespace NeuralNetTwo {
    internal class Program {
        static void Main(string[] args) {

            data dataSet = new data();
            int[][] trainingIns = dataSet.rgbs;
            int[][] trainingOuts = dataSet.answers;

            int[] layersizes = {3, 4, 6};
            network n = new network(layersizes);

            for(int i = 0; i < trainingOuts.Length; i++) {
                for(int j = 0; j < trainingOuts[i].Length; j++) {
                    Console.Write(trainingOuts[i][j]);
                }
                Console.WriteLine(" ");
            }
        }
    }
}
