all: Out.txt

Out.txt: main.exe
	mono $< > $@

main.exe: main.cs roots.dll vector.dll
	mcs -target:exe -reference:roots.dll -reference:vector.dll $<

roots.dll: roots.cs vector.dll QRGS.dll
	mcs -target:library -reference:vector.dll -reference:QRGS.dll $<

MATLIB_PATH = ../../lineq