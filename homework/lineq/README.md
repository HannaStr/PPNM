=============================
LINEAR EQUATIONS - Homework 1
=============================

---------
Objective
---------
Implement functions to solve linear equations;
calculate matrix inverse;
and calculate matrix determinant using the (modified) Gram-Schmidt orthogonalization method.

The Gram-Schmidt orthogonalization process, even modified, is less stable and accurate than the Givens roation algorithm.
On the other hand, the Gram-Schmidt process produces the j-th orthogonalized vector after the j-th iteration,
while orthogonalization using Givens rotations produces all the vectors only at the end.
This makes the Gram–Schmidt process applicable for iterative methods like the Arnoldi iteration.
Also its ease of implementation makes it a useful exercise for the students.

---------
Tasks
---------
A - (6 points) Solving linear equations using QR-decomposition by modified Gram-Schmidt orthogonalization
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
Implement a static (or, at your choice, non-static) class "QRGS" with functions "decomp", "solve", and "det" (as indicated above).
In the non-static class "decomp" becomes a constructor and must be called "QRGS").

The function "decomp" (or the constructor QRGS) should perform stabilized Gram-Schmidt orthogonalization of an n×m (where n≥m) matrix A and calculate R.

The function/method "solve" should use the matrices Q and R from "decomp" and solve the equation QRx=b for the given right-hand-side "b".

The function/method "det" should return the determinant of matrix R which is equal to the determinant of the original matrix. 
Determinant of a triangular matrix is given by the product of its diagonal elements.

Check that your "decomp" works as intended:

generate a random tall (n>m) matrix A (of a modest size);
factorize it into QR;
check that R is upper triangular;
check that QTQ=1;
check that QR=A;
Check that you "solve" works as intended:

generate a random square matrix A (of a modest size);
generate a random vector b (of the same size);
factorize A into QR;
solve QRx=b;
check that Ax=b;~


B - (3 points) Matrix inverse by Gram-Schmidt QR factorization
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
Add the function/method "inverse" to your "QRGS" class that, using the calculated Q and R, should calculate the inverse of the matrix A and returns it.

Check that you function works as intended:

generate a random square matrix A (of a modest size);
factorize A into QR;
calculate the inverse B;
check that AB=I, where I is the identity matrix;


C - (1 point) Operations count for QR-decomposition
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
Measure the time it takes to QR-factorize (with your implementation) a random NxN matrix as function of N.
Convince yourself that it goes like O(N³): measure (using the POSIX time utility) the time it takes to QR-factorize an N×N matrix for several values of N,
plot the time as function of N in gnuplot and fit with N³.

You can build your timing data like this (you might want to read

man bash | less +/"for name"
man 1 seq
man 1 time 
),

out.times.data : main.exe
	>$@
	for N in $$(seq 100 20 200); do \
		time --format "$$N %e" --output $@ --append \
		mono $< -size:$$N 1>out 2>err ;\
	done
	
