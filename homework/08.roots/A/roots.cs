using System;
using static System.Console;
using static System.Math;

public static vector newton(
    Func<vector vector> f,      //takes the input vector x and returns the vector f(x)
    vector x,                   //the starting point
    double eps = 1e-2           //the accuracy goal: on exit the condition |f(x)| < eps should be satisfied
){
    dx = Abs(x[i])*Pow(2,-26);  //2^(-26) is the square root of the double (machine epsilon)

    return x0;
}