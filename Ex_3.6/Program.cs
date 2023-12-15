using System;

class Program
{
    delegate int MaxDelegate1(int[,] matrix);
    delegate int MaxDelegate2(int[,] matrix);

    static void Main()
    {
        int[,] matrix = {
            {7, 2, 0, 1, 9, 6},
            {1, 5, 0, 7, 0, 8},
            {8, 9, 9, 2, 0, 3},
            {9, 5, 0, 3, 0, 2},
            {2, 1, 0, 6, 0, 7},
            {4, 8, 0, 9, 0, 1}
        };

        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        MaxDelegate1 maxDelegate1;
        maxDelegate1 = Max1;
        int max1 = maxDelegate1(matrix);
        Console.WriteLine($"Max1 {max1}");

        MaxDelegate2 maxDelegate2;
        maxDelegate2 = MaxDiagonal;
        int max2 = maxDelegate2(matrix);
        Console.WriteLine($"MaxDiagonal {max2}");

        Swap(matrix, max1, max2);

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    static int Max1(int[,] matrix)
    {
        int max = int.MinValue;
        int max1 = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = i; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                    max1 = j;
                }
            }
        }
        return max1;
    }

    static int MaxDiagonal(int[,] matrix)
    {
        int max = int.MinValue;
        int max2 = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, i] > max)
            {
                max = matrix[i, i];
                max2 = i;
            }
        }
        return max2;
    }

    static void Swap(int[,] matrix, int max1, int max2)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int temp = matrix[i, max1];
            matrix[i, max1] = matrix[i, max2];
            matrix[i, max2] = temp;
        }
    }
}