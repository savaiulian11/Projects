#pragma once
 #include <math.h>
 #include <stdio.h>
 #include <stdlib.h>
 #include <string.h>

 #define M 10

typedef struct listNode {
	char symbol[30];
	char mapping[60];
	struct listNode *next;
} listNode;

typedef struct hashMap {
	int numElements;
	struct listNode *buckets[M];
} hashMap;

int hash(const char *str);
void insertNodeHeadOfList(listNode **listStart,
	char *symbol,
	char *mapping);
void removeNodeHeadOfList(listNode **listStart);
listNode *getNode(listNode *listnode, int poz);
void removeNodeFromList(listNode **listStart, int poz);
void insertKeyValue(hashMap *HM, char *symbol, char *mapping);
char *getValue(hashMap HM, const char *symbol);
void removeKey(hashMap *HM, const char *symbol);
void initHashMap(hashMap *HM);
