
public static class constants {
    public static double e = 2.71828;
    public static double eulers = e;
}

public static class funcs {

    public static Random rand = new Random();
    public static double sigmoid(double x) {
        return 1/(1 + Math.Pow(constants.e, -1 * x));
    }


}
