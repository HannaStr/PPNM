using System;
using static System.Double;
using static System.Math;

public class AdaptiveIntegrator
{
    private const double Tolerance = 1e-6; // Desired tolerance for integral approximation
/*
    //private static readonly double[] DivisionPoints = { 1.0 / 6.0, 3.0 / 6.0, 5.0 / 6.0 };
    //private static readonly double[] TrapeziumWeights = { 3.0 / 8.0, 2.0 / 8.0, 3.0 / 8.0 };
    //private static readonly double[] RectangleWeights = { 3.0 / 8.0, 2.0 / 8.0, 3.0 / 8.0 };
    private static readonly double[] xi = { 1.0/6.0, 3.0/6.0, 5.0/6.0 };
    private static readonly double[] wi = { 3.0/8.0, 2.0/8.0, 3.0/8.0 };
    private static readonly double[] vi = { 3.0/8.0, 2.0/8.0, 3.0/8.0 };
*/
/*
    public static double Integrate(
        Func<double, double> f, 
        double a, 
        double b,
        double del = 0.001,
        double eps = 0.001
        //double f2 = NaN,
        //double f3 = NaN
    ){
        double h = b - a;
        double midPoint = (b + a) / 2.0;

        if (IsNan(f2)){
            f2 = ;
            f3 = ;
        }
        1
        double f1 = ;
        double f4 = ;

        double Q =
            h * (wi[0] * f(a) + 
                 wi[1] * f(midPoint) + 
                 wi[2] * f(b));
        double q =
            h * (vi[0] * f(xi[0] * h + a) +
                 vi[1] * f(xi[1] * h + a) +
                 vi[2] * f(xi[2] * h + a));

        double err = Abs(Q - q);

        if (err < Tolerance)
        {
            return Q; // Accept the approximation
        }
        else
        {
            // Subdivide the interval into three sub-intervals
            double integral = Integrate(f, a, midPoint - h / 3.0) +
                              Integrate(f, midPoint - h / 3.0, midPoint + h / 3.0) +
                              Integrate(f, midPoint + h / 3.0, b);
            return integral;
        }
    }
*/


//new attempt
    public static double integrate_sub3(
        Func<double,double> f, 
        double a,               //start point of integral 
        double b,               //end point of integral
        double del = 0.001,
        double eps = 0.001,
        double f2 = NaN
    ){
        double h = b-a;
        if (IsNaN(f2)){         //first call, no points to reuse
            f2 = f(a+3*h/6);
        }
        double f1 = f(a+h/6);
        double f3 = f(a+5*h/6);
        double Q  = (3*f1+2*f2+3*f3)/8*(b-a);  //higher order rule
        double q  = (  f1+  f2+  f3)/3*(b-a);  //lower order rule
        double err= Abs(Q-q);
        if (err <= del + eps*Abs(Q)) return Q;
        else{
            double m1 = (2*a+b)/3.0;
            double m2 = (a+2*b)/3.0;
            double integral =   integrate_sub3 (f, a , m1, del/Sqrt(3), eps, f1) +
                                integrate_sub3 (f, m1, m2, del/Sqrt(3), eps, f2) +
                                integrate_sub3 (f, m2, b , del/Sqrt(3), eps, f3);
            return integral;
        }

    }









    public static double integrate_old(
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
        else{
            double m1 = (2*a+b)/3.0;
            double m2 = (a+2*b)/3.0;
            double integral =   integrate_old (f, a , m1, del/Sqrt(3), eps, f1, f2) +
                                integrate_old (f, m1, m2, del/Sqrt(3), eps) +
                                integrate_old (f, m2, b , del/Sqrt(3), eps, f3, f4);
            return integral;
        }

    }







//To compare ==> subdivision into 2
    public static double integrate_sub2(
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
        else return integrate_sub2 (f, a, (a+b)/2, del/Sqrt(2), eps, f1, f2) +
                    integrate_sub2 (f, (a+b)/2, b, del/Sqrt(2), eps, f3, f4);

    }
}
