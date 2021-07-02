using System;

class Program {
    static void Main(string[] args) {
        Console.WriteLine(MakeChange(200, 0));
    }

    static int[] coins = new[] {200, 100, 50, 20, 10, 5, 2, 1};
    static int MakeChange(int money, int startingCoin) {
        if (startingCoin == coins.Length - 1) return 1;
        
        int sum = 0;
        for (int coin = startingCoin; coin < coins.Length; coin++) {
            if (money - coins[coin] == 0) sum++;
            if (money - coins[coin] > 0) sum += MakeChange(money - coins[coin], coin);
        }

        return sum;
    }
}