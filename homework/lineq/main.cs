using System;
using static System.Console;
using static System.Math;
using static System.Random;

class main{
	public static void Main(){
		decomp_test();
		//solve_test();
	}
	
	public static void check_decomp(){
		WriteLine("Gram-Schmidt orthogonalization");
		
		//generate random tall matrix A(n,m) for n>m
		int n=3;
		int m=2;
	
		matrix A = new matrix(n,m);
		Random rndm = new Random();
		for(int i=0;i<n;i++){
			for(int j=0;j<m;j++){
				A[i,j]=rndm.Next(20);
			}
		}
		WriteLine("Random matrix A is");
		A.print();

		//factorize A into QR
		QRGS lin_system = new decomp(A);
		WriteLine("Factorize matrix A into QR. R should be upper triangular. It is:")
		lin_system.R.print();

		//check that (Q^T)Q=1
		matrix QT_Q = lin_system.Q.transpose()*lin_system.Q;
		WriteLine("Q^T*Q should be 1. It is:");
		QT_Q.print();

		//check that QR=A
		matrix QR = lin_system.Q*lin_system.R;
		WriteLine("Q*R should equal original matrix A. It is:")
		QR.print();
	}

	//public static void check_solve(){

	//}
}
