using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;

class Program {
    static void Main(string[] args) {
        Stopwatch sw = Stopwatch.StartNew();
        var P = new Primes(100_000);
        var sourceRow = new List<int>();
        int sum = 0;
        foreach (var p in P) {
            if (sum + p < 1_000_000) {
                sum += p;
                sourceRow.Add(p);
            }
            else break;
        }
        
        for (int level = 1; level < sourceRow.Count - 1; level++) {
            for (int h = 0; h <= level; h++) {
                int s = sum;
                int l = level - h;
                for (int li = 0; li < l; li++) {
                    s -= sourceRow[li];
                }
                for (int hi = 0; hi < h; hi++) {
                    s -= sourceRow[sourceRow.Count - hi - 1];
                }
                if (P.Contains(s)) {
                    sw.Stop();
                    Console.WriteLine(s);
                    return;
                }
            }
        }
    }
}

// Not used for this solution, but nice to have around
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

class Primes : IEnumerable<int> {
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

    public IEnumerator<int> GetEnumerator()
    {
        return ((IEnumerable<int>)List).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)List).GetEnumerator();
    }
}