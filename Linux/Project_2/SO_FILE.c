#include "SO_FILE.h"
//Deschidere
FUNC_DECL_PREFIX SO_FILE* so_fopen(const char* pathname, const char* mode)
{
	SO_FILE* soFile = (SO_FILE*)malloc(sizeof(SO_FILE));

	soFile->fileHandle = INVALID_HANDLE_VALUE;
	soFile->cursor = 0;
	soFile->error = 0;
	soFile->bufferCursor = 0;
	soFile->bufferEnd = 0;
	soFile->lastOperation = -1;
	memset(soFile->buffer, 0, BUFFSIZE);

	if (strcmp(mode, "r") == 0)
		soFile->fileHandle = CreateFile(
			pathname,
			GENERIC_READ,
			FILE_SHARE_READ,
			NULL,
			OPEN_EXISTING,
			FILE_ATTRIBUTE_NORMAL,
			NULL
		);
	if (strcmp(mode, "r+") == 0)
		soFile->fileHandle = CreateFile(
			pathname,
			GENERIC_READ | GENERIC_WRITE,
			FILE_SHARE_READ | FILE_SHARE_WRITE,
			NULL,
			OPEN_EXISTING,
			FILE_ATTRIBUTE_NORMAL,
			NULL
		);
	if (strcmp(mode, "w") == 0)
		soFile->fileHandle = CreateFile(
			pathname,
			GENERIC_WRITE,
			FILE_SHARE_WRITE,
			NULL,
			OPEN_EXISTING | CREATE_NEW | TRUNCATE_EXISTING,
			FILE_ATTRIBUTE_NORMAL,
			NULL
		);
	if (strcmp(mode, "w+") == 0)
		soFile->fileHandle = CreateFile(
			pathname,
			GENERIC_WRITE | GENERIC_READ,
			FILE_SHARE_WRITE | FILE_SHARE_READ,
			NULL,
			OPEN_EXISTING | CREATE_NEW | TRUNCATE_EXISTING,
			FILE_ATTRIBUTE_NORMAL,
			NULL
		);
	if (strcmp(mode, "a") == 0) {
		soFile->fileHandle = CreateFile(
			pathname,
			GENERIC_WRITE,
			FILE_APPEND_DATA | FILE_SHARE_WRITE,
			NULL,
			OPEN_EXISTING | CREATE_NEW,
			FILE_ATTRIBUTE_NORMAL,
			NULL
		);
		so_fseek(soFile, 0, SEEK_END);
	}
	if (strcmp(mode, "a+") == 0) {
		soFile->fileHandle = CreateFile(
			pathname,
			GENERIC_READ | GENERIC_WRITE,
			FILE_APPEND_DATA | FILE_SHARE_READ | FILE_SHARE_WRITE,
			NULL,
			OPEN_EXISTING | CREATE_NEW,
			FILE_ATTRIBUTE_NORMAL,
			NULL
		);
		so_fseek(soFile, 0, SEEK_END);
	}
	if (soFile->fileHandle == INVALID_HANDLE_VALUE) {
		free(soFile);
		return NULL;
	}
	return soFile;
}

FUNC_DECL_PREFIX int so_fclose(SO_FILE *stream)
{
	int fd;

	if (stream == NULL)
		return SO_EOF;
	if (stream->lastOperation == WRITE)
		if (so_fflush(stream) != 0) {
			CloseHandle(stream->fileHandle);
			free(stream);
			return SO_EOF;
		}
	fd = CloseHandle(stream->fileHandle);
	free(stream);
	if (fd == 0)
		return SO_EOF;
	return 0;
}

//Citire si scriere
FUNC_DECL_PREFIX int so_fgetc(SO_FILE *stream)
{
	int bRet = 0;
	DWORD bytesRead;

	if (stream != NULL) {
		stream->lastOperation = READ;
		if (stream->bufferCursor != stream->bufferEnd) {
			stream->cursor++;
			return stream->buffer[stream->bufferCursor++];
		}
		memset(stream->buffer, 0, BUFFSIZE);
		bRet = ReadFile(
			stream->fileHandle,
			stream->buffer,
			BUFFSIZE,
			&bytesRead,
			NULL
		);
		if (bRet == 0) {
			stream->error = 1;
			return SO_EOF;
		}
		stream->bufferCursor = 0;
		stream->cursor++;
		if (bytesRead <= 0) {
			stream->error = 1;
			return SO_EOF;
		}
		stream->bufferEnd = bytesRead;
		return stream->buffer[stream->bufferCursor++];
	}
	return 0;
}

FUNC_DECL_PREFIX int so_fputc(int c, SO_FILE *stream)
{
	if (stream != NULL) {
		stream->lastOperation = WRITE;
		if (stream->bufferCursor == BUFFSIZE)
			so_fflush(stream);
		stream->cursor++;
		stream->buffer[stream->bufferCursor++] = c;
		return c;
	}
	stream->error = 1;
	return SO_EOF;
}

FUNC_DECL_PREFIX size_t so_fread(void *ptr,
	size_t size, size_t nmemb, SO_FILE *stream)
{
	if (stream != NULL) {
		int i = 0;
		char *tmp = ptr;

		while (i < size*nmemb) {
			unsigned char character = so_fgetc(stream);

			if (stream->error == 1)
				break;
			tmp[i++] = character;
		}
		return i / size;
	}
	return SO_EOF;
}
FUNC_DECL_PREFIX size_t so_fwrite(const void *ptr,
	size_t size, size_t nmemb, SO_FILE *stream)
{
	if (stream != NULL) {
		int i = 0;
		const char *tmp = ptr;

		while (i < size*nmemb)
			so_fputc(tmp[i++], stream);
		return i / size;
	}
	return 0;
}
//Pozitionare cursor
FUNC_DECL_PREFIX int so_fseek(SO_FILE *stream, long offset, int whence)
{
	if (stream == NULL)
		return -1;
	switch (stream->lastOperation) {
	case READ:
		stream->bufferCursor = 0;
		break;
	case WRITE:
		so_fflush(stream);
		break;
	}
	long position = SetFilePointer(
		stream->fileHandle,
		offset,
		0,
		whence
	);
	if (position == INVALID_SET_FILE_POINTER)
		return -1;
	if (position >= BUFFSIZE)
		if (stream->lastOperation == WRITE)
			so_fflush(stream);
		else {
			memset(stream->buffer, 0, BUFFSIZE);
			stream->bufferCursor = 0;
			stream->bufferEnd = 0;
		}
	else if (stream->cursor - stream->bufferCursor > position ||
		position == 0) {
		memset(stream->buffer, 0, BUFFSIZE);
		stream->bufferCursor = 0;
		stream->bufferEnd = 0;
	} else
		stream->bufferCursor =
		position - (stream->cursor - stream->bufferCursor);

	switch (whence) {
	case SEEK_SET:
		stream->cursor = offset;
		break;
	case SEEK_CUR:
		stream->cursor += offset;
		break;
	case SEEK_END:
		stream->cursor = position;
		break;
	}
	return 0;
}
FUNC_DECL_PREFIX long so_ftell(SO_FILE *stream)
{
	if (stream == NULL)
		return SO_EOF;
	return stream->cursor;
}
//Buffering
FUNC_DECL_PREFIX int so_fflush(SO_FILE *stream)
{
	int bRet;
	DWORD dwBytesWritten, dwBytesToWrite = sizeof(stream->buffer);

	do {
		bRet = WriteFile(stream->fileHandle,
			&stream->buffer,
			dwBytesToWrite,
			&dwBytesWritten,
			NULL);
		DIE(bRet == FALSE, "WriteFile");

		dwBytesToWrite -= dwBytesWritten;
	} while (dwBytesToWrite);
	memset(stream->buffer, 0, BUFFSIZE);
	stream->bufferCursor = 0;
	stream->bufferEnd = 0;
	return 0;
}
//Alte functii
FUNC_DECL_PREFIX int so_fileno(SO_FILE *stream)
{
	if (stream == NULL)
		return SO_EOF;
	return stream->fileHandle;
}
int so_feof(SO_FILE *stream)
{
	long end;
	long position = SetFilePointer(
		stream->fileHandle,
		0,
		0,
		FILE_END
	);
	SetFilePointer(
		stream->fileHandle,
		so_ftell(stream),
		0,
		FILE_BEGIN
	);
	if (end < so_ftell(stream))
		return 1;
	else
		return 0;
}
int so_ferror(SO_FILE *stream)
{
	return stream->error;
}
//Procese
FUNC_DECL_PREFIX SO_FILE *so_popen(const char *command, const char *type)
{
	return NULL;
}
FUNC_DECL_PREFIX int so_pclose(SO_FILE *stream)
{
	return -1;
}
