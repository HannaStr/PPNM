Out.txt : main.exe			#target : prerequisites
	mono main.exe > Out.txt			#recipe

main.exe : main.cs
	mcs main.cs

clean: 
	rm -f Out.txt main.exe
