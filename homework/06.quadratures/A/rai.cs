using System;
using static System.Math;
using static System.Double;

public static class rai{

    //code from exercise description
    public static double integrate(

        Func<double,double> f, 
        double a,               //start point of integral 
        double b,               //end point of integral
        double del = 0.001,
        double eps = 0.001,
        double f2 = NaN,
        double f3 = NaN
    ){
        double h = b-a;
        if (IsNaN(f2)){         //first call, no points to reuse
            f2 = f(a+2*h/6);
            f3 = f(a+4*h/6);
        }
        double f1 = f(a+h/6);
        double f4 = f(a+5*h/6);
        double Q  = (2*f1+f2+f3+2*f4)/6*(b-a);  //higher order rule
        double q  = (  f1+f2+f3+  f4)/4*(b-a);  //lower order rule
        double err= Abs(Q-q);
        if (err <= del + eps*Abs(Q)) return Q;
        else return integrate (f, a, (a+b)/2, del/Sqrt(2), eps, f1, f2) +
                    integrate (f, (a+b)/2, b, del/Sqrt(2), eps, f3, f4);

    }

    //error function
    public static double erf(double z){
        if (1.0 < z){
            Func<double,double> f = t =>  Exp(-Pow(z+(1-t)/t, 2))/t/t;      //function we want to integrate
            double a = 0.0;
            double b = 1.0;
            double integral = rai.integrate(f, a, b);
            return 1 - 2.0/Sqrt(PI)*integral;
        }
        if (Abs(z) <= 1.0){
            Func<double, double> f = x => Exp(-Pow(x, 2));
            double a = 0.0;
            double b = z;
            double integral = rai.integrate(f, a, b);
            return 2/Sqrt(PI)*integral;
        }
        else return -erf(-z);                                               //if(z<0.0)
    }
}