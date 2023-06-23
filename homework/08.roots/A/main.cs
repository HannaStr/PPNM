using System;
using static System.Console;
using static System.Math;

public class main{

    public static void Main(){
        WriteLine("\nTASK 1: Test the root-finding routine using some simple equations.\n");
        test_1d();
        test_2d();
        WriteLine("\nTASK 2: Apply the root-finding routine to the Rosenbrock's valley function.\n");
        RV_func();
    }

// f(x) = {f_1(x_1, ..., x_n), ..., f_N(x_1, ..., x_n)}
    public static void test_1d(){
        //1-dimentional function ==> N=1
        Func<vector, vector> f = x_n => new vector(Pow(x_n[0],2)-9);
        vector x_11 = new vector(2.0);
        vector x_12 = new vector(-0.01);
        var root_11 = roots.newton(f, x_11);
        var root_12 = roots.newton(f, x_12);
        WriteLine("\na) Test for a 1-dimentional function\n");
        WriteLine("   Find the roots of f(x)=x^2-9:");
        WriteLine($"   The roots are at: {root_11[0]}  (should be at 3) and at {root_12[0]}  (should be at -3)\n");
    }

    public static void test_2d(){
        //2-dimentional function ==> N=2
        Func<vector, vector> f = x_n => new vector(Pow(x_n[0],2)-9, Pow(x_n[1],2)-4);
        vector x_21 = new vector( 2.0, 5.0);        //x_21 ==> 2 functions, 1st roots
        vector x_22 = new vector(-0.1, -1.0);       //x_22 ==> 2 functions, 2nd roots
        var root_21 = roots.newton(f, x_21);
        var root_22 = roots.newton(f, x_22);
        WriteLine("\nb) Test for a 2-dimentional function\n");
        WriteLine("   Find the roots of f(x)={(x^2-9), (x^2-4)}:");
        WriteLine($"   The roots are at: {root_21[0]}, {root_22[0]}  (should be at 3, -3) and at {root_21[1]}, {root_22[1]}  (should be at 2, -2)\n");
    }

    public static void RV_func(){
        //Rosenbrock's Valley Function
        //f(x,y) = (1-x)^2 + 100(y-x^2)^2
        Func<vector, vector> f = xy => new vector(
            2*(200*Pow(xy[0],3)-200*xy[0]*xy[1]+xy[0]-1),       // (df/dx)
            200*(xy[1]-Pow(xy[0],2))                            // (df/dy)
        );                           
        vector a_21 = new vector( 0.999,-1.1);
        vector a_22 = new vector( 0.999, 1.1);
        var res_21 = roots.newton(f, a_21);
        var res_22 = roots.newton(f, a_22);
        WriteLine("\na) Find the extremum(s) of the Rosenbrock's valley function. \n");
        WriteLine("   Find the roots of f(x,y) = (1-x)^2 + 100(y-x^2)^2:");
        WriteLine($"   The roots are at: {res_21[0]}, {res_22[0]}  (should be x=1, y=1)  and {res_21[1]}, {res_22[1]}  (should be x^2=y)\n");
    }


}