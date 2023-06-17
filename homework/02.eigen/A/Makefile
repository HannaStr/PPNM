Out.txt : main.exe
	mono $< > $@

main.exe: main.cs matrix.dll jacobi.dll
	mcs -target:exe -reference:matrix.dll -reference:jacobi.dll $<

jacobi.dll: jacobi.cs matrix.dll
	mcs -target:library -reference:matrix.dll $<

LIBPATH = ../../../matlib

matrix.dll : $(LIBPATH)/vector.cs $(LIBPATH)/matrix.cs
	mcs -target:library -out:$@ $^

clean:
	rm -f *.exe *.dll *.txt