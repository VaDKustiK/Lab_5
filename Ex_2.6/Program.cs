using System;

class Program
{
    static void Main()
    {
        int[] A = new int[7] { 1, 5, 8, 3, 4, 999, 2 };
        int[] B = new int[8] { 9, 8, 999, 6, 1, 7, 3, 2 };

        A = AB(A, B);
        Console.WriteLine(string.Join(", ", A));
    }

    static int[] AB(int[] A, int[] B)
    {
        int maxA = A.Max();
        int maxB = B.Max();
        int[] AB = new int[A.Length + B.Length - 2];

        int ind = 0;
        for (int i = 0; i < A.Length; i++)
        {
            if (A[i] != maxA)
            {
                AB[ind] = A[i];
                ind++;
            }
        }

        for (int i = 0; i < B.Length; i++)
        {
            if (B[i] != maxB)
            {
                AB[ind] = B[i];
                ind++;
            }
        }

        return AB;
    }
}