using System;
using static System.Console;
using static System.Math;
class erf_data{
	static void Main(){
	    for(double x= -5+1.0/128;x<=5;x+=1.0/64){
		    WriteLine($"{x} {sfuns.erf(x)}");
	    }
    }
}