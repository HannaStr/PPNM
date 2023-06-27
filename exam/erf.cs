using System;
using static System.Console;
using static System.Math;

public class erf{

    public static void Main(){
        erf_sub2_data();
        WriteLine("\n\n");
        erf_sub3_data();
    }

    public static void erf_sub2_data(){
        WriteLine();
        for(double i=-3.5; i<=3.5; i=i+1.0/32.0){
            double erf_i = AdaptiveIntegrator.erf_sub2(i);
            WriteLine($"{i} {erf_i}");
        }        
    }

    public static void erf_sub3_data(){
        WriteLine();
        for(double i=-3.5; i<=3.5; i=i+1.0/32.0){
            double erf_i = AdaptiveIntegrator.erf_sub3(i);
            WriteLine($"{i} {erf_i}");
        }        
    }
}