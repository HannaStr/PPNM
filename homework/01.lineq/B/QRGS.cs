using System;
using static System.Console;
using static System.Math;

public class QRGS{
    public matrix Q,R;

    //Gram-Schmidt orthogonalization of matrix A, calculate R
    //code from notes page 3
    public QRGS(matrix a){
        Q = a.copy();
        int m = a.size2;
        R = new matrix (m,m);
        for (int i=0; i<m; i++){
            R[i,i] = Q[i].norm();
            Q[i] /= R[i,i];
            for (int j = i+1; j<m; j++){
                R[i,j] = Q[i].dot(Q[j]);
                Q[j] -= Q[i]*R[i,j];
            }
        }
    }
 

    //return determinant of R using back-substitution
    //code from notes page 2
    public void backsub(matrix U, vector c){
        for (int i = c.size-1; i>=0 ; i--){
            double sum = 0;
            for (int k = i+1; k < c.size; k++){
                sum += U[i, k]*c[k];
            }
            c[i] = (c[i]-sum)/U[i, i];
        }
    }


    //solve QRx=b ==> QR decomposition
    public vector solve(vector b){
        matrix Q_t = Q.transpose();
        vector x = Q_t*b;
        backsub(R, x);
        return x;
    }

    //claculate inverse of the matrix A using the calculated Q and R
    // A*x_i = e_i
    public matrix inverse(matrix A){
        int n = A.size1;
        matrix inv_A = new matrix(n,n);
        for (int i = 0; i < n; i++){
            vector e_i = matrix.id(n)[i];
            inv_A[i] = solve(e_i);
        }
        return inv_A;
    }
}