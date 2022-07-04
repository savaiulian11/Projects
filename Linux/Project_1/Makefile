CC = cl
CFLAGS = /W3 /nologo /EHsc /Za /MD 

build: so-cpp.exe

so-cpp.exe: so-cpp.obj HashMap.obj
	$(CC) $(CFLAGS) /Fe$@ $**

so-cpp.obj: so-cpp.c
	$(CC) $(CFLAGS) /Fe$@ /c $**

HashMap.obj: HashMap.c
	$(CC) $(CFLAGS) /Fe$@ /c $**

.IGNORE:
clean:
	del /Q /S /F *.obj so-cpp.exe