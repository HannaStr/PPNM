using System;
using static System.Math;
using static System.Console;

public class main{

    public static void Main(){
        Rosenbrock_func();
        //RV_func();
        //H_func();
    }


    //Rosenbrock's Valley Function ==> f(x,y) = (1-x)^2 + 100(y-x^2)^2
    public static void Rosenbrock_func(){
        WriteLine("--------------------------------------");
        WriteLine("Find the extrema of the Rosenbrock's Valley function of f(x)=(1-x^2)^2+100(y-x^2)^2:");
        Func<vector, double> f = delegate(vector x){
            return (1-x[0])*(1-x[0]) + 100*(x[1]-x[0]*x[0])*(x[1]-x[0]*x[0]);
        };
        vector a = new vector(1.1,2);
        var (res,steps) = multimin.qnewton(f, a);
        WriteLine($"The minimum is at (x,y) = ({res[0]}, {res[1]}) (should be (1,1)),\nstarting at ({a[0]},{a[1]}) with {steps} steps");
    }

    //Himmelblau's Function ==> f(x,y) = (x^2 + y - 11)^2 + (x + y^2 -7)^2
    public static void RV_func(){
        WriteLine("\n1) Find a minimum of the Rosenbrock's Valley function [f(x,y)=(1-x)^2+100(y-x^2)^2]");

    }
}