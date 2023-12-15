using System;
class Program
{
    public static double S(double a, double b, double c)
    {
        double p = (a+b+c) / 2;
        double S = Math.Sqrt(p * (p-a) * (p-b) * (p-c));
        return S;
    }

    static void Main(string[] args)
    {
        //1 треугольник
        double a1 = 7;
        double b1 = 5;
        double c1 = 4;
        //2 треугольник
        double a2 = 4;
        double b2 = 9;
        double c2 = 6;

        double S1 = S(a1, b1, c1);
        double S2 = S(a2, b2, c2);
        if (S1 >= S2)
            Console.WriteLine($"площадь 1 треугольника больше, она равна {S1}");
        else
            Console.WriteLine($"площадь 2 треугольника больше, она равна {S2}");

    }
}