using System;
using static System.Math;

public static class multimin{

// QUASI-NEWTON MINIMIZATION
    public static (vector,int) qnewton(
        Func<vector,double> f,          //objective function
        vector x,                   //startin point
        double acc = 0.01              //accuracy goal, on exit |gradient| should be < acc
    ){

        //set the inverse Hessian matrix to unity, B=1
        int n = x.size;
        matrix B  = matrix.id(n);
        matrix dB = new matrix (n,n);

        int step = 0;

        vector grad_x = num_grad(f,x);
        vector y = new vector(n);
        vector u = new vector(n);
        vector s = new vector(n);


        //repeat until converged (e.g. |grad_x|<tolerance):
        while (grad_x.norm() > acc){

            //calculate the Newton's step del_x = -B*grad_x
            vector del_x = -B*grad_x;

            //do linesearch starting with lambda = 1:
            double lam = 1.0;
            //double fx = f(x);

// BACK-TRACKING LINESEARCH 

            while(true){                    //linesearch ==> infinite loop until the command "break"

                //if f(x+lambda*del_x)<f(x) accept the step and update B:
                s = lam*del_x;
                if (f(x + s) < f(x)){
                    vector grad_x_NOs = grad_x;

                    //x = x + lambda*del_x
                    x = x + s;

// RANK-1 UPDATE

                    //update B = B+dB (rank-1 update)
                    grad_x = num_grad(f,x);
                    y = grad_x - grad_x_NOs;
                    u = s - B*y;                        //page 3 in notes
                    double u_y = u.dot(y);
                    if (Abs(u_y) > 1e-6){
                        dB = matrix.outer(u,u)/u_y;     //Eqn (18) in notes
                        B = B + dB;
                    }
                    
                    //break linesearch
                    break;
                }

                //lambda = lambda/2
                lam = lam/2;

                //if lambda < 1/1024 accept the step and reset B:
                if (lam < 1.0/1024){

                    //x = x+lambda*del_x
                    x = x + s;
                    grad_x = num_grad(f,x);

                    //B=1
                    B = matrix.id(n);

                    //break linsearch
                    break;
                }

                //continue linesearch
            }
            step++;
        }
        return(x,step);

    }

// NUMERICAL GRADIENT

    public static vector num_grad(
        Func<vector,double> f,
        vector x
    ){
        int n = x.size;
        double del = 1e-8;

        vector grad    = new vector(n);
        vector x_plus  = x.copy();
        vector x_minus = x.copy();
        
        for (int i = 0; i < n; i++){
            x_plus[i]  += del;
            x_minus[i] -= del;
            grad[i] = (f(x_plus) - f(x_minus))/(2.0*del);
        }
        return grad;
    }

/*
        public static vector numeric_gradient(
        Func<vector,double> f,
        vector x
    ){
        double Delta = Pow(2,-26);

        int n = x.size;
        vector gradient = new vector(n);
        double f_x = f(x);
        for(int i=0; i<n; i++){
            double dx;
            double x_i = x[i];
            if(Abs(x_i)<Sqrt(Delta)){
                dx = Delta;
            }
            else{
                dx = Abs(x_i)*Delta;
            };

            x[i] = x_i+dx;
            gradient[i] = (f(x)-f_x)/dx;
            x[i] = x_i;
        }
        return gradient;
    }
*/
}