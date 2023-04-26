using System;
using static System.Math;
using static System.Console;

class math{
	static void Main(){
		//square root of 2
		double sqrt2 = Sqrt(2.0);
		Write($"sqrt2 = {sqrt2} \n");
		Write($"sqrt2^2 = {sqrt2*sqrt2} (should equal 2) \n");
		//2 to the power of 1/5
		double power2_1fifth = Pow(2.0,0.2);
		Write($"2^(1/5) = {power2_1fifth} \n");
		Write($"(2^(1/5))^5 = {Pow(power2_1fifth,5.0)}  (should equal to 2) \n");
		//e to the power of pi
		Write($"e^pi = {Pow(E,PI)} \n");
		//pi to the power of e
		Write($"pi^e = {Pow(PI,E)} \n");

		//Gamma function
		double gamma_1 = sfuns.gamma(1.0);
		double gamma_2 = sfuns.gamma(2.0);
		double gamma_3 = sfuns.gamma(3.0);
		Write($"\nGamma function approx:\ngamma(1) = {gamma_1} (should be 1), \ngamma(2) = {gamma_2} (should be 1), \ngamma(3) = {gamma_3} (should be 2),\n");
	}
}
