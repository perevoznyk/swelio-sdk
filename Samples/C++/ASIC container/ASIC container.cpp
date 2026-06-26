// ASIC container.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <cstdlib>
#include <iostream>
#include "swelio.h"
#include <string.h>
#include <stdio.h>
#include <string>



wchar_t* convertCharArrayToLPCWSTR(const char* charArray)
{
	wchar_t* wString = new wchar_t[4096];
	MultiByteToWideChar(CP_ACP, 0, charArray, -1, wString, 4096);
	return wString;
}


// Helper to trim newline characters
void TrimNewline(char* str)
{
	if (!str) return;

	size_t len = strlen(str);
	while (len > 0 && (str[len - 1] == '\n' || str[len - 1] == '\r'))
	{
		str[len - 1] = '\0';
		len--;
	}
}

int ProcessFile(LPVOID ctx, const char* inputFile)
{
	FILE* file = nullptr;
	errno_t err = fopen_s(&file, inputFile, "r");
	if (err != 0 || !file)
	{
		perror("Failed to open input file");
		return -1;
	}


	size_t capacity = 0;
	ptrdiff_t  length;

	char buffer[4096];

	while (fgets(buffer, sizeof(buffer), file))
	{
		TrimNewline(buffer);

		if (buffer[0] == '\0')
			continue;


		// Call your function
		AddFileToContainer(ctx, buffer);
	}


	
	fclose(file);

	return 0;
}

int main(int argc, char* argv[])
{
	LPWSTR containerName = nullptr;
	LPVOID ctx = InitializeContainer();

	// argc is 1 + number of arguments passed (argv[0] is the program name)
	if (argc > 2) {
		LPWSTR certificate = convertCharArrayToLPCWSTR(argv[1]);
		LPWSTR password = convertCharArrayToLPCWSTR(argv[2]);
		containerName = convertCharArrayToLPCWSTR(argv[3]);
		if (!ContainerCertificate(ctx, certificate, password)) {
			std::cout << "Failed to set container certificate." << std::endl;
		}
		delete certificate;
		delete password;

	}
	else {
		std::cout << "No arguments were passed." << std::endl;
		std::cout << "Usage: <program> <certificate> <password> <container_name>" << std::endl;
	}

	ProcessFile(ctx, "input.txt");
	
	SaveContainer(ctx, containerName);

	
	FreeContainer(ctx);
	delete containerName;
	return 0;
}

