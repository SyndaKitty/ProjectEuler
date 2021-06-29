using System;
using System.IO;

class Program {
    static void Main(string[] args) {
        var grid = ParseGrid();
        int size = 20;
        int sequence = 4;

        int largest = 0;

        // Generate all vertical lines
        for (int r = 0; r <= size - sequence; r++) {
            for (int c = 0; c < size; c++) {
                int product = 1;
                for (int i = 0; i < sequence; i++) {
                    product *= grid[r+i,c];
                }
                if (product > largest) {
                    largest = product;
                }
            }
        }

        // Generate all horizontal lines
        for (int r = 0; r < size; r++) {
            for (int c = 0; c <= size - sequence; c++) {
                int product = 1;
                for (int i = 0; i < sequence; i++) {
                    product *= grid[r,c+i];
                }
                if (product > largest) {
                    largest = product;
                }
            }
        }

        // Generate all upper-left to bottom-right diagonals
        for (int r = 0; r <= size - sequence; r++) {
            for (int c = 0; c <= size - sequence; c++) {
                int product = 1;
                for (int i = 0; i < sequence; i++) {
                    product *= grid[r+i,c+i];
                }
                if (product > largest) {
                    largest = product;
                }
            }
        }
    
        // Generate all bottom-left to upper-right diagonals
        for (int r = 0; r <= size - sequence; r++) {
            for (int c = 0; c <= size - sequence; c++) {
                int product = 1;
                for (int i = 0; i < sequence; i++) {
                    product *= grid[r+sequence-1-i,c+i];
                }
                if (product > largest) {
                    largest = product;
                }
            }
        }
        Console.WriteLine(largest);
    }

    static int[,] ParseGrid() {
        var lines = File.ReadAllLines("grid.txt");
        int[,] values = new int[20, 20];
        for (int row = 0; row < 20; row++) {
            string[] nums = lines[row].Split(' ');
            for (int col = 0; col < 20; col++) {
                values[row, col] = Convert.ToInt32(nums[col]);
            }
        }

        return values;
    }
}