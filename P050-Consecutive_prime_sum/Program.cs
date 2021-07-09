using System;
using System.Linq;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {
        var p = new Primes(1_000_000);
        int[] rollingSum = p.List.TakeLast<int>(20).ToArray(); 
        int r = 0, i = 0;
        int sum = rollingSum.Sum<int>(x => x);
        for (i = p.Count - 1; sum > 1_000_000; i--) {
            sum -= rollingSum[r];
            rollingSum[r] = p[i];
            sum += rollingSum[r];
            r = (r + 1) % rollingSum.Length;
        }

        var t = new KaiTriangle<int>(p.List.Take(i));
        var best = new { score = 0, prime = 0};
        foreach (var row in t.GenerateAscending(1_000_000)) {
            foreach (var val in row) {
                if (!p.Contains(val.Sum)) continue;
                if (val.Length > best.score) {
                    best = new { score = val.Length, prime = val.Sum };
                }
            }
        }
        Console.WriteLine($"{best.prime} {best.score}");
    }
}

class KaiTriangle<T> where T : IComparable<T> {
    T[] sourceRow;
    int length;
    public KaiTriangle(IEnumerable<T> source) {
        if (source == null || source.FirstOrDefault() == null) {
            throw new InvalidOperationException("Source row must not be empty");
        }
        try {
            var sum = ((dynamic)source.First()) + ((dynamic)source.First());
        }
        catch {
            throw new NotSupportedException("Type must implement addition operator");
        }

        sourceRow = source.ToArray();
        length = sourceRow.Length;

    }

    public struct Item {
        public Item(T sum, int start, int length) {
            Sum = sum;
            Start = start;
            Length = length;
        }
        public T Sum;
        public int Start;
        public int Length;
    }

    public IEnumerable<IEnumerable<Item>> GenerateAscending(T MaxValue) {
        yield return sourceRow.Select((num, index) => new Item(num, index, 1));
        var previousRow = sourceRow.ToList();
        var nextRow = new List<T>();
        for (int y = 1; y < length; y++) {
            for (int x = 0; x < previousRow.Count - 1; x++) {
                var sum = (T)((dynamic)previousRow[x] + (dynamic)sourceRow[y+x]);
                if (sum.CompareTo(MaxValue) <= 0) {
                    nextRow.Add(sum);
                }
            }
            yield return nextRow.Select((num, index) => new Item(num, index, y + 1));
            previousRow = nextRow;
            nextRow = new List<T>();
        }
    }

    public IEnumerable<IEnumerable<Item>> GenerateDescending() {
        var sideRow = new T[length];
        T sum = default(T);
        for (int i = 0; i < length; i++) {
            sum = (T)((dynamic)sum + (dynamic)sourceRow[i]);
            sideRow[i] = sum;
        }
        yield return sideRow.Select((num, index) => new Item(num, 0, index + 1));
        var previousRow = sideRow;
        var nextRow = new T[sideRow.Length - 1];
        for (int y = 1; y < length; y++) {
            for (int x = 0; x < length - y; x++) {
                nextRow[x] = (T)((dynamic)previousRow[x + 1] - (dynamic)previousRow[0]);
            }
            yield return nextRow.Select((num, index) => new Item(num, y, index + 1));
            previousRow = nextRow;
            nextRow = new T[previousRow.Length - 1];
        }
    }
}

class Primes {
    public int MaxChecked;
    public List<int> List;
    public bool[] Array;
    public int Count => List.Count;
    public float Growth;
    public bool Contains(int i) {
        if (MaxChecked > i) return Array[i];
        if (Growth <= 1) {
            throw new InvalidOperationException($"Checking if {i} is a prime, but MaxChecked is {MaxChecked}");
        }
        else Generate((int)(i * Growth));
        return Array[i];
    }
    public int this[int index] => List[index];

    public Primes(int n, float growth = 2) {
        Growth = growth;
        Generate(n);
    }

    void Generate(int n) {
        if (MaxChecked >= n) return;
        MaxChecked = n;
        // Sieve of Erotosthenes
        Array = new bool[n];
        Array[2] = true;
        for (int i = 3; i < n; i+=2) {
            Array[i] = true;
        }
        for (int i = 3; i * i <= n; i += 2) {
            int index = i * 2;
            while (index < n) {
                Array[index] = false;
                index += i;
            }
        }

        int approximateCount = n < 128 ? n / 2 : (int)(n * 1.1 / Math.Log(n - 1));
        List = new List<int>(approximateCount);
        List.Add(2);
        for (int i = 3; i < n; i += 2) {
            if (Array[i]) {
                List.Add(i);
            }
        }
    }
}