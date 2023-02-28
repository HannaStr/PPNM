Out.txt : hello.exe
	mono hello.exe > Out.txt

hello.exe : hello.cs
	mcs hello.cs -out:hello.exe -target:exe

clean:
	rm --force Out.txt hello.exe
