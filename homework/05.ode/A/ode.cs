using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;

public static class ode{

/*    public static (vector, vector) rkstepXY(Func<double,vector,vector> f, double x, vector y, double h){    
        vector k = //...

        vector yh = //...
        vector er = //...
        
        return (yh,er);
    }
*/

    //simple mid-point Euler method
    public static (vector, vector) rkstep12(
        Func <double, vector, vector> f,           // the f from dy/dx=f(x,y)
        double x,                               // the current value of the variable
        vector y,                               // the current value y(x) of the sought function
        double h                                // the step to be taken
    ){
        vector k0 = f(x,y);                     // embedded lower order formula (Euler)
        vector k1 = f(x+h/2, y+k0*(h/2));       // higher order formula (midpoint)

        vector yh = y+k1*h;                     // y(x+h) estimate
        vector er = (k1-k0)*h;                  // error estimate

        return (yh,er);
    }

    public static (vector, vector) rkstep23(
        Func <double, vector, vector> f,
        double x, vector y, double h
    ){
        vector k0 = f(x,y);
        vector k1 = f(x+h/2, y+k0*(h/2));
        vector k2 = f(x+3*h/4, y+k1*(3*h/4));

        vector ka = k0*(2.0/9)+k1*(3.0/9)+k2*(4.0/9);
        vector kb = k1;

        vector yh = y+ka*h;
        vector er = (ka-kb)*h;

        return (yh, er);

    }


    public static vector driver12(
        Func<double,vector,vector> f,   // the f from dy/dx=f(x,y)
        double a,                       // the start-point a
        vector ya,                      // y(a)
        double b,                       // the end-point of the integration
        double h=0.01,                  // initial step-size
        double acc=0.01,                // absolute accuracy goal
        double eps=0.01                // relative accuracy goal
        //genlist<double> xlist = null,
        //genlist<vector> ylist = null
    ){
        if (a>b) throw new ArgumentException ("driver: a>b");
        double x = a;
        vector y = ya.copy();

        /*var xlist = new genlist <double>();
        xlist.add(x);
        var ylist =new genlist <vector>();
        ylist.add(y);*/

        //if(xlist!=null){xlist.clear(); xlist.push(x);}
        //if(ylist!=null){ylist.clear(); ylist.push(y);}

        do{
            //if (x >= b) return (xlist, ylist);
            if (x >= b) return y;                                   // job done
            if (x+h > b) h = b - x;                                 // last step should end at b
            var (yh, erv) = rkstep12 (f, x, y, h);
            double tol = Max(acc, eps*yh.norm()) * Sqrt(h/(b-a));
            double err = erv.norm();
            if(err <= tol){
                x += h;
                y = yh;
                //xlist.add(x);
                //ylist.add(y);
                //if(xlist!=null)xlist.push(x);
                //if(ylist!=null)ylist.push(y);
            }
            h *= Min (Pow(tol/err, 0.25)*0.95, 2);                  // reajust step-size
        }
        while(true);
    }


    public static vector driver23(
        Func<double,vector,vector> f,   // the f from dy/dx=f(x,y)
        double a,                       // the start-point a
        vector ya,                      // y(a)
        double b,                       // the end-point of the integration
        double h=0.01,                  // initial step-size
        double acc=0.01,                // absolute accuracy goal
        double eps=0.01                 // relative accuracy goal
    ){
        if (a>b) throw new ArgumentException ("driver: a>b");
        double x = a;
        vector y = ya.copy();

        do{
            if (x >= b) return y;                                   // job done
            if (x+h > b) h = b - x;                                 // last step should end at b
            var (yh, erv) = rkstep12 (f, x, y, h);
            double tol = Max(acc, eps*yh.norm()) * Sqrt(h/(b-a));
            double err = erv.norm();
            if(err <= tol){
                x += h;
                y = yh;
            }
            h *= Min (Pow(tol/err, 0.25)*0.95, 2);                  // reajust step-size
        }
        while(true);
    }

/*    public static vector driverXY(Func<double,vector,vector> f, double a, vector ya, double b, double h=0.01, double acc=0.01, double eps=0.01){
        if (a>b) throw new ArgumentException ("driver: a>b");
        double x = a;
        vector y = ya.copy();

        var xlist = new genlist<double>();
        xlist.add(x);
        var ylist =new genlist<vector>();
        ylist.add(y);

        do{
            if (x >= b) return (xlist, ylist);
            if (x+h > b) h = b - x;
            var (yh, erv) = rkstepXY (F, x, y, h);
            double tol = (acc+eps*yh.norm()) * Sqrt(h/(b-a));
            double err = erv.norm();
            if(err <= tol){
                x += h;
                y = yh;
                xlist.add(x);
                ylist.add(y);
            }
            h *= Min (Pow(tol/err), 0.25*0.95, 2);
        }
        while(true);
    }*/
}