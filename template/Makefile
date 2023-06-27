all: Out.txt

Out.txt : main.exe
	mono $< > $@

main.exe: main.cs matrix/vector.dll NAME.dll
	mcs -target:exe -reference:matrix/vector.dll -reference:NAME.dll $<

NAME.dll: NAME.cs matrix/vector.dll QRGS.dll
	mcs -target:library -reference:matrix/vector.dll -reference: QRGS.dll $<

QRGS_PATH = ../../01.lineq/B

QRGS.dll: $(QRGS_PATH)/QRGS.cs matrix/vector.dll
	mcs -target:library -reference:matrix/vector.dll -out:./$@ $<

MATLIB_PATH = ../../../matlib							

matrix/vector.dll : $(MATLIB_PATH)/vector.cs $(MATLIB_PATH)/matrix.cs
	mcs -target:library -out:$@ $^

clean:
	rm -f *.exe *.dll *.txt


# < - only first after : compiles
# ^ - all compiled