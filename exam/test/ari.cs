using System;
using static System.Math;

public class AdaptiveIntegrator
{
    private const double Tolerance = 1e-6; // Desired tolerance for integral approximation

    //private static readonly double[] DivisionPoints = { 1.0 / 6.0, 3.0 / 6.0, 5.0 / 6.0 };
    //private static readonly double[] TrapeziumWeights = { 3.0 / 8.0, 2.0 / 8.0, 3.0 / 8.0 };
    //private static readonly double[] RectangleWeights = { 3.0 / 8.0, 2.0 / 8.0, 3.0 / 8.0 };
    private static readonly double[] xi = { 1.0/6.0, 3.0/6.0, 5.0/6.0 };
    private static readonly double[] wi = { 3.0/8.0, 2.0/8.0, 3.0/8.0 };
    private static readonly double[] vi = { 3.0/8.0, 2.0/8.0, 3.0/8.0 };


    public static double Integrate(
        Func<double, double> f, 
        double a, 
        double b,
        double del = 0.001,
        double eps = 0.001,
        double f2 = NaN,
        double f3 = NaN
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
}
