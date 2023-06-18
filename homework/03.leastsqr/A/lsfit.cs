using System;
using static System.Console;
using static System.Math;

public static class lsfit{
    public static vector lsfit(Func<double,double>[] fs, vector x, vector y, vector dy){
        //Solve A(n,m)c(m)=b(n) to get c
        int n = x.size;                     //Fitting n (experimental) data points...
        int m = fs.Length;                  //...by a linear combination of, fs, of m functions
        
        matrix A = new matrix (n,m);
        vector b = new vector (n);

        // A_ik = f_k(x_i)/dy_i     and     b_i = y_i/dy_i  ; equation (14) in notes
        // i-->n, k-->m
        for (int i=0, i<n, i++){
            b[i] = y[i]/dy[i];
            for (int k=0, k<m, k++){
                A[i,k] = fs[k]*(x[i]/dy[i];)
            }
        }

        //factorize A for QR (QRGS)
        QRGS facQR = new QRGS(A);
        vactor c = facQR.solve(b);          //QR decomposition; QRGS.solve()

        return c;
    }
}