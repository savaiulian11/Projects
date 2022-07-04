/*
 * Loader Implementation
 *
 * 2018, Operating Systems
 */

#include <signal.h>
#include <stdio.h>
#include <fcntl.h>
#include <stdlib.h>
#include <sys/mman.h>
#include <unistd.h>
#include <string.h>

#include "exec_parser.h"

#define MAX_PAGE_NUMBER 200

int fileDescriptor;
static so_exec_t *exec;
struct sigaction old_action;
size_t pageSize;

typedef struct mappedPages{
	void *pageAddress[MAX_PAGE_NUMBER];
	int count;
} Page_;

Page_ pages;

void copyData(so_seg_t *segment, size_t segmentOffset, void *newPage)
{
	char *buffer = malloc(sizeof(char)*pageSize);

	lseek(fileDescriptor, segment->offset + segmentOffset, SEEK_SET);
	if (segmentOffset > segment->file_size)
		memset(newPage, 0, pageSize);
	else {
		size_t totalBytesRead = 0, bytesRead = 0;

		if (segmentOffset + pageSize <= segment->file_size) {
			while (1) {
				bytesRead = read(fileDescriptor,
					buffer + totalBytesRead,
					pageSize - totalBytesRead);
				if (bytesRead <= 0)
					break;
				totalBytesRead += bytesRead;
			}
		} else {
			size_t offsetToPageSize =
				segment->file_size - segmentOffset;
//aliniere la dimensiunea fisierului in cazul iesirii din zona alocata

			while (1) {
				bytesRead = read(fileDescriptor,
					buffer + totalBytesRead,
					offsetToPageSize - totalBytesRead);
				if (bytesRead <= 0)
					break;
				totalBytesRead += bytesRead;
			}
			memset(buffer + offsetToPageSize,
				0, pageSize - offsetToPageSize);
		}
		memcpy(newPage, buffer, pageSize);
		free(buffer);
	}
}

static void segv_handler(int signum, siginfo_t *info, void *context)
{
	int i;
	so_seg_t *segment;
	size_t pageOffset;
	void *pageAddress;
	long segmentOffset;
	//offset segment fata de locul unde
	//s a provocat eroarea (<0 am trecut pe o pagina cu adresa superioara)

	for (i = 0; i < exec->segments_no; i++) {
		segmentOffset = (char *)info->si_addr -
						(char *)exec->segments[i].vaddr;
		if (segmentOffset <= exec->segments[i].mem_size)
			if (segmentOffset >= 0) {
				segment = &(exec->segments[i]);
				break;
			}
	}

	if (segment == NULL)
		old_action.sa_sigaction(signum, info, context);

	pageOffset = segmentOffset%pageSize;
	segmentOffset -= pageOffset;
	//offsetul poate fi mai mare decat dimensiunea paginii,
	//asa ca acesta se aliniaza la dimensiunea paginii
	pageAddress = (void *)segment->vaddr + segmentOffset;

	for (i = 0; i < pages.count; i++)
		if (pageAddress == pages.pageAddress[i])
			old_action.sa_sigaction(signum, info, context);

	void *newPage = mmap(pageAddress,
					pageSize,
					PERM_R | PERM_W,
					MAP_FIXED | MAP_SHARED | MAP_ANONYMOUS,
					-1,
					0);
	pages.pageAddress[pages.count] = newPage;
	pages.count++;
	copyData(segment, segmentOffset, newPage);
	mprotect(pageAddress, getpagesize(), segment->perm);
}

int so_init_loader(void)
{
	/* TODO: initialize on-demand loader */
	printf("\nAici0\n");
	struct sigaction action;
	int rc;

	action.sa_sigaction = segv_handler;
	sigemptyset(&action.sa_mask);
	sigaddset(&action.sa_mask, SIGSEGV);
	action.sa_flags = SA_SIGINFO;

	rc = sigaction(SIGSEGV, &action, &old_action);
	if (rc == -1)
		exit(EXIT_FAILURE);
	return -1;
}

int so_execute(char *path, char *argv[])
{
	pages.count = 0;
	fileDescriptor = open(path, O_RDONLY);
	pageSize = getpagesize();

	exec = so_parse_exec(path);
	if (!exec)
		return -1;

	so_start_exec(exec, argv);

	return -1;
}
