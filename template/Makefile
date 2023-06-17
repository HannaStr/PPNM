Out.txt : main.exe
	mono $< > $@

main.exe: main.cs matrix.dll NAME.dll
	mcs -target:exe -reference:matrix.dll -reference:NAME.dll $<

NAME.dll: NAME.cs matrix.dll
	mcs -target:library -reference:matrix.dll $<

LIBPATH = ../../../matlib/vector							#must be changed for my repository

matrix.dll : $(LIBPATH)/vector.cs $(LIBPATH)/matrix.cs
	mcs -target:library -out:$@ $^

clean:
	rm -f *.exe *.dll *.txt


# < - only first after : compiles
# ^ - all compiled