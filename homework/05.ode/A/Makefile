all: Out.txt check_ode.svg ode_23.svg

Out.txt: main.exe
	mono $< > $@

check_ode.svg: check_ode.gpi Out.txt
	gnuplot $<

ode_23.svg: ode_23.gpi Out.txt
	gnuplot $<

main.exe: main.cs vector.dll ode.dll
	mcs -target:exe -reference:vector.dll -reference:ode.dll $<

ode.dll: ode.cs vector.dll
	mcs -target:library -reference:vector.dll -out:$@ ode.cs

MATLIB_PATH = ../../../matlib

vector.dll: $(MATLIB_PATH)/vector.cs $(MATLIB_PATH)/matrix.cs
	mcs -target:library -out:$@ $^

clean:
	rm -f *.exe *.dll *.txt
