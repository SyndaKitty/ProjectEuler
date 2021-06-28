using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

class Program {

    
    static void Main(string[] args) {
        
        string txt = File.ReadAllText("p059_cipher.txt");
        string[] encodedAsciiRaw = txt.Split(",");
        char[] encodedAscii = new char[encodedAsciiRaw.Length];

        for (int i = 0; i < encodedAscii.Length; i++) {
            encodedAscii[i] = (char)Convert.ToInt32(encodedAsciiRaw[i]);
        }

        HashSet<string> commonWords = new HashSet<string>();
        commonWords.Add("the");
        commonWords.Add("be");
        commonWords.Add("to");
        commonWords.Add("of");
        commonWords.Add("and");
        commonWords.Add("a");
        
        int bestCount = 0;
        string bestDecoded = "";
        for (int i = 0; i < 26 * 26 * 26; i++) {
            char a = (char)((i / (26 * 26)) + 'a');
            char b = (char)(((i / 26) % 26) + 'a');
            char c = (char)((i % 26) + 'a');
            string keyPart = new string(new char[] {a, b, c});
            char[] key = string.Concat(Enumerable.Repeat(keyPart, txt.Length / 3)).Substring(0, txt.Length).ToCharArray();

            string decoded = Decode(encodedAscii, key);
            int counts = CheckEnglishCompat(decoded, commonWords);
            if (counts > bestCount) {
                bestCount = counts;
                bestDecoded = decoded;
            }
        }

        Console.WriteLine(bestDecoded);
        int total = 0;
        foreach (var c in bestDecoded.ToCharArray()) {
            total += c;
        }
        Console.WriteLine(total);
    }

    static string Decode(char[] text, char[] key) {
        StringBuilder decoded = new StringBuilder(text.Length);
        for (int i = 0; i < text.Length; i++) {
            decoded.Append((char)(text[i] ^ key[i]));
        }
        return decoded.ToString();
    }

    static int CheckEnglishCompat(string decoded, HashSet<string> commonWords) {
        string[] words = decoded.ToString().Split(' ');
        return words.Where(w => commonWords.Contains(w)).Count();
    }
}