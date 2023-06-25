using System;
using static System.Console;
using static System.Math;


public class main
{
    public static void Main(string[] args)
    {
        Func<double, double> function = x => x * x; // Example function: f(x) = x^2
        double lowerLimit = 0.0;
        double upperLimit = 1.0;

        double result = AdaptiveIntegrator.Integrate(function, lowerLimit, upperLimit);
        Console.WriteLine("Approximate integral: " + result);
    }
}
