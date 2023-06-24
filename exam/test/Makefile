all: Out.txt #erf.svg

#erf.svg: erf.gpi Out.txt
#	gnuplot $<

Out.txt: main.exe
	mono $< >$@

main.exe: main.cs ari.dll
	mcs -target:exe -reference:ari.dll $<

ari.dll: ari.cs
	mcs -target:library $<

clean:
	rm -f *.exe *.dll *.txt