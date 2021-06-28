using System;

class Program {
    static void Main(string[] args) {
        // Solved by using Pascal's Triangle
        int l = 20;
        decimal[,] values = new decimal[l+1,l+1];
        // Seed initial values
        for (int i=0; i<=l; i++) {
            values[i,0] = 1;
            values[0,i] = 1;
        }

        for (int y=1; y<=l; y++) {
            for (int x=1; x<=l; x++) {
                values[x,y] = values[x-1,y] + values[x,y-1];
            }
        }

        Console.WriteLine(values[l, l]);
    }
}