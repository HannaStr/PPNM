using System;
using static System.Console;
using static System.Math;
public static class main{
	public static void Main(){
		/*
		int n=8;
		double[] a = new double[n];
		for(int i=0;i<n;i++) Write($"a[{i}]={a[i]} ");
		WriteLine();
		for(int i=0;i<n;i++) a[i]=i;
		for(int i=0;i<n;i++) Write($"a[{i}]={a[i]} ");
		WriteLine();
		WriteLine($"array length = {a.Length}");
		foreach(double ai in a) Write($" ai = {ai}");
		WriteLine();
		*/
		vec u = new vec(2,3,4);
		vec v = new vec(1,2,3);
		u.print    ("u  = ");
		v.print    ("v  = ");
		(u+v).print("u+v= ");
		(2*u).print("2*u= ");
		vec w=u*2;
		w.print("u*2= ");
		vec w2 = u+6*v -w;
		w2.print   ("w2 = u+6*v = ");
		(-u).print ("-u = ");
		WriteLine($"u%v = {u%v}");
		WriteLine($"u.dot(v) = {u.dot(v)}");
		(u.cross(v)).print("cross product = ");
		(v.cross(u)).print("cross product = ");
		WriteLine($"norm(v) = {v.norm()}");
		WriteLine($"norm(u) = {u.norm()}");
		WriteLine($"approx(u,v) = {u.approx(v)}");
		WriteLine($"approx(u,u) = {u.approx(u)}");
	}
}
