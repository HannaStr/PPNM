all: Out.txt

Out.txt: main.exe
	mono $< > $@

main.exe: main.cs qnewton.dll matrix.dll
	mcs -target:exe -reference:qnewton.dll -reference:matrix.dll $<

qnewton.dll: qnewton.cs matrix.dll QRGS.dll
	mcs -target:library -reference:matrix.dll -reference:QRGS.dll $<

QRGS_DIR = ~/PPNM/homework/01.lineq/B

QRGS.dll: $(QRGS_DIR)/QRGS.cs matrix.dll
	mcs -target:library -reference:matrix.dll -out:./$@ $<

MATLIB_PATH = ../../../matlib

matrix.dll: $(MATLIB_PATH)/vector.cs $(MATLIB_PATH)/matrix.cs
	mcs -target:library -out:$@ $^

clean:
	rm -f *.exe *.dll *.txt

