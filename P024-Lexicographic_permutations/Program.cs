using System;

class Program {
    static void Main(string[] args) {
        
        int size = 10;
        int[] factorials = new int[size];
        factorials[0] = 1;
        for (int i = 1; i < size; i++) {
            factorials[i] = factorials[i-1] * (i + 1);
        }
        
        foreach (var d in GetPermutation(1_000_000, size, factorials)) {
            Console.Write(d);
        }
        Console.WriteLine();
    }

    static int[] GetPermutation(int n, int size, int[] factorials) {
        int[] digits = new int[size];
        int remainder = n-1;
        for (int d = 0; d < size-1; d++) {
            digits[d] = remainder / factorials[size-2-d];
            remainder = remainder % factorials[size-2-d];
        }

        int[] picks = new int[size];
        int[] results = new int[size];
        for (int j = 0; j < size; j++) {
            picks[j] = j;
        }
        for (int d = 0; d < digits.Length; d++) {
            results[d] = picks[digits[d]];
            for (int j = digits[d]; j < size - 1; j++) {
                picks[j] = picks[j + 1];
            }
        }
        return results;
    }

    // static void Generate(int k, char[] array, List<string> permutations) {
    //     if (k == 1) {
    //         permutations.Add(new string(array));
    //     }
    //     else {
    //         for (int i = 0; i < k; i++) {
    //             Generate(k - 1, array, permutations);
    //             if (k % 2 == 0) {
    //                 (array[i], array[k-1]) = (array[k-1], array[i]);
    //             }
    //             else {
    //                 (array[0], array[k-1]) = (array[k-1], array[0]);
    //             }
    //         }
    //     }
    // }
}