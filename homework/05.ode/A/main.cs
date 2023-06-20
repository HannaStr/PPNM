using System;
using static System.Console;
using static System.Math;

public class main{
    public static void Main(){
        step_12();
        step_23();
        pendulun_scipy();
    }
    
    public static void step_12(){
        WriteLine();
        
        double h = 0.1;
        Func<double, vector, vector> osc = delegate(double t, vector y){
            return new vector (y[1], -y[0]);           //u''=-u
        };

        double[] initial_cond = new double [] {1.0, 0.0};
        vector y0_osc = new vector(initial_cond);
            for(double t0 = h; t0 <= 10.0; t0 += h){
                vector sol = ode.driver12(osc, t0-h, y0_osc, t0);
                WriteLine($"{t0} {sol[0]} {sol[1]}");
                y0_osc = sol;
            }
    }

    public static void step_23(){
        WriteLine();
        WriteLine();

        double h = 0.1;
        Func<double, vector, vector> osc = delegate(double t, vector y){
            return new vector (y[1], -y[0]);
        };

        double[] initial_cond = new double [] {1.0, 0.0};
        vector y0_osc = new vector(initial_cond);
            for(double t0 = h; t0 <= 10.0; t0 += h){
                vector sol = ode.driver23(osc, t0-h, y0_osc, t0);
                WriteLine($"{t0} {sol[0]} {sol[1]}");
                y0_osc = sol;
            }


    }
}