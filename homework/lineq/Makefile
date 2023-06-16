Out.txt : main.exe			
	mono $< > $@		

main.exe : main.cs matrix.dll QRGS.dll
	mcs -target:exe -reference: matrix.dll -reference: QRGS.dll $<

QRGS.dll: QRGS.cs matrix.dll
	mcs -target: library -reference: matrix.dll $<

matrix.dll: ../vector.cs ../matrix.cs
	mcs -target:library -out: $@ $^

clean: 
	rm -f *.exe *.dll *.txt

# < - only first after : compiles
# ^ - all compiled