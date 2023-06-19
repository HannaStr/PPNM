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
        for(double z=0.0+1/32; z<7; z+=1.0/8){
            WriteLine($"{z} {spline.linterp(x,y,z)} {spline.linterpInteg(x,y,z)}");
        }
        


    }

}