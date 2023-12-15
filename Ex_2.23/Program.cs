using System;

class Program
{
    public static void Main()
    {
        double[,] matrix1 = new double[,]
        {
            { 11, 50, 19, 41, 25 },
            { 49, 19, 45, 31, 13 },
            { 9, 41, 31, 27, 15 },
            { 37, 15, 50, 43, 52 }
        };
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Console.Write(matrix1[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        double[,] matrix2 = new double[,]
        {
            { 15, 33, 31, 29, 19, 11 },
            { 88, 13, 19, 70, 23, 13 },
            { 19, 39, 59, 11, 47, 23 },
            { 23, 35, 13, 31, 60, 15 },
            { 35, 15, 11, 31, 21, 29 },
            { 37, 11, 27, 90, 13, 19 }
        };
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                Console.Write(matrix2[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();


        double[] max1 = Max5(matrix1, 5);
        double[] max2 = Max5(matrix2, 5);

        Console.WriteLine("Максимальные элементы в 1 матрице");
        Console.WriteLine(string.Join(", ", max1));
        Console.WriteLine();

        Console.WriteLine("Максимальные элементы во 2 матрице");
        Console.WriteLine(string.Join(", ", max2));
        Console.WriteLine();

        matrix1 = NewMatrix(matrix1, max1);
        matrix2 = NewMatrix(matrix2, max2);

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Console.Write(matrix1[i, j]);
                Console.Write(" ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                Console.Write(matrix2[i, j]);
                Console.Write(" ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();

    }

    public static double[,] NewMatrix(double[,] matrix, double[] maxes)
    {
        int k = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == 0)
                {
                    matrix[i, j] = maxes[k]*2;
                    k++;
                }
                else
                {
                    int t;
                    for (t = 0; t < 5; t++)
                    {
                        if (matrix[i, j] == maxes[t])
                        {
                            matrix[i, j] *= 2;
                            break;
                        }
                    }
                    if (t == 5)
                    {
                        matrix[i, j] /= 2;
                    }
                }
            }
        }
        return matrix;
    }

    public static double[] Max5(double[,] matrix, int count)
    {
        double[] maxes = new double[count];
        int[] positions = new int[count];

        for (int k = 0; k < count; k++)
        {
            double max = double.MinValue;
            int maxI = -1;
            int maxJ = -1;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxI = i;
                        maxJ = j;
                    }
                }
            }

            if (maxI != -1 && maxJ != -1)
            {
                maxes[k] = max;
                positions[k] = maxI * matrix.GetLength(1) + maxJ;
                matrix[maxI, maxJ] = 0;
            }
        }

        for (int i = 0; i < count - 1; i++)
        {
            for (int j = i + 1; j < count; j++)
            {
                if (positions[j] < positions[i])
                {
                    double tempMax = maxes[i];
                    int tempPosition = positions[i];
                    maxes[i] = maxes[j];
                    positions[i] = positions[j];
                    maxes[j] = tempMax;
                    positions[j] = tempPosition;
                }
            }
        }
        return maxes;
    }
}