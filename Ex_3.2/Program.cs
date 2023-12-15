using System;

class Program
{
    public delegate void DelegateSort(int[,] matrix, int i);

    static void Main()
    {
        int[,] matrix = new int[4, 5]
        {
            { 3, 9, 6, 7, 2},
            { 9, 1, 7, 8, 2},
            { 2, 4, 2, 8, 9},
            { 4, 2, 9, 1, 7}
        };
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        Program program = new Program();
        program.SortMatrix(matrix, program.Sort);
    }

    public void SortMatrix(int[,] matrix, DelegateSort sortDelegate)
    {
        for (int i = 0; i < 4; i++)
        {
            if (i % 2 == 0)
            {
                int[] row = GetRow(matrix, i);
                Array.Sort(row);
                SortRow(matrix, row, i);
            }
            else
            {
                int[] row = GetRow(matrix, i);
                Array.Sort(row);
                Array.Reverse(row);
                SortRow(matrix, row, i);
            }

            sortDelegate(matrix, i);
        }
    }

    public void Sort(int[,] matrix, int i)
    {
        for (int j = 0; j < 5; j++)
        {
            Console.Write(matrix[i, j] + " ");
        }
        Console.WriteLine();
    }

    public void SortRow(int[,] matrix, int[] row, int rowIndex)
    {
        for (int j = 0; j < 5; j++)
        {
            matrix[rowIndex, j] = row[j];
        }
    }

    public int[] GetRow(int[,] matrix, int rowIndex)
    {
        int[] row = new int[5];
        for (int j = 0; j < 5; j++)
        {
            row[j] = matrix[rowIndex, j];
        }
        return row;
    }
}