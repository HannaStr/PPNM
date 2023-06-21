all: Out.txt plot.svg

Out.txt: main.exe
	mono $< > $@

plot.svg: plot.gpi unit_circ.data
	gnuplot $<

unit_circ.data: unit_circ.exe
	mono $< > $@

unit_circ.exe: unit_circ.cs vector.dll MC.dll
	mcs -target:exe -reference:vector.dll -reference:MC.dll $<

main.exe: main.cs vector.dll MC.dll
	mcs -target:exe -reference:vector.dll -reference:MC.dll $<

MC.dll: MC.cs vector.dll
	mcs -target:library -reference:vector.dll $<

MATLIB_PATH = ../../../matlib

vector.dll: $(MATLIB_PATH)/matrix.cs $(MATLIB_PATH)/vector.cs
	mcs -target:library -out:./$@ $^

clean:
	rm -f *.exe *.dll *.txt