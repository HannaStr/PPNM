using System;
using static System.Console;
using static System.Math;

class main{
    public static void Main(){

        int n = 15;
        double[] x = new double[n];
        double[] y = new double[n];
        for(int i=0; i<n; i++){
            x[i] = i/2.0;
            y[i] = Sin(i/2.0);
        }
        for(double z=0.0; z<7; z+=1.0/10){                                              //for some reason has to be z<7
            WriteLine($"{z} {spline.linterp(x,y,z)} {spline.linterpInteg(x,y,z)}");
        }
        


    }

}