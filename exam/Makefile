all: Out.txt erf.svg erf_zoom.svg

erf.svg: erf.gpi erf.data
	gnuplot $<

erf_zoom.svg: erf_zoom.gpi erf.data
	gnuplot $<

erf.data: erf.exe
	mono $< > $@

erf.exe: erf.cs ari.dll
	mcs -target:exe -reference:ari.dll $<

Out.txt: main.exe
	mono $< >$@

main.exe: main.cs ari.dll
	mcs -target:exe -reference:ari.dll $<

ari.dll: ari.cs
	mcs -target:library $<

clean:
	rm -f *.exe *.dll *.txt