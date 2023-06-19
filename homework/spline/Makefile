all: Plot.svg Out.txt 

Out.txt : main.exe
	mono $< > $@

Plot.svg : plot.gpi data.data
	gnuplot $<

data.data : data.exe
	mono $< > $@ 

data.exe: data.cs spline.dll
	mcs -target:exe -reference:spline.dll $<

main.exe: main.cs spline.dll
	mcs -target:exe -reference:spline.dll $<

spline.dll: spline.cs
	mcs -target:library $<

clean:
	rm -f *.exe *.dll *.txt