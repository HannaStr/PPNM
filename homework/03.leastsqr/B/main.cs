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

        //Calculate the fitting parameters c_k
        vector c_k = ls_sqr_fit.lsfit(fs, t, ln_y, d_ln_y).Item1;
        matrix cov = ls_sqr_fit.lsfit(fs, t, ln_y, d_ln_y).Item2;
        vector err = ls_sqr_fit.lsfit(fs, t, ln_y, d_ln_y).Item3;

        double T_half_err = Log(2)*err[1]/Pow(Abs(c_k[1]),2);
        double diff = 3.6313 - (Log(2)/Abs(c_k[1]));

        WriteLine("\nThX is today known as Ra_224. \nThe modern value of its half-life time is T_1/2 = 3.6313(14) days. [1]");
        //half-life time is T_1/2 = ln(2)/lambda
        WriteLine($"\nT_1/2 of ThX from the least-quare fit is: {Log(2)/Abs(c_k[1])}");
        WriteLine($"With the uncertainty = {T_half_err}");
        WriteLine($"\nTherefore, the result from the fit is {Round(((Log(2)/Abs(c_k[1])-3.63)/3.63)*100,2)}% larger than the true value.\n");
        WriteLine($"The difference of the measured value to the true value is: {Abs(diff)} \nand this should be smaller than the error. In this case it's: {Abs(diff)<Abs(T_half_err)}");

        cov.print();


        WriteLine("\n\nSources:\n   [1] DOI: 10.1016/j.apradiso.2020.109572");
        
    }
}