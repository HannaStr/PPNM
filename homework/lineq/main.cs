using System;
using static System.Console;
using static System.Math;
using static System.Random;

class main{
	public static void Main(){
		check_decomp();
		//check_solve();
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

	public static void check_solve(){
		WriteLine("Solve equation QRx=b for given b.")
		//generate random square matrix A and random vector b (same size)
		int n = 4;

		matrix A = new matrix(n,n);
		vector b = new vector(n);
		Random rndm = new Random();
		for(int i=0;i<n;i++){
			b[i] = rndm.Next(20)
			for(int j=0;j<n;j++){
				A[i,j]=rndm.Next(20);
			}
		}
		WriteLine("Random matrix A is:");
		A.print();
		WriteLine("and random vector b is:");
		b.print();

		//factorize A into QR
		QRGS lin_system = new decomp(A);
		vector x = lin_system.solve(b)
		WriteLine("Factorize matrix A into QR and solve QRX=b. x is:")
		x.print();

		//check that Ax=b
		var Ax = A*x;
		WriteLine("A*x should be equal to vector b. It is:")
		Ax.print();

	}
}
