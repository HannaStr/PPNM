using System;
using static System.Console;
using static System.Math;
using static System.Random;

class main{
	public static void Main(){
		check_decomp();
		check_solve();
	}
	
	public static void check_decomp(){
		WriteLine("......................................");
		WriteLine("TASK 1: Gram-Schmidt orthogonalization");
		WriteLine("``````````````````````````````````````");

		//generate random tall matrix A(n,m) for n>m
		int n=5;
		int m=3;
	
		matrix A = new matrix(n,m);
		Random rndm = new Random();
		for(int i=0; i<n; i++){
			for(int j=0; j<m; j++){
				A[i,j]=rndm.Next(20);
			}
		}
		//WriteLine();
		WriteLine("\na) Take a random tall matrix A:");
		A.print();

		//factorize A into QR
		QRGS lin_system = new QRGS(A);
		WriteLine("\nb) Factorize matrix A into QR. Matrix R is:");
		lin_system.R.print();
		WriteLine("   Note: R should be an upper triangular matrix.");

		//check that (Q^T)Q=1
		matrix QT_Q = lin_system.Q.transpose()*lin_system.Q;
		WriteLine("\nc) Calculate (Q_transposed * Q). It gives:");
		QT_Q.print();
		WriteLine($"   Note: should be an identity matrix.\n   In this case this is: {QT_Q.approx(matrix.id(m))}");

		//check that QR=A
		matrix QR = lin_system.Q*lin_system.R;
		WriteLine("\nd) Calculate (Q*R):");
		QR.print();
		WriteLine($"   Note: Should be equal to the original matrix A.\n   In this case this is: {QR.approx(A)}");
	}

	public static void check_solve(){
		WriteLine();
		WriteLine(".........................................");
		WriteLine("TASK 2: Solve equation QRx=b for given b.");
		WriteLine("`````````````````````````````````````````");
		//generate random square matrix A and random vector b (same size)
		int n = 4;

		matrix A = new matrix(n,n);
		vector b = new vector(n);
		Random rndm = new Random();
		for(int i=0;i<n;i++){
			b[i] = rndm.Next(20);
			for(int j=0;j<n;j++){
				A[i,j]=rndm.Next(20);
			}
		}
		WriteLine("\na) Take a random square matrix A:");
		A.print();
		WriteLine("\n   and a random vector b (of the same size):");
		b.print();

		//factorize A into QR
		QRGS lin_system = new QRGS(A);
		vector x = lin_system.solve(b);
		WriteLine("\nb) Factorize matrix A into QR and solve QRx=b. \n   Therefore, x is:");
		x.print();

		//check that Ax=b
		var Ax = A*x;
		WriteLine("\nc) Calculate (A*x) which gives:");
		Ax.print();
		WriteLine($"   Note: It should be equal to our vector b.\n   In this case this is: {Ax.approx(b)}");

	}
}
