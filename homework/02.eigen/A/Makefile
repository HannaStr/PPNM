Out.txt: main.exe
	mono $< > $@

main.exe: main.cs matrix.dll jacobi.dll
	mcs -target:exe -reference:matrix.dll -reference:jacobi.dll $<

jacobi.dll: jacobi.cs matrix.dll
	mcs -target:library -reference:matrix.dll $<

MATLIB_PATH = ../../../matlib

matrix.dll: $(MATLIB_PATH)/vector.cs $(MATLIB_PATH)/matrix.cs
	mcs -target:library -out:$@ $^

clean:
	rm -f *.exe *.dll *.txt