all: Out.txt

Out.txt: main.exe
	mono $< > $@

main.exe: main.cs roots.dll vector.dll
	mcs -target:exe -reference:roots.dll -reference:vector.dll $<

roots.dll: roots.cs vector.dll QRGS.dll
	mcs -target:library -reference:vector.dll -reference:QRGS.dll $<

QRGS_PATH = ../../01.lineq/B

QRGS.dll: $(QRGS_PATH)/QRGS.cs vector.dll
	mcs -target:library -reference:vector.dll -out:./$@ $<

MATLIB_PATH = ../../../matlib

vector.dll: $(MATLIB_PATH)/vector.cs $(MATLIB_PATH)/matrix.cs
	mcs -target:library -out:$@ $^

clean:
	rm -f *.exe *.dll *.txt