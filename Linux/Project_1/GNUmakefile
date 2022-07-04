CC = gcc

.PHONY: build clean

build: so-cpp

so-cpp: so-cpp.o HashMap.o
	gcc -Wall so-cpp.c HashMap.c -o so-cpp -I.

so-cpp.o: so-cpp.c
	gcc -Wall -c so-cpp.c -I.

HashMap.o: HashMap.c
	gcc -Wall -c HashMap.c -I.

clean:
	-rm -f *.o *~ so-cpp 

