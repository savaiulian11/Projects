CC = cl
CFLAGS =/nologo /MD

all: build

build: SO_FILE.dll

SO_FILE.dll: SO_FILE.obj
	link /dll /out:$@ /implib:SO_FILE.lib SO_FILE.obj

SO_FILE.obj: SO_FILE.c SO_FILE.h
	$(CC) /c SO_FILE.c /Fo$@
	
.IGNORE:
clean:
	del /Q /S /F *.obj *.lib *.dll *.exp
