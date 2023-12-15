using System;

class Program
{
    public static int С(int n, int k)
    {
        int nFact = Fact(n);
        int kFact = Fact(k);
        int nkFact = Fact(n - k);

        int С = nFact / (kFact * nkFact);
        return С;
    }

    public static int Fact(int n)
    {
        int f = 1;
        for (int i = 1; i <= n; i++)
        {
            f *= i;
        }
        return f;
    }

    static void Main(string[] args)
    {
        int n8 = 8;
        int n10 = 10;
        int n11 = 11;
        int k = 5;
        int res8 = С(n8, k);
        int res10 = С(n10, k);
        int res11 = С(n11, k);
        Console.WriteLine($"{res8} способов собрать команду из {k} среди {n8} человек");
        Console.WriteLine($"{res10} способов собрать команду из {k} среди {n10} человек");
        Console.WriteLine($"{res11} способов собрать команду из {k} среди {n11} человек");
    }
}