#define _CRT_SECURE_NO_WARNINGS
#include "HashMap.h"

#define MAX_LENGTH 256

#define _if 1
#define _ifdef 2
#define _ifndef 3
#define _else 4
#define _elif 5
#define _endif 6
#define _define 7
#define _undef 8
#define _include 9

#define writeToFile 1
#define writeToStdout 0

hashMap defV;
char incF[20][60];
char *inputFile;
char *outputFile;


//wc word counter
int incC;
int mLD;//multiLineDefine
char mLS[30];//multiLineSymbol
char mLM[30];//multiLineMapping
int canWrite = 1;
int outputType = writeToStdout;
int endDEFINE;
FILE *output;

int conditionAnalizer(char words[][30], int wC);
int isDirective(char *word);

int breakInWords(char *line, char words[20][30]);
int textAnalizer(char words[][30], int wC);

void write(char words[][30], int wC);
int inputFromFile(char *fileName);
void inputFromStdin(void);

int main(int argc, char **argv)
{
	int i;
	int s;
	int size;

	initHashMap(&defV);
	strcpy(incF[incC++], "_test/inputs/");
	strcpy(incF[incC++], "./");
	for (i = 1; i < argc; i++) {
		if (argv[i][0] == '-') {
			size = strlen(argv[i]);
			switch (argv[i][1]) {
			case 'D':
			{
				char *symbol = NULL;
				char *mapping = NULL;

				if (size > 2) {
					symbol = strtok(argv[i] + 2, "=");
					mapping = strtok(NULL, "\n\0");
				} else {
					symbol = strtok(argv[i + 1], "=");
					mapping = strtok(NULL, "\n\0");
					i = i + 1;
				}
				if (mapping == NULL)
					mapping = "";
				insertKeyValue(&defV, symbol, mapping);
				break;
			}
			case 'o':
				if (size > 2)
					outputFile = argv[i] + 2;
				else {
					outputFile = argv[i + 1];
					i = i + 1;
				}
				break;
			case 'I':
				if (size > 2)
					strcpy(incF[incC++], argv[i] + 2);
				else {
					strcpy(incF[incC++], argv[i + 1]);
					i = i + 1;
				}
				s = strlen(incF[incC - 1]);
				if (incF[incC - 1][s - 1] == '\n')
					incF[incC - 1][s - 1] = '/';
				if (incF[incC - 1][s - 1] != '/')
					strcat(incF[incC - 1], "/");
				break;
			default:
				return 12;
			}
		} else {
			if (inputFile == NULL)
				inputFile = argv[i];
			else
				if (outputFile == NULL)
					outputFile = argv[i];
				else
					return 12;
		}
	}
	if (outputFile) {
		outputType = writeToFile;
		output = fopen(outputFile, "w");
	}
	if (inputFile == NULL)
		inputFromStdin();
	else
		if (inputFromFile(inputFile) == 12)
			return 12;
	if (outputFile)
		fclose(output);

	return 0;
}

void write(char words[][30], int wC)
{
	int i = 0;

	for (; i <= wC; i++) {
		char *x = NULL;
		x = getValue(defV, words[i]);
		switch (outputType) {
		case writeToFile:
			if (x != NULL)
				fprintf(output, "%s", x);
			else
				fprintf(output, "%s", words[i]);
			break;
		case writeToStdout:
			if (x != NULL)
				printf("%s", x);
			else
				printf("%s", words[i]);
			break;
		}
	}
}
int conditionAnalizer(char words[][30], int wC)
{
	char *x = NULL;
	char *y = NULL;
	int value;
	char *r;

	r = words[wC - 3];
	if (strcmp(r, "#if") == 0 || strcmp(r, "#elif") == 0) {
		x = getValue(defV,
			words[wC - 1]);
		if (x == NULL)
			x = words[wC - 1];
		switch (strcmp(x, "0")) {
		case 0:
			return 0;
		case 1:
			return 1;
		case -1:
			return -1;
		}
	}
	x = getValue(defV, words[wC - 3]);
	if (x == NULL)
		x = words[wC - 3];
	y = getValue(defV, words[wC - 1]);
	if (y == NULL)
		y = words[wC - 1];
	value = strcmp(x, y);
	if (strcmp(words[wC - 2], " > ") == 0 && value > 0)
		return 1;
	if (strcmp(words[wC - 2], " < ") == 0 && value < 0)
		return 1;
	if (strcmp(words[wC - 2], " == ") == 0 && value == 0)
		return 1;
	if (strcmp(words[wC - 2], " != ") == 0 && value != 0)
		return 1;
	return 0;
}
int isDirective(char *word)
{
	if (strcmp(word, "#if") == 0)
		return _if;
	if (strcmp(word, "#ifdef") == 0)
		return _ifdef;
	if (strcmp(word, "#ifndef") == 0)
		return _ifndef;
	if (strcmp(word, "#else") == 0)
		return _else;
	if (strcmp(word, "#endif") == 0)
		return _endif;
	if (strcmp(word, "#elif") == 0)
		return _elif;
	if (strcmp(word, "#define") == 0)
		return _define;
	if (strcmp(word, "#undef") == 0)
		return _undef;
	if (strcmp(word, "#include") == 0)
		return _include;
	return 0;
}
int breakInWords(char *line, char words[20][30])
{
	int wC = 0;
	int size = strlen(line);
	int character = 0;
	int newWord = 0;

	while (size > character) {
		if (line[character] == '\0')
			break;
		while (strchr("\t []{}<>=*/%!&|^.,:;()\\", line[character])) {
			if (size == character)
				break;
			if (newWord == 0 && character != 0)
				wC++;
			strncat(words[wC], &line[character], 1);
			character++;
			newWord++;
		}
		if (line[character] == '\r') {
			strncat(words[++wC], &line[character], 1);
			strncat(words[wC], &line[character + 1], 1);
			break;
		}
		if (line[character] == '\n' && size == (character + 1)) {
			strncat(words[++wC], &line[character], 1);
			break;
		}
		if (newWord != 0)
			wC++;
		newWord = 0;
		strncat(words[wC], &line[character], 1);
		character++;
	}
	return wC;
}
int inputFromFile(char *fileName)
{
	FILE *input = fopen(fileName, "r");
	int i;
	int wC;
	int isDirective;

	if (input == NULL)
		return 12;

	while (!feof(input)) {
		char words[20][30];
		char line[MAX_LENGTH];

		for (i = 0; i < 20; i++)
			strcpy(words[i], "");
		fgets(line, MAX_LENGTH, input);
		wC = breakInWords(line, words);
		memset(&line, 0, sizeof(line));
		isDirective = textAnalizer(words, wC);

		if (isDirective == 12)
			return 12;
		if (isDirective && canWrite == 1)
			write(words, wC);

	}
	if (strcmp(fileName, "temp") == 0)
		remove("temp");
	fclose(input);
	return 0;
}
void inputFromStdin(void)
{
	FILE *temp = fopen("temp", "wb");

	while (!feof(stdin)) {
		char line[MAX_LENGTH];

		memset(&line, 0, sizeof(line));
		fgets(line, MAX_LENGTH, stdin);
		fputs(line, temp);
	}
	fclose(temp);
	inputFromFile("temp");
}
int textAnalizer(char words[][30], int wC)
{
	char *v;
	char *temp;
	int value;
	int i;
	int j;

	for (i = 0; i < wC; i++) {
		switch (isDirective(words[i])) {
		case _if:
			if (!conditionAnalizer(words, wC))
				canWrite = 0;
			else
				canWrite = 1;
			return 0;
		case _ifdef:
			if (getValue(defV, words[wC - 1]))
				canWrite = 1;
			else
				canWrite = 0;
			return 0;
		case _ifndef:
			if (getValue(defV, words[wC - 1]))
				canWrite = 0;
			else
				canWrite = 1;
			return 0;
		case _elif:
			if (canWrite)
				return 0;
			if (conditionAnalizer(words, wC))
				canWrite = 1;
			else
				canWrite = 0;
			return 0;
		case _else:
			if (canWrite)
				canWrite = 0;
			else
				canWrite = 1;
			return 0;
		case _endif:
			canWrite = 1;
			return 0;
		case _define:
			if (canWrite == 0)
				break;
			v = words[wC - 1];
			if (strcmp(v, " \\") == 0 || strcmp(v, "\\") == 0) {
				mLD = 1;
				strcpy(mLS, words[wC - 4]);
				strcpy(mLM, words[wC - 2]);
				endDEFINE = 1;
				break;
			}
			for (j = 4; j < wC; j++) {
				temp = getValue(defV, words[j]);

				if (temp != NULL)
					strcpy(words[j], temp);
			}
			for (j = 5; j < wC; j++)
				strcat(words[i + 4], words[j]);
			insertKeyValue(&defV, words[i + 2], words[i + 4]);
			endDEFINE = 1;
			return 0;
		case _undef:
			removeKey(&defV, words[i + 2]);
			return 0;
		case _include:
		{
			char includedFile[40];
			char search[50];

			strcpy(includedFile, words[2] + 1);
			for (i = 3; i < wC - 2; i++)
				strcat(includedFile, words[i]);
			strcat(includedFile, ".h");

			for (i = 0; i < incC; i++) {
				strcpy(search, incF[i]);
				strcat(search, includedFile);
				value = inputFromFile(search);

				if (value == 12 && i == incC - 1)
					return 12;
				if (value == 0) {
					endDEFINE = 1;
					return 0;
				}
				memset(&search, 0, sizeof(search));
			}
			return 0;
		}
		default:
			break;
		}

		if (strcmp(words[wC], "\n") == 0 && endDEFINE == 1) {
			endDEFINE = 0;
			return 0;
		}
		if (mLD == 1) {
			v = words[wC - 1];
			if (strcmp(v, " \\") == 0 || strcmp(v, "\\") == 0) {
				strcat(mLM, " ");
				for (i = wC - 4; i < wC - 1; i++)
					strcat(mLM, words[i]);
				return 0;
			}
			strcat(mLM, " ");
			for (i = wC - 3; i < wC; i++)
				strcat(mLM, words[i]);
			mLD = 0;
			insertKeyValue(&defV, mLS, mLM);
			return 0;
		}
	}
	return 1;
}
