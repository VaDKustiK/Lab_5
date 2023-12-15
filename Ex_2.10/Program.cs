using System;

class Program
{
    public static void Main()
    {
        Console.WriteLine("Введите количество строк и столбцов");
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];

        Random r = new Random();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = r.Next(10, 50);
            }
        }
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        int maxind = MaxInd(matrix);
        int minind = MinInd(matrix);
        Console.WriteLine($"min index {minind}, max index {maxind}");
        Console.WriteLine();
        Delete(matrix, maxind, minind);

        int count = 2;
        if (maxind == minind)
            count = 1;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n - count; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    static int MaxInd(int[,] matrix)
    {
        int maxind = 0;
        int max = int.MinValue;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < i + 1; j++)
            {
                if (matrix[i, j] >= max)
                {
                    max = matrix[i, j];
                    maxind = j;
                }
            }
        }
        return maxind;
    }

    static int MinInd(int[,] matrix)
    {
        int minind = 0;
        int min = int.MaxValue;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = i+1; j < matrix.GetLength(0); j++)
            {
                if (matrix[i, j] < min)
                {
                    min = matrix[i, j];
                    minind = j;
                }
            }
        }
        return minind;
    }

    static void Delete(int[,] matrix, int maxind, int minind)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = maxind; j < matrix.GetLength(0) - 1; j++)
            {
                matrix[i, j] = matrix[i, j + 1];
            }
        }
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = minind; j < matrix.GetLength(0) - 1; j++)
            {
                matrix[i, j-1] = matrix[i, j];
            }
        }
    }
}