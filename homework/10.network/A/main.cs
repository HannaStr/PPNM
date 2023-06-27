using System;
using static System.Math;
using static System.Console;


public class main{

    public static void Main()
    {
        //function g(x) = Cos(5*x - 1) * Exp(-x*x)
        Func<double, double> g = (x) => Cos(5 * x - 1) * Exp(-x * x);

        // Sample points on the interval [-1, 1]
        int ns = 20;       //number of sample points
        vector x_s = new vector(ns);
        vector y_s = new vector(ns);
        double a = -1.0;
        double b =  1.0;
        //WriteLine($"\n{ns} sample points of the function g(x) = Cos(5*x - 1) * Exp(-x*x).\n");

        for (int i = 0; i < ns; i++)
        {
            double xi = a + (b-a) * i / (ns - 1);
            double yi = g(xi);
            x_s[i] = xi;
            y_s[i] = yi;
            WriteLine($"{x_s[i]} {y_s[i]}");
        }

        // Train your network to interpolate the tabulated function
        int nr_hidden = 10;
        var network = new ann(nr_hidden);
        network.train(x_s, y_s);

        // Test the trained network by evaluating its response at various points
        int nrTestP = 100;      //number of test points
        double stepSize = 2.0 / (nrTestP - 1);
        
        WriteLine();
        WriteLine();

        //WriteLine("\nTesting the trained network\n   y_A = actual y for function g(x)\n   y_P = y for g(x) predicted by the neural network");
        //WriteLine("Table is {x, y_A, y_P}:\n");
        for (int i = 0; i < nrTestP; i++)
        {
            double xi = -1 + i * stepSize;
            double yiActual = g(xi);
            double yiPredicted = network.response(xi);
            WriteLine($"{xi} {yiActual} {yiPredicted}");
        }
    }

}
