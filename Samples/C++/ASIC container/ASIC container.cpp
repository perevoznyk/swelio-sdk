// ASIC container.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include "swelio.h"

int main()
{
	LPVOID ctx = InitializeContainer();

	ContainerCertificate(ctx, (LPWSTR)L"dri.products.pfx", (LPWSTR)L"delphi");
	//ContainerPickCertificate(ctx);
	//ContainerEidCertificate(ctx, 0);

	AddFileToContainer(ctx, (LPSTR)"test1.pdf");
	AddFileToContainer(ctx, (LPSTR)"test2.pdf");
	AddFileToContainer(ctx, (LPSTR)"test1.docx");

	SaveContainer(ctx, (LPWSTR)L"test2.asice");
	FreeContainer(ctx);
}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
