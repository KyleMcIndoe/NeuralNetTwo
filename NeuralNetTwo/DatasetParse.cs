using System.Formats.Asn1;
using System.IO;

public class data { // I hate this script with a burning passion, but it works,and thats good enough
    public static string answersPath = "Colors Dataset\\answers.txt";
    public static string rgbsPath = "Colors Dataset\\rgbs.txt";

    static string[] answersLines = File.ReadAllLines(answersPath);
    static string[] rgbsLines = File.ReadAllLines(rgbsPath);

    string[][] answersLinesSplit = new string[answersLines.Length][];
    string[][] rgbsLinesSplit = new string[rgbsLines.Length][];

    public double[][] answers = new double[answersLines.Length][];
    public double[][] rgbs = new double[answersLines.Length][];

    public data() {
        for(int i = 0; i < answersLines.Length; i++) {
            answersLinesSplit[i] = answersLines[i].Split(" ");
            rgbsLinesSplit[i] = rgbsLines[i].Split(" ");
        }
        for(int i = 0; i < answersLinesSplit.Length; i++) {
            answers[i] = new double[answersLinesSplit[i].Length];
            for(int j = 0; j < answersLinesSplit[i].Length; j++) {
                int x = 0;
                if(answersLinesSplit[i][j] == "1") x = 1;
                answers[i][j] = x;
            }
        }

        for(int i = 0; i < rgbsLinesSplit.Length; i++) {
            rgbs[i] = new double[rgbsLinesSplit[i].Length];
            for(int j = 0; j < rgbsLinesSplit[i].Length; j++) {
                int x = 0;
                Int32.TryParse(rgbsLinesSplit[i][j], out x);
                rgbs[i][j] = x;
            }
        }
    }
}

