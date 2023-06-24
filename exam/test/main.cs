using System;
using static System.Console;
using static System.Math;


public class main
{
    public static void Main(string[] args)
    {
        Func<double, double> f = x => x * x; // Example function: f(x) = x^2
        double a = 0.0;
        double b = 1.0;

        double result = AdaptiveIntegrator.Integrate(f, a, b);
        Console.WriteLine("Approximate integral: " + result);
    }
}