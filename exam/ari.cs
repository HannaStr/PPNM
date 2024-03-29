using System;
using static System.Math;
using static System.Double;

public class AdaptiveIntegrator{


//Adaptive Recursive Integrator using division into 3 subintervals
    public static double integrate_sub3(
        Func<double, double> f,
        double a,               // start point of integral
        double b,               // end point of integral
        double del = 0.0001 ,              //0.0001,
        double eps = 0.0001,            //0.0001,
        double f2 = NaN
    ){
        double h = b - a;
        if (IsNaN(f2))
        {
            f2 = f(a + 3 * h / 6);
        }
        double f1 = f(a + h / 6);
        double f3 = f(a + 5 * h / 6);

        double Q = ((3 * f1 + 2 * f2 + 3 * f3) / 8) * h; // higher order rule
        double q = ((f1 + f2 + f3) / 3) * h; // lower order rule
        double error = Abs(Q - q);

        if (error <= del + eps * Abs(Q))
        {
            return Q; // Accept the approximation
        }
        else
        {
            double m1 = (2 * a + b) / 3.0;
            double m2 = (a + 2 * b) / 3.0;

            return  integrate_sub3(f, a , m1, del / Sqrt(3), eps, f1) +         // Integrate left sub-interval
                    integrate_sub3(f, m1, m2, del / Sqrt(3), eps, f2) +         // Integrate middle sub-interval
                    integrate_sub3(f, m2, b, del / Sqrt(3), eps, f3);           // Integrate right sub-interval


                    
        }
    }




//To compare ==> subdivision into 2
    public static double integrate_sub2(
        Func<double,double> f, 
        double a,               //start point of integral 
        double b,               //end point of integral
        double del = 0.0001,
        double eps = 0.0001,
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

    //error function
    public static double erf_sub2(double z){
        if (1.0 < z){
            Func<double,double> f = t =>  Exp(-Pow(z+(1-t)/t, 2))/t/t;      //function we want to integrate
            double a = 0.0;
            double b = 1.0;
            double integral = AdaptiveIntegrator.integrate_sub2(f, a, b);
            return 1 - 2.0/Sqrt(PI)*integral;
        }
        if (Abs(z) <= 1.0){
            Func<double, double> f = x => Exp(-Pow(x, 2));
            double a = 0.0;
            double b = z;
            double integral = AdaptiveIntegrator.integrate_sub2(f, a, b);
            return 2/Sqrt(PI)*integral;
        }
        else return -erf_sub2(-z);                                               //if(z<0.0)
    }

    public static double erf_sub3(double z){
        if (1.0 < z){
            Func<double,double> f = t =>  Exp(-Pow(z+(1-t)/t, 2))/t/t;      //function we want to integrate
            double a = 0.0;
            double b = 1.0;
            double integral = AdaptiveIntegrator.integrate_sub3(f, a, b);
            return 1 - 2.0/Sqrt(PI)*integral;
        }
        if (Abs(z) <= 1.0){
            Func<double, double> f = x => Exp(-Pow(x, 2));
            double a = 0.0;
            double b = z;
            double integral = AdaptiveIntegrator.integrate_sub3(f, a, b);
            return 2/Sqrt(PI)*integral;
        }
        else return -erf_sub3(-z);                                               //if(z<0.0)
    }



}