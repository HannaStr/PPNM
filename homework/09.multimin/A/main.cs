using System;
using static System.Math;
using static System.Console;

public class main{

    public static void Main(){
        //Rosenbrock_func();
        RV_func();
        H_func();

        WriteLine("\n\nNote: The algorithm is taking quite a lot of steps to reach the minimum. This could be improved upon further.");
    }

/*

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
*/

    //Rosenbrock's Valley Function ==> f(x,y) = (1-x)^2 + 100(y-x^2)^2
    public static void RV_func(){
        WriteLine("\n1) Find a minimum of the Rosenbrock's Valley function [f(x,y)=(1-x)^2+100(y-x^2)^2]\n");
        Func<vector, double> f = (xy) => (1-xy[0])*(1-xy[0]) + 100*(xy[1]-xy[0]*xy[0])*(xy[1]-xy[0]*xy[0]);
        vector start = new vector (1.1, 2.0);
        var (res, step) = multimin.qnewton(f,start);
        WriteLine("\nMinima of Rosenbrock's Valley Function are: ");
        WriteLine($"\nx = {res[0]}   should be 1   (starting at {start[0]})"); 
        WriteLine($"\ny = {res[1]}   should be 1   (starting at {start[1]})");
        WriteLine("\nsteps = " + step);
    }

    //Himmelblau's Function ==> f(x,y) = (x^2 + y - 11)^2 + (x + y^2 -7)^2
    public static void H_func(){
        WriteLine("\n2) Find a minimum of the Himmelblau's function [f(x,y)=(x^2+y-11)^2+(x+y^2-7)^2]\n");
        Func<vector, double> f = (xy) => (((xy[0]*xy[0])+xy[1]-11)*((xy[0]*xy[0])+xy[1]-11)+(xy[0]+xy[1]*xy[1]-7)*(xy[0]+xy[1]*xy[1]-7));
        vector start_1 = new vector ( 3.1, 2.1);
        vector start_2 = new vector (-3.1, 3.0);
        vector start_3 = new vector (-4.1,-3.0);
        vector start_4 = new vector ( 3.1,-2.0);
        var (res_1, step_1) = multimin.qnewton(f,start_1);
        var (res_2, step_2) = multimin.qnewton(f,start_2);
        var (res_3, step_3) = multimin.qnewton(f,start_3);
        var (res_4, step_4) = multimin.qnewton(f,start_4);
        WriteLine("\nMinima of Himmelblau's Function are: ");
        WriteLine($"\nx = {res_1[0]}, y = {res_1[1]}   should be ( 3.00, 2.00)   (starting at {start_1[0]},{start_1[1]}) ==> steps taken: {step_1}");
        WriteLine($"\nx = {res_2[0]}, y = {res_2[1]}   should be approx (-2.81, 3.13)   (starting at {start_2[0]},{start_2[1]}) ==> steps taken: {step_2}");
        WriteLine($"\nx = {res_3[0]}, y = {res_3[1]}   should be approx (-3.78,-3.28)   (starting at {start_3[0]},{start_3[1]}) ==> steps taken: {step_3}");
        WriteLine($"\nx = {res_4[0]}, y = {res_4[1]}   should be approx ( 3.58,-1.85)   (starting at {start_4[0]},{start_4[1]}) ==> steps taken: {step_4}"); 

        //WriteLine("\nsteps = " + step);    
    }
}