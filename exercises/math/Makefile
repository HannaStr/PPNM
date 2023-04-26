Out.txt : math.exe
	mono math.exe > Out.txt
#redirect output of the program to an output file

sfuns.dll : sfuns.cs
	mcs -target:library -out:sfuns.dll sfuns.cs
#complie piece of source code into a library

math.exe : math.cs sfuns.dll
	mcs -target:exe -out:math.exe -reference:sfuns.dll math.cs
#link library to  math.cs

clean:
	rm -f Out.txt sfuns.dll math.exe 


