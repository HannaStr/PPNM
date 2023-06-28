using System;
using static System.Console;
using static System.Math;

public class main{
    public static void Main(){
        WriteLine("\nTesting the implementation of the integration algorithm on some integrals.\nThe result is compared to the expected values with uncertainty 10e-4.");
        WriteLine("..........................................................................\n");
        int_1();        // Sqrt(x)
        int_2();        // 1/Sqrt(x)
        int_3();        // 4*Sqrt(1-x^2)
        int_4();        // ln(x)/Sqrt(x)
        erf_data();

    }

    public static void int_1(){
        Func<double,double> f = x => Sqrt(x);
        double a = 0.0;
        double b = 1.0;
        double integral = rai.integrate(f,a,b);
        double expected = 2.0/3.0;
        WriteLine($"1)\nIntegral of [Sqrt(x)] in respect of x with limit (0,1) is: {integral}.");
        WriteLine($"\nIt should be 2/3.\nIn this case this is: ");
        approx(expected, integral);
    }

    public static void int_2(){
        Func<double,double> f = x => 1/Sqrt(x);
        double a = 0.0;
        double b = 1.0;
        double integral = rai.integrate(f,a,b);
        double expected = 2.0;
        WriteLine($"2)\nIntegral of [1/Sqrt(x)] in respect of x with limit (0,1) is: {integral}.");
        WriteLine($"\nIt should be 2.\nIn this case this is: ");
        approx(expected, integral);
    }

    public static void int_3(){
        Func<double,double> f = x => 4*Sqrt(1-Pow(x,2));
        double a = 0.0;
        double b = 1.0;
        double integral = rai.integrate(f,a,b);
        double expected = PI;
        WriteLine($"3)\nIntegral of [4*sqrt(1-x^2)] in respect of x with limit (0,1) is: {integral}.");
        WriteLine($"\nIt should be pi.\nIn this case this is: ");
        approx(expected, integral);
    }

    public static void int_4(){
        Func<double,double> f = x => Log(x)/Sqrt(x);
        double a = 0.0;
        double b = 1.0;
        double integral = rai.integrate(f,a,b);
        double expected = -4;
        WriteLine($"4)\nIntegral of [ln(x)/sqrt(x)] in respect of x with limit (0,1) is: {integral}.");
        WriteLine($"\nIt should be -4.\nIn this case this is: ");
        approx(expected, integral);
    }

    public static void approx(double e, double i){
        //double e = expected;
        double t = Pow(10,-4);
        //double i = integral;
        double diff = Abs(e)-Abs(i);
        if (diff < t){
            WriteLine("True\n");
        }
        else WriteLine("False\n");
    }

    public static void erf_data(){
        WriteLine();
        WriteLine("The error function was plotted in erf.svg. \nThe function seems to be a good fit with the exact results especially when the values of delta and epsilon are small. \nHowever, for delta and epsilon larger (e.g. 0.01) the function is no longer smooth at z = +/- 1. This is due to the nature of the error function in use \n(which is defined differently for intervals of (z<0), (0<=z<=1) and (1<z)). \n");
        for(double i=-3.5; i<=3.5; i=i+1.0/32.0){
            double erf_i = rai.erf(i);
            WriteLine($"{i} {erf_i}");
        }        
    }     
}