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

        for(int i = 0; i < answersLinesSplit.Length; i++) {
            for(int j = 0; j < answersLinesSplit[i].Length; j++) {
                answers[i][j] = Convert.ToInt32(answersLinesSplit[i][j]);
            }
        }

        for(int i = 0; i < rgbsLinesSplit.Length; i++) {
            for(int j = 0; j < rgbsLinesSplit[i].Length; j++) {
                rgbs[i][j] = Convert.ToInt32(rgbsLinesSplit[i][j]);
            }
        }
    }
}

