// ASIC container.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

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
}

