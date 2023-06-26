all: Out.txt

Out.txt: main.exe
	mono $< > $@

main.exe: main.cs qnewton.dll vector.dll
	mcs -target:exe -reference:qnewton.dll -reference:vector.dll $<

qnewton.dll: qnewton.cs vector.dll QRGS.dll
	mcs -target:library -reference:vector.dll -reference:QRGS.dll $<

QRGS_PATH = ../../01.lineq/B

QRGS.dll: $(QRGS_PATH)/QRGS.cs vector.dll
	mcs -target:library -reference:vector.dll -out:./$@ $<

MATLIB_PATH = ../../../matlib

vector.dll: $(MATLIB_PATH)/vector.cs $(MATLIB_PATH)/matrix.cs
	mcs -target:library -out:./$@ $<

clean:
	rm -f *.exe *.dll *.txt

