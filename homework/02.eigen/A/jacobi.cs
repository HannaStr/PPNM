using System;
using static System.Console;
using static System.Math;

public class jacobi{

    //code from course page part A.1 (can stay as is)
    public static void timesJ(matrix A, int p, int q, double theta){
        double c=Cos(theta), s=Sin(theta);
        for(int i=0; i<A.size1; i++){
            double aip=A[i,p], aiq=A[i,q];
            A[i,p]=c*aip-s*aiq;
            A[i,q]=s*aip+c*aiq;
        }
    }

    //code from course page part A.2 (can stay as is)
    public static void Jtimes(matrix A, int p, int q, double theta){
        double c=Cos(theta), s=Sin(theta);
        for(int j=0; j<A.size1; j++){
            double apj=A[p,j], aqj=A[q,j];
            A[p,j]= c*apj+s*aqj;
            A[q,j]=-s*apj+c*aqj;
        }
    }

    //code from course page part A.3
    public static (matrix,matrix) cyclic(matrix A){                                 //this function requires some changes
        matrix D = A.copy();
        int m = A.size1;
        matrix V = matrix.id(m);

        bool changed;
        do{
            changed=false;
            for(int p=0; p<m-1; p++){
                for(int q=p+1; q<m; q++){
                    double apq=D[p,q], app=D[p,p], aqq=D[q,q];      //verify if this is correct
                    double theta=0.5*Atan2(2*apq, aqq-app);
                    double c=Cos(theta), s=Sin(theta);
                    double new_app=c*c*app-2*s*c*apq+s*s*aqq;
                    double new_aqq=s*s*app+2*s*c*apq+c*c*aqq;
                    if(new_app!=app || new_aqq!=aqq){               //do rotation
                        changed = true;
                        timesJ(D, p, q, theta);                     // D <-- D * J
                        Jtimes(D, p, q,-theta);                     // D <-- J^T * D
                        timesJ(V, p, q, theta);                     // V <-- V * J
                    }
                }
            }
        }
        while (changed);
        return (D,V);
    }
}