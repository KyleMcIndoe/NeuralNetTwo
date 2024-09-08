
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

    public static double nudgeAmount(double[] derivs, double learnRate) {
        double prod = derivs[0];
        for(int i = 1; i < derivs.Length; i++) {
            prod *= derivs[i];
        }
        return prod * learnRate;
    }
}
