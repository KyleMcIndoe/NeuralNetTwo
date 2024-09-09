using System.IO;

public class data {
    public static string inputsPath = "Colors Dataset\\answers.txt";
    public static string rgbsPath = "Colors Dataset\\rgbs.txt";

    static string[] answersLines = File.ReadAllLines(inputsPath);
    static string[] rgbsLines = File.ReadAllLines(rgbsPath);

    string[][] answersLinesSplit = new string[answersLines.Length][];
    string[][] rgbsLinesSplit = new string[rgbsLines.Length][];

    public int[][] answers = new int[answersLines.Length][];
    public int[][] rgbs = new int[answersLines.Length][];

    public data() {
        for(int i = 0; i < answersLines.Length; i++) {
            answersLinesSplit[i] = answersLines[i].Split(" ");
            rgbsLinesSplit[i] = answersLines[i].Split(" ");
        }

        for(int i = 0; i < answersLines.Length; i++) {
            for(int j = 0; j < answersLinesSplit[i].Length; i++) {
                answers[i][j] = int.Parse(answersLinesSplit[i][j]);
                rgbs[i][j] = int.Parse(rgbsLinesSplit[i][j]);
            }
        }
    }
}

