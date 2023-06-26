using System;
using static System.Console;
using static System.Math;


public class main
{
    public static void Main(string[] args)
    {
        WriteLine("\nCompare the results for the algorith with division into 2 and 3 subintervals respectively.\nCalculation for function f(x)=x^2 (expected value 1/3)");
        check_1();
        check_2();
        WriteLine("\nTesting the implementation of the integration algorithm (2 subintervals).\nThe result is compared to the expected values with uncertainty 10e-4.");
        //WriteLine("..........................................................................\n");
        int_1();        // Sqrt(x)
        int_2();        // 1/Sqrt(x)
        int_3();        // 4*Sqrt(1-x^2)
        int_4();        // ln(x)/Sqrt(x)
        WriteLine("\nTesting the implementation of the integration algorithm (3 subintervals).\nThe result is compared to the expected values with uncertainty 10e-4.");
        int_1b();        // Sqrt(x)
        int_2b();        // 1/Sqrt(x)
        int_3b();        // 4*Sqrt(1-x^2)
        int_4b();        // ln(x)/Sqrt(x)
        //erf_data();

    }

    public static void check_1()
    {
        Func<double, double> f = x => x * x; // Example function: f(x) = x^2
        double a = 0.0;
        double b = 1.0;

        double result = AdaptiveIntegrator.integrate_sub3(f, a, b);
        Console.WriteLine("Approximate integral (check 2): " + result);
    }

        public static void check_2()
    {
        Func<double, double> f = x => x * x; // Example function: f(x) = x^2
        double a = 0.0;
        double b = 1.0;

        double result = AdaptiveIntegrator.integrate_sub2(f, a, b);
        Console.WriteLine("Approximate integral (sub2): " + result);
    }




    public static void int_1(){
        Func<double,double> f = x => Sqrt(x);
        double a = 0.0;
        double b = 1.0;
        double integral = AdaptiveIntegrator.integrate_sub2(f,a,b);
        double expected = 2.0/3.0;
        WriteLine($"1)\nIntegral of [Sqrt(x)] in respect of x with limit (0,1) is: {integral}.");
        WriteLine($"\nIt should be 2/3.\nIn this case this is: ");
        approx(expected, integral);
    }

    public static void int_2(){
        Func<double,double> f = x => 1/Sqrt(x);
        double a = 0.0;
        double b = 1.0;
        double integral = AdaptiveIntegrator.integrate_sub2(f,a,b);
        double expected = 2.0;
        WriteLine($"2)\nIntegral of [1/Sqrt(x)] in respect of x with limit (0,1) is: {integral}.");
        WriteLine($"\nIt should be 2.\nIn this case this is: ");
        approx(expected, integral);
    }

    public static void int_3(){
        Func<double,double> f = x => 4*Sqrt(1-Pow(x,2));
        double a = 0.0;
        double b = 1.0;
        double integral = AdaptiveIntegrator.integrate_sub2(f,a,b);
        double expected = PI;
        WriteLine($"3)\nIntegral of [4*sqrt(1-x^2)] in respect of x with limit (0,1) is: {integral}.");
        WriteLine($"\nIt should be pi.\nIn this case this is: ");
        approx(expected, integral);
    }

    public static void int_4(){
        Func<double,double> f = x => Log(x)/Sqrt(x);
        double a = 0.0;
        double b = 1.0;
        double integral = AdaptiveIntegrator.integrate_sub2(f,a,b);
        double expected = -4;
        WriteLine($"4)\nIntegral of [ln(x)/sqrt(x)] in respect of x with limit (0,1) is: {integral}.");
        WriteLine($"\nIt should be -4.\nIn this case this is: ");
        approx(expected, integral);
    }


    public static void int_1b(){
        Func<double,double> f = x => Sqrt(x);
        double a = 0.0;
        double b = 1.0;
        double integral = AdaptiveIntegrator.integrate_sub3(f,a,b);
        double expected = 2.0/3.0;
        WriteLine($"1)\nIntegral of [Sqrt(x)] in respect of x with limit (0,1) is: {integral}.");
        WriteLine($"\nIt should be 2/3.\nIn this case this is: ");
        approx(expected, integral);
    }

    public static void int_2b(){
        Func<double,double> f = x => 1/Sqrt(x);
        double a = 0.0;
        double b = 1.0;
        double integral = AdaptiveIntegrator.integrate_sub3(f,a,b);
        double expected = 2.0;
        WriteLine($"2)\nIntegral of [1/Sqrt(x)] in respect of x with limit (0,1) is: {integral}.");
        WriteLine($"\nIt should be 2.\nIn this case this is: ");
        approx(expected, integral);
    }

    public static void int_3b(){
        Func<double,double> f = x => 4*Sqrt(1-Pow(x,2));
        double a = 0.0;
        double b = 1.0;
        double integral = AdaptiveIntegrator.integrate_sub3(f,a,b);
        double expected = PI;
        WriteLine($"3)\nIntegral of [4*sqrt(1-x^2)] in respect of x with limit (0,1) is: {integral}.");
        WriteLine($"\nIt should be pi.\nIn this case this is: ");
        approx(expected, integral);
    }

    public static void int_4b(){
        Func<double,double> f = x => Log(x)/Sqrt(x);
        double a = 0.0;
        double b = 1.0;
        double integral = AdaptiveIntegrator.integrate_sub3(f,a,b);
        double expected = -4.0;
        WriteLine($"4)\nIntegral of [ln(x)/sqrt(x)] in respect of x with limit (0,1) is: {integral}.");
        WriteLine($"\nIt should be -4.\nIn this case this is: ");
        approx(expected, integral);
    }




    public static void approx(double e, double i){
        double t = Pow(10, -4); // tolerance
        double diff = Abs(e - i);
        if (diff < t)
        {
            WriteLine("True\n" + diff);
        }
        else
        {
            WriteLine("False\n" + diff);
        }
    }
}