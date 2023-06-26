using System;
using static System.Math;
using static System.Console;


public class main
{
    public static void Main()
    {
        // Define the tabulated function g(x) = Cos(5*x - 1) * Exp(-x*x)
        Func<double, double> g = (x) => Cos(5 * x - 1) * Exp(-x * x);

        // Generate sample points on the interval [-1, 1]
        int numSamples = 20;
        vector x_s = new vector(numSamples);
        vector y_s = new vector(numSamples);
        //var network = new ann(n);

        for (int i = 0; i < numSamples; i++)
        {
            double xi = -1 + 2.0 * i / (numSamples - 1);
            double yi = g(xi);
            x_s[i] = xi;
            y_s[i] = yi;
        }

        // Train the artificial neural network to interpolate the tabulated function
        int numHiddenNeurons = 10;
        var network = new ann(numHiddenNeurons);
        network.train(x_s, y_s);

        // Test the trained network by evaluating its response at various points
        int numTestPoints = 100;
        double stepSize = 2.0 / (numTestPoints - 1);

        for (int i = 0; i < numTestPoints; i++)
        {
            double xi = -1 + i * stepSize;
            double yiActual = g(xi);
            double yiPredicted = network.response(xi);
            WriteLine($"x = {xi}, Actual y = {yiActual}, Predicted y = {yiPredicted}");
        }
    }
}
