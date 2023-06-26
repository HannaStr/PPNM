all: Out.txt

#plot.svg: plot.gpi Out.txt
#	gnuplot $<

Out.txt: main.exe
	mono $< > $@

main.exe: main.cs neuNet.dll vector.dll
	mcs -target:exe -reference:neuNet.dll -reference:vector.dll $<

neuNet.dll: neuNet.cs vector.dll multimin.dll
	mcs -target:library -reference:vector.dll -reference:multimin.dll $<

multimin.dll: ../../09.multimin/A/qnewton.cs vector.dll QRGS.dll
	mcs -target:library -reference:vector.dll -reference:QRGS.dll -out:./$@ $<

QRGS_PATH = ../../01.lineq/B

QRGS.dll: $(QRGS_PATH)/QRGS.cs vector.dll
	mcs -target:library -reference:vector.dll -out:./$@ $<

MATLIB_DIR = ../../../matlib

vector.dll: $(MATLIB_DIR)/vector.cs $(MATLIB_DIR)/matrix.cs
	mcs -target:library -out:./$@ $^

clean:
	rm -f *.exe *.dll *.txt 
#*.svg
