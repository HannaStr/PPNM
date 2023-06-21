using System;
using static System.Console;
using static System.Math;    

public class data {

    public static void Main(){
        //WriteLine("\n1) Find area of a unit circle\n");
        Func<vector, double> f = r_theta => r_theta[0];
        vector a = new vector (0.0, 0.0);                           //starting points of integrals dr & dtheta
        vector b = new vector (1.0, 2*PI);                          //ending points of integrals dr & dtheta
        //int N = 1000000;
        //double exp_val = PI;                                        //expected value
        
        for (int N=10; N <= 1e8; N *= 10){
            var integral = MC.plain(f, a, b, N);
            double result = integral.Item1;
            double err = integral.Item2;
            WriteLine($"{N}  {result}  {err}");
        }
    }
}