#define _CRT_SECURE_NO_WARNINGS
#include "HashMap.h"

int hash(const char *str)
{
	int sum = 0;

	for (; *str != '\0'; str++) {
		sum += *str;
		sum %= M;
	}
	return sum % M;
}

void insertNodeHeadOfList(listNode **listStart,
	char *symbol,
	char *mapping)
{
	listNode *node = (listNode *)malloc(sizeof(listNode));

	if (node == NULL) {
		printf("ERROR: CAN NOT ALLOCATE RAM\n");
		return;
	}
	node->next = *listStart;
	*listStart = node;
	strcpy(node->symbol, symbol);
	strcpy(node->mapping, mapping);
}

void removeNodeHeadOfList(listNode **listStart)
{
	listNode *aux;

	if (*listStart == NULL)
		return;
	aux = (*listStart);
	*listStart = (*listStart)->next;
	free(aux);
}

listNode *getNode(listNode *listnode, int poz)
{
	int i;

	if (listnode == NULL)
		return NULL;
	for (i = 0; i < poz; i++) {
		if (listnode->next == NULL)
			break;
		listnode = listnode->next;
	}
	return listnode;
}

void removeNodeFromList(listNode **listStart, int poz)
{
	listNode *aux;

	if (poz == 0) {
		removeNodeHeadOfList(listStart);
		return;
	}
	aux = getNode(*listStart, poz - 1);

	if (aux->next != NULL) {
		listNode *aux1 = aux->next;

		aux->next = aux->next->next;
		free(aux1);
	} else {
		listNode *aux1 = getNode(*listStart, poz - 2);

		aux->next = NULL;
		free(aux1);
	}
}

void insertKeyValue(hashMap *HM, char *symbol, char *mapping)
{
	int j = hash(symbol);

	HM->numElements++;
	insertNodeHeadOfList(&HM->buckets[j], symbol, mapping);
}

char *getValue(hashMap HM, const char *symbol)
{
	int j = hash(symbol);

	while (HM.buckets[j] != NULL) {
		if (strcmp(HM.buckets[j]->symbol, symbol) == 0)
			return HM.buckets[j]->mapping;
		HM.buckets[j] = HM.buckets[j]->next;
	}
	return NULL;
}

void removeKey(hashMap *HM, const char *symbol)
{
	int j = hash(symbol);
	listNode *list = HM->buckets[j];
	int poz = 0;
	int flag = 0;

	for (; list; list = list->next) {
		poz++;
		if (strcmp(list->symbol, symbol) == 0) {
			flag = 1;
			break;
		}
	}
	if (flag != 0)
		removeNodeFromList(&HM->buckets[j], poz - 1);
}

void initHashMap(hashMap *HM)
{
	int i;

	HM->numElements = 0;
	for (i = 0; i < M; i++)
		HM->buckets[i] = NULL;
}
