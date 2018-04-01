// EncryptDecryptFile.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <windows.h>
#include "FileOperations.h"
#include "Encryption.h"

int _tmain(int argc, _TCHAR* argv[])
{
	if (FileExists(L"readme.txt"))
	{
		FileDelete(L"readme.txt");
	}

	HANDLE h = FileCreateRewrite(L"readme.txt");
	FileWrite(h, L"This is unprotected clean text");
	FileClose(h);

	EncryptFileAES(L"readme.txt", L"readme.enc", L"password");
	DecryptFileAES(L"readme.enc", L"readme.txt", L"password");

	return 0;
}

