using System;
using static System.Console;
using static System.Math;
using static System.Random;

class main{
    public static void Main(){
        check_jacobi();
    }

    public static void check_jacobi(){
        WriteLine(".................................");
		WriteLine("TASK: Jacobi eigenvalue algorithm");
		WriteLine("`````````````````````````````````");

		//generate random symmetric matrix A(n,n)
		int n=5;
	
		matrix A = new matrix(n,n);
		Random rndm = new Random();
		for(int i=0; i<n; i++){
			for(int j=0; j<n; j++){
				A[i,j]=rndm.Next(20);
                A[i,j]=A[j,i];
			}
		}

		WriteLine("\na) Take a random matrix A:");
		A.print();

        //perform the eigenvalue-decomposition (EVD) ==> A=V*D*(V_transposed)
        matrix D = A.copy();
        matrix V = matrix.id(n);

        (D,V)=jacobi.cyclic(A);
        D.print();
        V.print();


    }
}