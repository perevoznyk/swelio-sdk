// FileOperationsDemo.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <windows.h>
#include "FileOperations.h"

int _tmain(int argc, _TCHAR* argv[])
{
	CreateUnicodeFile(L"readme.txt");
	if (FileExists(L"readme.txt"))
	{
		if (IsUnicodeFile(L"readme.txt"))
		{
			ClearFileAttributes(L"readme.txt");
			ShellCopyFile(L"readme.txt", L"readme.doc");
			DeleteToRecycleBin(L"readme.txt", FALSE);
		}
	}

	if (FileGetSize(L"readme.doc") == 2)
	{
		if (FileExtensionIs(L"readme.doc", L".doc"))
		{
			FileRename(L"readme.doc", L"readme.txt");
			FileDelete(L"readme.txt");
		}
	}

	return 0;
}

