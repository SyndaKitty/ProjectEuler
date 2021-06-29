using System;
using System.Linq;
using System.IO;

class Program {
    // Same approach as P18, start at bottom of tree, calculating best path by summing the
    // larger of the two adjacent numbers, move upwards
    static void Main(string[] args) {
        var lines = File.ReadAllLines("p067_triangle.txt");
        int size = lines.Last().Split(" ").Length;
        var values = new int[size+1, size+1];
        
        for (int line = 0; line < lines.Length; line++) {
            var words = lines[line].Split(" ");
            for (int word = 0; word < words.Length; word++) {
                values[word,line - word] = Convert.ToInt32(words[word]);
            }
        }

        for (int i = size-2; i >= 0; i--) {
            for (int j = 0; j <= i; j++) {
                int x = j;
                int y = i-j;
                values[x,y] += Math.Max(values[x+1,y], values[x, y+1]);
            }
        }

        Console.WriteLine(values[0,0]);
    }
}