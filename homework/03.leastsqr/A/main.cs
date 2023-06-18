using System;
using static System.Console;
using static System.Math;
using static System.Random;

class main{
    public static void Main(){
        
        double [] t  = new double [] {1, 2, 3, 4, 6, 9, 10, 13, 15};
        double [] y  = new double [] {117, 100, 88, 72, 53, 29.5, 25.2, 15.2, 11.1};
        double [] dy = new double [] {5, 5, 5, 4, 4, 3, 3, 2, 2};

        var fs = new Func<double,double>[] {z => 1.0, z => z, z => z*z};

        //radioactive decay follows expoential law y(t)=a*exp(-lamda*t)
        //want to fit ln(y)=ln(a)-lambda*t
        int n = y.Length;
        
        double [] ln_y   = new double [n];
        double [] d_ln_y = new double [n];

        for(int i=0; i<n; i++){
            ln_y[i] = Log(y[i]);
            d_ln_y[i] = dy[i]/y[i];
        }

        vector coeffs = ls_sqr_fit.lsfit(fs, t, ln_y, d_ln_y);

        coeffs.print();


    }
}