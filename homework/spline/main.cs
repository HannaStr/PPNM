using System;
using static System.Console;
using static System.Math;

class main{
    public static void Main(){
        test_lininterp();
    }

    public static void test_lininterp(){
        int n = 15;
        double[] x = new double[n];
        double[] y = new double[n];
        for(int j=0; j<n; j++){
            x[j] = j/2.0;
            y[j] = Sin(j/2.0);
        }

        WriteLine("Generate data points, following a sin(x)");
        for(int j=0; j<n; j++){
            WriteLine($"{x[j]} {y[j]}");
        }
        WriteLine();

        WriteLine("Pick a z, interploate and integrate the data points");
        double z=2.4;
        WriteLine($"z={z} f(z)={spline.linterp(x,y,z)} Integral {spline.linterpInteg(x,y,z)}");


    }

}