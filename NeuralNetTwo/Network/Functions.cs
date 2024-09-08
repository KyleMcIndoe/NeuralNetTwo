
public static class constants {
    public static double e = 2.71828;
    public static double eulers = e;
}

public static class funcs {

    public static Random rand = new Random();
    public static double sigmoid(double x) {
        return 1/(1 + Math.Pow(constants.e, -1 * x));
    }

    public static double sigmoidDerivative(double x) {
        return sigmoid(x) * (1 - sigmoid(x));
    }

    public static double meanSquaredError(double[] trainingDataInputs, double[] trainingDataAnswers, network n) {
        double mse = 0;

        double[] networkOutput = n.calculateOutput(trainingDataInputs);

        for(int i = 0; i < trainingDataInputs.Length; i++) {
            mse += Math.Pow(trainingDataAnswers[i] - networkOutput[i], 2);
        }

        return mse / trainingDataInputs.Length;
    }

    public static double dCostdWeight(double derivOfNode, double sigmoidDeriv, double prevNodeVal) {
        return derivOfNode * sigmoidDeriv * prevNodeVal;
    }

    public static double derivOfNode(network.node x) {

        double sigmoidDeriv = sigmoidDerivative(x.val);
        double derivofnode = 0;

        for(int i = 0; i < x.weights.Count; i++) {
            derivofnode += x.connections[i].costDeriv * sigmoidDeriv * x.weights[i];
        }

        return derivofnode;
    }

    public static void train(network n, double[][] trainingDataInput, double[][] trainingDataOutput, double learnRate, int epochs) {
        for(int curSet = 0; curSet < epochs && curSet < trainingDataInput.Length; curSet++) {
            double[] trainingInput = trainingDataInput[curSet];
            double[] trainingExpected = trainingDataOutput[curSet];

            double[] networkOutput = n.calculateOutput(trainingInput); // forward propagation
            double loss = meanSquaredError(trainingInput, trainingExpected, n);
            
            n.backPropogation(loss, learnRate); // backward propagation
        }
    }

    public static int classify(double[] outputs) { // return the largest output
        double max = 0;
        int maxi = 0;

        for(int i = 0; i < outputs.Length; i++) {
            if(outputs[i] > max) {
                max = outputs[i];
                maxi = i;
            }
        }

        return maxi;
    }
}


