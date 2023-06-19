using System;
using static System.Console;
using static System.Math;

public class spline{

    public static double linterp(double[] x, double[] y, double z){
        int i = binsearch(x,z);
        double dx = x[i+1]-x[i]; if(!(dx>0)) throw new Exception("uups...");
        double dy = y[i+1]-y[i];
        return y[i] + dy/dx * (z-x[i]);
    }

    public static int binsearch(double[] x, double z){
        /* locates the interval for z by bisection */ 
        if(!(x[0]<=z && z<=x[x.Length-1])) throw new Exception("binsearch: bad z");
        int i = 0, j = x.Length-1;
        while(j-i>1){
            int mid=(i+j)/2;
            if(z>x[mid]) i = mid; else j =mid;
        }
        return i;
    }

    public static double linterpInteg(double[] x, double[] y, double z){
        double int_sum = 0;
        int z_bin = binsearch(x,z);
        for(int i = 0; i<z_bin; i++){
            double dx = x[i+1]-x[i];
            double dy = y[i+1]-y[i];
            double p_i = dy/dx;
            int_sum += y[i]*(x[i+1]-x[i]) + p_i/2.0 *(x[i+1]-x[i])*(x[i+1]-x[i]);
        }
        double p_z = (y[z_bin +1]-y[z_bin])/(x[z_bin+1]-x[z_bin]);
        int_sum += y[z_bin]*(z-x[z_bin]) + p_z/2.0 *(z-x[z_bin])*(z-x[z_bin]);
        return int_sum;
    }
}