using System;
using static System.Double;
using static System.Math;

public class AdaptiveIntegrator
{
    //private const double Tolerance = 1e-6; // Desired tolerance for integral approximation
/*
    DivisionPoints      ==>     xi = { 1.0/6.0, 3.0/6.0, 5.0/6.0 }
    TrapeziumWeights    ==>     wi = { 3.0/8.0, 2.0/8.0, 3.0/8.0 }
    RectangleWeights    ==>     vi = { 3.0/8.0, 2.0/8.0, 3.0/8.0 }
*/

//current one
    public static double integrate_sub3(
        Func<double, double> f,
        double a,               // start point of integral
        double b,               // end point of integral
        double delta = 0.0001,              //0.0001,
        double epsilon = 0.0001,            //0.0001,
        double f2 = NaN
    )
    {
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

        if (error <= delta + epsilon * Abs(Q))
        {
            return Q; // Accept the approximation
        }
        else
        {
            double m1 = (2 * a + b) / 3.0;
            double m2 = (a + 2 * b) / 3.0;

            double integral = 0.0;

            integral += integrate_sub3(f, a, m1, delta / Sqrt(3), epsilon, f1); // Integrate left sub-interval
            integral += integrate_sub3(f, m1, m2, delta / Sqrt(3), epsilon, f2); // Integrate middle sub-interval
            integral += integrate_sub3(f, m2, b, delta / Sqrt(3), epsilon, f3); // Integrate right sub-interval

            return integral;
        }
    }

/*
//AI
    public static double integrate_sub3_AI(
        Func<double, double> f,
        double a,               // start point of integral
        double b,               // end point of integral
        double delta = 0.0001,              //0.0001,
        double epsilon = 0.0001,            //0.0001,
        double f1 = NaN,
        double f2 = NaN,
        double f3 = NaN
    )
    {
        double h = b - a;
        if (IsNaN(f1))
        {
            f1 = f(a + h / 6);
            f2 = f(a + 3 * h / 6);
            f3 = f(a + 5 * h / 6);
        }

        double Q = ((3 * f1 + 2 * f2 + 3 * f3) / 8) * h; // higher order rule
        double q = ((f1 + f2 + f3) / 3) * h; // lower order rule
        double error = Abs(Q - q);

        if (error <= delta + epsilon * Abs(Q))
        {
            return Q; // Accept the approximation
        }
        else
        {
            double m1 = (2 * a + b) / 3.0;
            double m2 = (a + 2 * b) / 3.0;

            double integral = 0.0;

            if (a < 0.0 && b > 0.0)
            {
                integral += integrate_sub3(f, a, 0.0, delta / Sqrt(3), epsilon, f1, f2, f3);
                a = 0.0;
            }

            integral += integrate_sub3(f, a, m1, delta / Sqrt(3), epsilon, f1, f2, f3); // Integrate left sub-interval
            integral += integrate_sub3(f, m1, m2, delta / Sqrt(3), epsilon, f1, f2, f3); // Integrate middle sub-interval
            integral += integrate_sub3(f, m2, b, delta / Sqrt(3), epsilon, f1, f2, f3); // Integrate right sub-interval

            return integral;
        }
    }

*/

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



//-----------------OLD----------OLD-------------
/*
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

    public static double integrate_lessold(
        Func<double,double> f, 
        double a,               //start point of integral 
        double b,               //end point of integral
        double del = 0.0001,
        double eps = 0.0001,
        double f2 = NaN
    ){
        double h = b-a;
        if (IsNaN(f2)){         //first call, no points to reuse
            f2 = f(a+3*h/6);
        }
        double f1 = f(a+h/6);
        double f3 = f(a+5*h/6);

        //double Q  = (3*f1+2*f2+3*f3)/8*(b-a);  //higher order rule
        //double q  = (  f1+  f2+  f3)/3*(b-a);  //lower order rule

        double Q  = (2*f1+3*f2+2*f3)/8*(b-a);  //higher order rule
        double q  = (  f1+2*f2+  f3)/4*(b-a);  //lower order rule

        double err= Abs(Q-q);

        if (err <= del + eps*Abs(Q)) return Q;    //accept the approximation
        else{
            double m1 = (2*a+b)/3.0;
            double m2 = (a+2*b)/3.0;

            double integral = 0.0;

            if (a < 0.0&& b > 0.0){
                integral += integrate_sub3(f, a, Min(m1, 0.0), del/Sqrt(3), eps, f1);
                a = 0.0;
            }
            integral += integrate_sub3 (f, a , m1, del/Sqrt(3), eps, f1) +
                        integrate_sub3 (f, m1, m2, del/Sqrt(3), eps, f2) +
                        integrate_sub3 (f, m2, b , del/Sqrt(3), eps, f3);
            return integral;
        }

    }
*/

}
