// ASIC container.cpp : This file contains the 'main' function. Program execution begins and ends there.
//
#define _CRTDBG_MAP_ALLOC
#include <cstdlib>
#include <crtdbg.h>
#include <iostream>
#include "swelio.h"

int main()
{
	LPVOID ctx = InitializeContainer();

	ContainerCertificate(ctx, (LPWSTR)L"digital-signature.pfx", (LPWSTR)L"password");
	//ContainerPickCertificate(ctx);
	//ContainerEidCertificate(ctx, 0);

	AddFileToContainer(ctx, (LPSTR)"test1.pdf");
	AddFileToContainer(ctx, (LPSTR)"test2.pdf");
	AddFileToContainer(ctx, (LPSTR)"test1.docx");

	SaveContainer(ctx, (LPWSTR)L"test2.asice");
	FreeContainer(ctx);

#ifdef _DEBUG
	// Dump memory leaks at program exit
	_CrtDumpMemoryLeaks();
#endif
	return 0;
}

