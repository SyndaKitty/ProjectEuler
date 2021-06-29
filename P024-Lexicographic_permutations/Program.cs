using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    static void Main(string[] args) {
        var chars = new[] {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
        List<string> allPermutations = new List<string>();
        Generate(chars.Length, chars, allPermutations);
        
        allPermutations = allPermutations.OrderBy(n => n).ToList();
        Console.WriteLine(allPermutations[1_000_000-1]);
    }

    static void Generate(int k, char[] array, List<string> permutations) {
        if (k == 1) {
            permutations.Add(new string(array));
        }
        else {
            for (int i = 0; i < k; i++) {
                Generate(k - 1, array, permutations);
                if (k % 2 == 0) {
                    (array[i], array[k-1]) = (array[k-1], array[i]);
                }
                else {
                    (array[0], array[k-1]) = (array[k-1], array[0]);
                }
            }
        }
    }
}