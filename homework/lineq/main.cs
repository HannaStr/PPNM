using System;
using static System.Console;
using static System.Math;
using static System.Random;

class main{
	public static void Main(){
		decomp_test();
		//solve_test();
	}
	
	public static void decomp_test(){
	
		//matrix A(nxm) where n>m
		int n=3;
		int m=2;
	
		matrix A = new matrix(n,m);
		Random rndm = new Random();
		for(int i=0;i<n;i++){
			for(int j=0;j<m;j++){
				A[i,j]=rndm.Next(10);
			}
		}
		A.print();
	}
}
