  using System;
using static System.Console;
using static System.Math;

public class spline{

    public static double linterp(double[] x, double[] y, double z){
        int i = binsearch(x,z);
        double dx = x[i+1]-x[i]; 
        if(!(dx>0)) throw new Exception("uups...");
        double dy = y[i+1]-y[i];
        return y[i] + dy/dx * (z-x[i]);
    }

    // locate the interval for z by bisection
    public static int binsearch(double[] x, double z){
        if(!(x[0] <= z && z <= x[x.Length-1])) throw new Exception("binsearch: bad z");
        int i = 0, j = x.Length-1;
        while(j-i > 1){
            int mid=(i+j)/2;
            if(z > x[mid]) i = mid; else j = mid;
        }
        return i;
    }

    // calculate (analytically) the integral of the linear spline from point x[0] to a given point z
    public static double linterpInteg(double[] x, double[] y, double z){
        double sum = 0;
        int z_bis = binsearch(x,z);
        for(int i = 0; i < z_bis; i++){
            //eq (6) in notes
            double dx = x[i+1]-x[i];
            double dy = y[i+1]-y[i];
            double p = dy/dx;
            //eq (8) in notes
            sum += y[i]*(x[i+1]-x[i]) + p/2.0 *(x[i+1]-x[i])*(x[i+1]-x[i]);
        }
        //eq (1) in notes
        double p_z = (y[z_bis +1]-y[z_bis])/(x[z_bis+1]-x[z_bis]);
        sum += y[z_bis]*(z-x[z_bis]) + p_z*((z-x[z_bis])*(z-x[z_bis]))/2;
        return sum;
    }
}