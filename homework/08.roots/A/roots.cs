using System;
using static System.Console;
using static System.Math;

public static vector newton(
    Func<vector vector> f,      //takes the input vector x and returns the vector f(x)
    vector x,                   //the starting point
    double eps = 1e-2           //the accuracy goal: on exit the condition |f(x)| < eps should be satisfied
){

/*  EXAMPLE
    repeat
        calculate the Jacobian
        solve J*dx = -f(x) for dx
        lamda <-- 1
        while |f(x+lamda*dx)| > (1-lamda/2)|f(x)| and lamda >= 1/1024 do lambda <-- lambda/2
        x <-- x + lambda*dx
*/
    int n = x.size;
    matrix J = new matrix (n,n);
    vector f_x = f(x);
    //double del_x = Sqrt(eps);

    //repeat
    while(diverge){
        //calculate the Jacobian
        for(int i=0; i<n; i++){
            double del_x = Abs(x[i])*Pow(2,-26);  //2^(-26) is the square root of the double (machine epsilon)
            for(int k=0; k<n; k++){
                vector x_k = x.copy;
                x_k[k] += del_x;
                J[i,k] = (f(x_k)[i]-f_x[i](x))/del_x;
            }
        }

        //solve J*dx = -f(x) for dx
		QRGS lin_system = new QRGS(J);
		vector dx = lin_system.solve(-f_x);
		WriteLine("\nb) Solve J*dx= -f(x). \n   Therefore, dx is:");
		dx.print();

        //lambda <-- 1
        double lambda = 1.0;

        //while |f(x+lamda*dx)| > (1-lamda/2)|f(x)| and lamda >= 1/1024 do lambda <-- lambda/2
        while(Abs(f(x+lambda*dx)) > (1-lambda/2)*Abs(f(x)) && lambda >= 1/1024){
            lambda = lambda/2.0;
        }
        //x <-- x + lambda*dx
        x += lambda*dx;
        diverge = Abs(f(x)) < eps;
        f_x = f(x);
    }


    //dx is the solution to LinEq (J*dx=-f(x)) ==> Newton's step 
    return x;
}