Out.txt: main.exe			
	mono $< > $@		

main.exe: main.cs matrix.dll QRGS.dll
	mcs -target:exe -reference:matrix.dll -reference:QRGS.dll $<

QRGS.dll: QRGS.cs matrix.dll
	mcs -target:library -reference:matrix.dll $<

MATLIB_PATH = ../../../matlib

matrix.dll: $(MATLIB_PATH)/vector.cs $(MATLIB_PATH)/matrix.cs
	mcs -target:library -out:$@ $^

clean: 
	rm -f *.exe *.dll *.txt