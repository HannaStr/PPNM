using System;
using static System.Console;
using static System.Math;

class main{
    public static void Main(){
        
        int n = 15;
        double[] x = new double[n];
        double[] y = new double[n];

        WriteLine("Generetating data points of a sin(x) function");

        for (int i=0; i<n; i++){
            x[i] = i/2.0;
            y[i] = Sin(x[i]);
            WriteLine($"{x[i]}  {y[i]}");
        }

        WriteLine();

        //WriteLine("Pick a z, interploate and integrate the data points");
        //double z=2.4;
        //WriteLine($"z={z} f(z)={spline.linterp(x,y,z)} Integral {spline.linterpInteg(x,y,z)}");


    }

}