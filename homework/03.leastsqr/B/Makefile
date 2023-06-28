all: Out.txt Plot.svg

Plot.svg: plot.gpi data.data
	gnuplot $<

Out.txt: main.exe
	mono $< > $@

data.data: data.exe
	mono $< > $@

data.exe: data.cs lsfit.dll matrix.dll
	mcs -target:exe -reference:lsfit.dll -reference:matrix.dll $<

main.exe: main.cs matrix.dll lsfit.dll
	mcs -target:exe -reference:matrix.dll -reference:lsfit.dll $<

lsfit.dll: lsfit.cs matrix.dll QRGS.dll
	mcs -target:library -reference:matrix.dll -reference:QRGS.dll $<

QRGS_DIR = ~/PPNM/homework/01.lineq/B

QRGS.dll: $(QRGS_DIR)/QRGS.cs matrix.dll
	mcs -target:library -reference:matrix.dll -out:./$@ $<

MATLIB_PATH = ../../../matlib

matrix.dll: $(MATLIB_PATH)/vector.cs $(MATLIB_PATH)/matrix.cs
	mcs -target:library -out:$@ $^

clean:
	rm -f *.exe *.dll *.txt