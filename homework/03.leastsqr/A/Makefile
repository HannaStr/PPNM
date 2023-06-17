all: Out.txt Fit.svg

Fit.svg: fit.gpi Out.txt
	gnuplot $<

Out.txt: main.exe
	mono $< > $@

main.exe: main.cs matrix.dll lsfit.dll
	mcs -target:exe -reference:matrix.dll -reference:lsfit.dll $<

QRGS_DIR: ../../../01.lineq

QRGS.dll: $(QRGS_DIR)/QRGS.cs matrix.dll
	mcs -target:library -reference:matrix.dll $<

lsfit.dll: lsfit.cs matrix.dll
	mcs -target:library -reference:matrix.dll $<

MATLIB_PATH = ../../../matlib

matrix.dll: $(MATLIB_PATH)/vector.cs $(MATLIB_PATH)/matrix.cs
	mcs -target:library -out:$@ $^

clean:
	rm -f *.exe *.dll *.txt