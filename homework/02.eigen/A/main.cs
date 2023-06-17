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
                A[j,i]=A[i,j];
			}
		}

		WriteLine("\na) Take a random matrix A:");
		A.print();

        //perform the eigenvalue-decomposition (EVD) ==> A=V*D*(V_transposed)
        WriteLine("\nb) Perform the Eigenvalue Decomposition (EVD): A = V * D * V_transposed");
        matrix D, V;

        (D,V)=jacobi.cyclic(A);
        WriteLine("\n   'D' is a diagonal matrix with the eigenvalues:");
        D.print();
        WriteLine("\n   and 'V' is a matrix of orthogonalized eigenvectors corresponding to the eigenvalues:");
        V.print();

        //check that V_T*A*V=D
        matrix Vt_A_V = V.transpose()*A*V;
        WriteLine("\nc) Calculate (V_transposed * A * V):");
        Vt_A_V.print();
        WriteLine($"\n   Note: It should equal to D. In this case it is: {Vt_A_V.approx(D)}");
        
        //check that V*D*V_T=A
        matrix V_D_Vt = V*D*V.transpose();
        WriteLine("\nd) Calculate (V * D * V_transposed):");
        V_D_Vt.print();
        WriteLine($"\n   Note: It should equal to A. In this case it is: {V_D_Vt.approx(A)}");

        //check that V_T*V=I
        matrix Vt_V = V.transpose()*V;
        WriteLine($"\ne) Calculate (V_transposed * V)\n   It should be an identity matrix. In this case this is: {Vt_V.approx(matrix.id(n))}");

        //check that V*V_T=I
        matrix V_Vt = V*V.transpose();
                WriteLine($"\nf) Calculate (V * V_transposed)\n   It should be an identity matrix. In this case this is: {V_Vt.approx(matrix.id(n))}");
    }
}