// ASIC container.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <cstdlib>
#include <crtdbg.h>
#include <iostream>
#include "swelio.h"
#include <tchar.h>

wchar_t* convertCharArrayToLPCWSTR(const char* charArray)
{
	wchar_t* wString = new wchar_t[4096];
	MultiByteToWideChar(CP_ACP, 0, charArray, -1, wString, 4096);
	return wString;
}

int main(int argc, char* argv[])
{
	LPVOID ctx = InitializeContainer();

	// argc is 1 + number of arguments passed (argv[0] is the program name)
	if (argc > 2) {
		LPWSTR certificate = convertCharArrayToLPCWSTR(argv[1]);
		LPWSTR password = convertCharArrayToLPCWSTR(argv[2]);
		ContainerCertificate(ctx, certificate, password);
		delete certificate;
		delete password;
	}
	else {
		std::cout << "No arguments were passed." << std::endl;
	}


	//ContainerPickCertificate(ctx);
	//ContainerEidCertificate(ctx, 0);

	AddFileToContainer(ctx, (LPSTR)"test1.pdf");
	AddFileToContainer(ctx, (LPSTR)"test2.pdf");
	AddFileToContainer(ctx, (LPSTR)"test1.docx");

	SaveContainer(ctx, (LPWSTR)L"test2.asice");

	//VerifyContainer(ctx, (LPWSTR)L"test2.asice");
	FreeContainer(ctx);


	return 0;
}

