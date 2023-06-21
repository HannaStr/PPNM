using System;
using static System.Math;
using static System.Console;

public class main{
    
    public static void Main(){
        test_plainMC();
        diff_int();
    }

    public static void test_plainMC(){
        WriteLine("\n1) Find area of a unit circle\n");
        Func<vector, double> f = r_theta => r_theta[0];
        vector a = new vector (0.0, 0.0);                           //starting points of integrals dr & dtheta
        vector b = new vector (1.0, 2*PI);                          //ending points of integrals dr & dtheta
        int N = 1000000;
        double exp_val = PI;                                        //expected value
        var integral = MC.plain(f, a, b, N);
        double result = integral.Item1;
        double err = integral.Item2;
        WriteLine($"The area of a unit circle is: {result} with an error of {err}");
        WriteLine($"\nThe result should be = {exp_val}.");
        test_err(result, err, exp_val, N);

    }


    public static void diff_int(){
        WriteLine("\n2) Find the solution to a difficult singular integral\n");
        WriteLine($"The integral is: int(0,pi)dx int(0,pi)dy int(0,pi)dz (1/pi^3)*[1-cos(x)cos(y)cos(z)]^(-1), \nwhere 'int(0,pi)' means integral with limits from 0 to pi.\n");
        Func<vector, double> f = xyz => 1/(Pow(PI,3)*(1-Cos(xyz[0])*Cos(xyz[1])*Cos(xyz[2])));
        vector a = new vector (0.0, 0.0, 0.0);                          //starting points of integrals dr & dtheta
        vector b = new vector (PI,  PI,  PI );                          //ending points of integrals dr & dtheta
        int N = 1000000;
        double exp_val = 1.3932039296856768591842462603255;                                            //expected value
        var integral = MC.plain(f, a, b, N);
        double result = integral.Item1;
        double err = integral.Item2;
        WriteLine($"The integral gives a result: {result} with an error of {err}");
        WriteLine($"\nThe result should be = {exp_val}.");
        test_err(result, err, exp_val, N);

    }

    public static void test_err(double result, double err, double exp_val, int N){
        double plus = exp_val + err;
        double minus = exp_val - err;
        //WriteLine($"result_max = {plus} \nresult_min = {minus}");

        if (minus < result){
            if(result < plus){
                WriteLine("The result is equal to the expected value (within the error limits).");
            }
        }
        else WriteLine("The result is NOT equal to the expected value (within the error limits).");

        double scale = 1/Sqrt(N);
        WriteLine($"The error should scale as 1/sqrt(N) = {scale}.\n");
    }
}