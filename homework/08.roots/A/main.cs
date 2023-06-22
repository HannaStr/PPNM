using System;
using static System.Console;
using static System.Math;

public class main{

    public static void Main(){
        WriteLine("\nTASK 1: Test the root-finding routine using some simple equations.\n");
        test_1d();
        test_2d();
    }

// f(x) = {f_1(x_1, ..., x_n), ..., f_N(x_1, ..., x_n)}
    public static void test_1d(){
        //1-dimentional function ==> N=1
        Func<vector, vector> f = x_n => new vector(Pow(x_n[0],2)-9);
        vector a_11 = new vector(2.0);
        vector a_12 = new vector(-0.01);
        var res_11 = roots.newton(f, a_11);
        var res_12 = roots.newton(f, a_12);
        WriteLine("\na) Test for a 1-dimentional function\n");
        WriteLine("   Find the roots of f(x)=x^2-9:");
        WriteLine($"   The roots are at: {res_11[0]}  (should be at 3) and at {res_12[0]}  (should be at -3)\n");
    }

    public static void test_2d(){
        //2-dimentional function ==> N=2
        Func<vector, vector> f = x_n => new vector(Pow(x_n[0],2)-9, Pow(x_n[1],2)-4);
        vector a_21 = new vector( 2.0, 5.0);
        vector a_22 = new vector(-0.1, -1.0);
        var res_21 = roots.newton(f, a_21);
        var res_22 = roots.newton(f, a_22);
        WriteLine("\nb) Test for a 2-dimentional function\n");
        WriteLine("   Find the roots of f(x)={(x^2-9), (x^2-4)}:");
        WriteLine($"   The roots are at: {res_21[0]}, {res_22[0]}  (should be at 3, -3) and at {res_21[1]}, {res_22[1]}  (should be at 2, -2)\n");
    }

}