all: Out.txt #erf.svg

#erf.svg: erf.gpi Out.txt
#	gnuplot $<

Out.txt: main.exe
	mono $< >$@

main.exe: main.cs rai.dll
	mcs -target:exe -reference:rai.dll $<

rai.dll: rai.cs
	mcs -target:library $<

clean:
	rm -f *.exe *.dll *.txt