//===============================================================================
//= Copyright (c) Serhiy Perevoznyk.  All rights reserved.
//= THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//= OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//= LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//= FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

#pragma once

//
//  IID_PPV_ARG(IType, ppType) 
//      IType is the type of pType
//      ppType is the variable of type IType that will be filled
//
//      RESULTS in:  IID_IType, ppvType
//      will create a compiler error if wrong level of indirection is used.
//
//  macro for QueryInterface and related functions
//  that require a IID and a (void **)
//  this will insure that the cast is safe and appropriate on C++
//
#ifdef __cplusplus
#define IID_PPV_ARG(IType, ppType) IID_##IType, reinterpret_cast<void**>(static_cast<IType**>(ppType))
#else
#define IID_PPV_ARG(IType, ppType) &IID_##IType, (void**)(ppType))
#endif

#ifdef __cplusplus
extern "C" {
#endif


typedef VOID (CALLBACK* FOLDERENUMPROC)(LPWSTR fileName, LPARAM lParam);

//   Summary
//   Creates UNICODE file
//   Parameters
//   fileName :  The name of the file 
void WINAPI CreateUnicodeFileW(LPCWSTR fileName);

//   Summary
//   Checks if the file is UNICODE file
//   Description
//   This function checks the file encoding based on BOM (Byte
//   Order Mark).
//   Parameters
//   fileName :  The name of the file
//   Return Value
//   Returns TRUE if file is stored in UNICODE format, otherwise
//   returns FALSE.                                              
BOOL WINAPI IsUnicodeFileW(LPCWSTR fileName);

//   Summary
//   Deletes file to WIndows Recycle Bin
//   Description
//   Use this function to delete the file to Windows Recycle Bin
//   Parameters
//   fileName :  The name of the file
//   silent :    Do not display a progress dialog box            
void WINAPI DeleteToRecycleBinW(LPWSTR fileName, BOOL silent);

 //  Summary
 //  Copies file to the new location
 //  Description
 //  Copies file to the new location using Windows shell copy
 //  routine
 //  Parameters
 //  oldName :  The source file name
 //  newName :  The destination file name                     
void WINAPI ShellCopyFileW(LPWSTR oldName, LPWSTR newName);

 //  Summary
 //  Retrieves the size of a specified file.
 //  Description
 //  This function determines the size of the file specified by the name of the file
 //  Parameters
 //  fileName :  The name of the file
 //  Return Value
 //  The size of the file in bytes.                             
DWORD WINAPI FileGetSizeW(LPCWSTR fileName);

 //  Summary
 //  Tests whether a specified file exists.
 //  Description
 //  Use this function to check if the file with provided name
 //  exists.
 //  Return Value
 //  FileExists returns TRUE if the file specified by FileName
 //  exists. If the file does not exist, FileExists returns FALSE. 
BOOL WINAPI FileExistsW(LPWSTR fileName);

 //  Summary
 //  Checks the file extension
 //  Description
 //  This function checks if the file has a given extension
 //  Parameters
 //  fileName :  The name of the file
 //  ext :       The file name extension
 //  Return Value
 //  Returns true if the file has a specified extension, otherwise
 //  returns false.                                                
BOOL WINAPI FileExtensionIsW(LPCWSTR fileName, LPCWSTR ext);

 //  Summary
 //  Checks if the file is an image file
 //  Parameters
 //  fileName :  The name of the file
 //  Return Value
 //  Returns TRUE if the file is an image file, otherwise returns
 //  FALSE.                                                       
BOOL WINAPI FileIsImageW(LPCWSTR fileName);

 //  Summary
 //  Deletes a file from disk.
 //  Description
 //  DeleteFile deletes the file named by fileName from the disk.
 //  Parameters
 //  fileName :  The name of the file                             
void WINAPI FileDeleteW(LPWSTR fileName);

 //  Summary
 //  This function sets the file attributes to normal.
 //  Description
 //  This function removed additional file attributes, like
 //  system, read-only and hidden.
 //  Parameters
 //  fileName :  The name of the file                       
void WINAPI ClearFileAttributesW(LPWSTR fileName);

 //  Summary
 //  Creates new or overwrites existing file
 //  Description
 //  This function creates the new file with provided file name if
 //  the file with given name does not exists.
 //  If the file exists, it will be overwritten and the current
 //  content of the file will be lost
 //  Return Value
 //  The result of the function is the handle of the file 
HANDLE WINAPI FileCreateRewriteW(LPCWSTR fileName);

 //  Summary
 //  Concludes input/output (I/O) to a file opened using the
 //  FileCreateRewrite function.
 //  Description
 //  Closes the file handle of the specified file when its not in
 //  use anymore
 //  Parameters
 //  handle :  The handle of the file                             
void WINAPI FileCloseW(HANDLE handle);

 //  Summary
 //  Writes string to the file
 //  Parameters
 //  handle :  The handle of the file
 //  text :    The text to write      
void WINAPI FileWriteW(HANDLE handle, LPWSTR text);

 //  Summary
 //  Writes one character to the file
 //  Parameters
 //  handle :  The handle of the file
 //  text :    The character to write 
void WINAPI FileWriteCharW(HANDLE handle, WCHAR text);

 //  Summary
 //  Writes new line sequence to the file
 //  Parameters
 //  handle :  The handle of the file     
void WINAPI FileWriteNewLineW(HANDLE handle);

 //  Summary
 //  Checks if the file is an animated GIF image file
 //  Parameters
 //  fileName :  The name of the file
 //  Return Value
 //  Returns TRUE if the file is an animated GIF image file,
 //  otherwise returns FALSE.                                
BOOL WINAPI IsAnimatedGIFW(LPWSTR fileName);

 //  Summary
 //  Renames the file
 //  Parameters
 //  oldName :  \File to be renamed
 //  newName :  New name of the file
 //  Return Value
 //  Returns TRUE if the file was successfully renamed, otherwise
 //  returns FALSE                                                
BOOL WINAPI FileRenameW(LPWSTR oldName, LPWSTR newName);

 //  Summary
 //  Replaces environment variable names with values
 //  Description
 //  This function expands environment-variable strings and
 //  replaces them with their defined values in the file name.
 //  Parameters
 //  fileName :  The source file name
 //  fullName :  The expanded file name                        
void WINAPI StripFileNameW(LPCWSTR fileName, LPWSTR fullName);

 //  Summary
 //  The CopyFile function copies an existing file to a new file.
 //  Description
 //  This function makes a copy of the file with the new name or
 //  path.
 //  Parameters
 //  oldName :  The name of the source file
 //  newName :  The name of the destination file
 //  Return Value
 //  The result of the function is TRUE when the file is
 //  successfully copied to the new location, otherwise the result
 //  is FALSE.                                                     
BOOL WINAPI FileCopyW(LPWSTR oldName, LPWSTR newName);

 //  Summary
 //  Gets the full path to the file based on file name
 //  Parameters
 //  fileName :  The name of the file
 //  fullName :  The full path to the file             
BOOL WINAPI FullPathW(LPWSTR fileName, LPWSTR fullName);

 //  Summary
 //  Checks if the file or folder with the given name exists
 //  Parameters
 //  fileName :  The file or folder name
 //  Return Value
 //  Returns TRUE if the file or folder exists, otherwise returns
 //  FALSE.                                                       
BOOL WINAPI FileOrFolderExistsW(LPWSTR fileName);

 //  Summary
 //  Determines whether a specified directory exists.
 //  Description
 //  Call DirectoryExists to determine whether the directory
 //  specified by the Directory parameter exists. If the directory
 //  exists, the function returns True. If the directory does not
 //  exist, the function returns False.
 //  If a full path name is entered, DirectoryExists searches for
 //  the directory along the designated path. Otherwise, the
 //  Directory parameter is interpreted as a relative path name
 //  from the current directory.
 //  Parameters
 //  fileName :  The name of the directory
 //  Return Value
 //  Returns TRUE if the directory exists, otherwise returns FALSE 
BOOL WINAPI DirectoryExistsW(LPWSTR fileName);

 //  Summary
 //  Verifies that a path is a valid directory.
 //  Description
 //  This function verifies if provided value is the name of the
 //  folder
 //  Return Value
 //  Returns TRUE if the path is a valid directory, or FALSE
 //  otherwise. 
BOOL WINAPI IsDirectoryW(LPWSTR folderName);

 //  Summary
 //  Checks if the file is a Windows executable
 //  Parameters
 //  fileName :  The name of the file
 //  Return Value
 //  Returns TRUE if the file is a Windows executable, otherwise
 //  returns FALSE.                                              
BOOL WINAPI FileIsExeW(LPWSTR fileName);

 //  Summary
 //  Checks if the file is a Windows icon (.ico) file
 //  Parameters
 //  fileName :  The name of the file
 //  Return Value
 //  Returns TRUE if the file is a Windows icon (.ico) file,
 //  otherwise returns FALSE.                                
BOOL WINAPI FileIsIconW(LPWSTR fileName);

 //  Summary
 //  Checks if provided string is a valid file name
 //  Description
 //  Checks if provided string is a valid file name and does not
 //  contain any illegal characters
 //  Parameters
 //  fileName :  The name of the file
 //  Return Value
 //  Returns TRUE if provided string is valid file name, otherwise
 //  returns FALSE                                                 
BOOL WINAPI IsValidFileNameW(LPWSTR fileName);

 //  Summary
 //  Checks if provided string is a valid file path
 //  Description
 //  Checks if provided string is a valid file path and does not
 //  contain any illegal characters
 //  Parameters
 //  fileName :  The file path to check
 //  Return Value
 //  Returns TRUE if provided string is valid file path, otherwise
 //  returns FALSE                                                 
BOOL WINAPI IsValidPathNameW(LPWSTR fileName);

 //  Summary
 //  Calculates the number of files in the given folder
 //  Parameters
 //  folderName :  The name of the folder
 //  Return Value
 //  The number of files in the given folder            
int WINAPI  GetFilesCountW(LPWSTR folderName);

 //  Summary
 //  Creates UNICODE file
 //  Parameters
 //  fileName :  The name of the file 
void WINAPI CreateUnicodeFileA(LPCSTR fileName);

 //  Summary
 //  Checks if the file is UNICODE file
 //  Description
 //  This function checks the file encoding based on BOM (Byte
 //  Order Mark).
 //  Parameters
 //  fileName :  The name of the file
 //  Return Value
 //  Returns TRUE if file is stored in UNICODE format, otherwise
 //  returns FALSE.                                              
BOOL WINAPI IsUnicodeFileA(LPCSTR fileName);

 //  Summary
 //  Deletes file to the Windows Recycle Bin
 //  Description
 //  Use this function to delete the file to Windows Recycle Bin
 //  Parameters
 //  fileName :  The name of the file
 //  silent :    Do not display a progress dialog box            
void WINAPI DeleteToRecycleBinA(LPSTR fileName, BOOL silent);

 //  Summary
 //  Copies file to the new location
 //  Description
 //  Copies file to the new location using Windows shell copy
 //  routine
 //  Parameters
 //  oldName :  The source file name
 //  newName :  The destination file name                     
void WINAPI ShellCopyFileA(LPSTR oldName, LPSTR newName);

 //  Summary
 //  Retrieves the size of a specified file.
 //  Description
 //  This function determines the size of the file specified by the file name.
 //  Parameters
 //  fileName :  The name of the file
 //  Return Value
 //  The size of the file in bytes.                             
DWORD WINAPI FileGetSizeA(LPCSTR fileName);

 //  Summary
 //  Tests whether a specified file exists.
 //  Description
 //  Use this function to check if the file with provided name
 //  exists.
 //  Return Value
 //  FileExists returns TRUE if the file specified by FileName
 //  exists. If the file does not exist, FileExists returns FALSE. 
BOOL WINAPI FileExistsA(LPSTR fileName);

 //  Summary
 //  Checks the file extension
 //  Description
 //  This function checks if the file has a given extension
 //  Parameters
 //  fileName :  The name of the file
 //  ext :       The file name extension
 //  Return Value
 //  Returns true if the file has a specified extension, otherwise
 //  returns false.                                                
BOOL WINAPI FileExtensionIsA(LPCSTR fileName, LPCSTR ext);

 //  Summary
 //  Checks if the file is an image file
 //  Parameters
 //  fileName :  The name of the file
 //  Return Value
 //  Returns TRUE if the file is an image file, otherwise returns
 //  FALSE.                                                       
BOOL WINAPI FileIsImageA(LPCSTR fileName);

 //  Summary
 //  Deletes a file from disk.
 //  Description
 //  DeleteFile deletes the file named by fileName from the disk.
 //  Parameters
 //  fileName :  The name of the file                             
void WINAPI FileDeleteA(LPSTR fileName);

 //  Summary
 //  This function sets the file attributes to normal.
 //  Description
 //  This function removed additional file attributes, like
 //  system, read-only and hidden.
 //  Parameters
 //  fileName :  The name of the file                       
void WINAPI ClearFileAttributesA(LPSTR fileName);

 //  Summary
 //  Creates new or overwrites existing file
 //  Description
 //  This function creates the new file with provided file name if
 //  the file with given name does not exists.
 //  If the file exists, it will be overwritten and the current
 //  content of the file will be lost
 //  Return Value
 //  The result of the function is the handle of the file 
HANDLE WINAPI FileCreateRewriteA(LPCSTR fileName);

 //  Summary
 //  Concludes input/output (I/O) to a file opened using the
 //  FileCreateRewrite function.
 //  Description
 //  Closes the file handle of the specified file when its not in
 //  use anymore
 //  Parameters
 //  handle :  The handle of the file                             
void WINAPI FileCloseA(HANDLE handle);

 //  Summary
 //  Writes string to the file
 //  Parameters
 //  handle :  The handle of the file
 //  text :    The text to write      
void WINAPI FileWriteA(HANDLE handle, LPSTR text);

 //  Summary
 //  Writes one character to the file
 //  Parameters
 //  handle :  The handle of the file
 //  text :    The character to write 
void WINAPI FileWriteCharA(HANDLE handle, CHAR text);

 //  Summary
 //  Writes new line sequence to the file
 //  Parameters
 //  handle :  The handle of the file     
void WINAPI FileWriteNewLineA(HANDLE handle);

 //  Summary
 //  Checks if the file is an animated GIF image file
 //  Parameters
 //  fileName :  The name of the file
 //  Return Value
 //  Returns TRUE if the file is an animated GIF image file,
 //  otherwise returns FALSE.                                
BOOL WINAPI IsAnimatedGIFA(LPSTR fileName);

 //  Summary
 //  Renames the file
 //  Parameters
 //  oldName :  \File to be renamed
 //  newName :  New name of the file
 //  Return Value
 //  Returns TRUE if the file was successfully renamed, otherwise
 //  returns FALSE                                                
BOOL WINAPI FileRenameA(LPSTR oldName, LPSTR newName);

 //  Summary
 //  Replaces environment variable names with values
 //  Description
 //  This function expands environment-variable strings and
 //  replaces them with their defined values in the file name.
 //  Parameters
 //  fileName :  The source file name
 //  fullName :  The expanded file name                        
void WINAPI StripFileNameA(LPCSTR fileName, LPSTR fullName);

 //  Summary
 //  The CopyFile function copies an existing file to a new file.
 //  Description
 //  This function makes a copy of the file with the new name or
 //  path.
 //  Parameters
 //  oldName :  The name of the source file
 //  newName :  The name of the destination file
 //  Return Value
 //  The result of the function is TRUE when the file is
 //  successfully copied to the new location, otherwise the result
 //  is FALSE.                                                     
BOOL WINAPI FileCopyA(LPSTR oldName, LPSTR newName);

 //  Summary
 //  Gets the full path to the file based on file name
 //  Parameters
 //  fileName :  The name of the file
 //  fullName :  The full path to the file             
BOOL WINAPI FullPathA(LPSTR fileName, LPSTR fullName);

 //  Summary
 //  Checks if the file or folder with the given name exists
 //  Parameters
 //  fileName :  The file or folder name
 //  Return Value
 //  Returns TRUE if the file or folder exists, otherwise returns
 //  FALSE.                                                       
BOOL WINAPI FileOrFolderExistsA(LPSTR fileName);

 //  Summary
 //  Determines whether a specified directory exists.
 //  Description
 //  Call DirectoryExists to determine whether the directory
 //  specified by the Directory parameter exists. If the directory
 //  exists, the function returns True. If the directory does not
 //  exist, the function returns False.
 //  If a full path name is entered, DirectoryExists searches for
 //  the directory along the designated path. Otherwise, the
 //  Directory parameter is interpreted as a relative path name
 //  from the current directory.
 //  Parameters
 //  fileName :  The name of the directory
 //  Return Value
 //  Returns TRUE if the directory exists, otherwise returns FALSE 
BOOL WINAPI DirectoryExistsA(LPSTR fileName);

 //  Summary
 //  Verifies that a path is a valid directory.
 //  Description
 //  This function verifies if provided value is the name of the
 //  folder
 //  Return Value
 //  Returns TRUE if the path is a valid directory, or FALSE
 //  otherwise. 
BOOL WINAPI IsDirectoryA(LPSTR folderName);

 //  Summary
 //  Checks if the file is a Windows executable
 //  Parameters
 //  fileName :  The name of the file
 //  Return Value
 //  Returns TRUE if the file is a Windows executable, otherwise
 //  returns FALSE.                                              
BOOL WINAPI FileIsExeA(LPSTR fileName);

 //  Summary
 //  Checks if the file is a Windows icon (.ico) file
 //  Parameters
 //  fileName :  The name of the file
 //  Return Value
 //  Returns TRUE if the file is a Windows icon (.ico) file,
 //  otherwise returns FALSE.                                
BOOL WINAPI FileIsIconA(LPSTR fileName);

 //  Summary
 //  Checks if provided string is a valid file name
 //  Description
 //  Checks if provided string is a valid file name and does not
 //  contain any illegal characters
 //  Parameters
 //  fileName :  The name of the file
 //  Return Value
 //  Returns TRUE if provided string is valid file name, otherwise
 //  returns FALSE                                                 
BOOL WINAPI IsValidFileNameA(LPSTR fileName);

 //  Summary
 //  Checks if provided string is a valid file path
 //  Description
 //  Checks if provided string is a valid file path and does not
 //  contain any illegal characters
 //  Parameters
 //  fileName :  The file path to check
 //  Return Value
 //  Returns TRUE if provided string is valid file path, otherwise
 //  returns FALSE                                                 
BOOL WINAPI IsValidPathNameA(LPSTR fileName);

 //  Summary
 //  Calculates the number of files in the given folder
 //  Parameters
 //  folderName :  The name of the folder
 //  Return Value
 //  The number of files in the given folder            
int WINAPI  GetFilesCountA(LPSTR folderName);


 //  Summary
 //  Writes the memory buffer to file
 //  Description
 //  This function stores the content of the memory buffer to the file.
 //  Parameters
 //  fileName :    The name of the file
 //  buffer :      The address of the memory block
 //  bufferSize :  The size of the memory block                   
void WINAPI WriteBufferToFileW(LPWSTR fileName, BYTE* buffer, int bufferSize);

 //  Summary
 //  Writes the memory buffer to file
 //  Description
 //  This function stores the content of the memory buffer to the file.
 //  Parameters
 //  fileName :    The name of the file
 //  buffer :      The address of the memory block
 //  bufferSize :  The size of the memory block                   
void WINAPI WriteBufferToFileA(LPSTR fileName, BYTE* buffer, int bufferSize);

 //  Summary
 //  Reads the content of the file to the memory buffer
 //  Description
 //  Use this function to retrieve the content of the file to the
 //  memory block
 //  Parameters
 //  fileName :    The name of the file
 //  buffer :      The address of the memory block
 //  bufferSize :  The size of the memory block                   
void WINAPI ReadBufferFromFileW(LPWSTR fileName, BYTE* buffer, int bufferSize);

 //  Summary
 //  Reads the content of the file to the memory buffer
 //  Description
 //  Use this function to retrieve the content of the file to the
 //  memory block
 //  Parameters
 //  fileName :    The name of the file
 //  buffer :      The address of the memory block
 //  bufferSize :  The size of the memory block                   
void WINAPI ReadBufferFromFileA(LPSTR fileName, BYTE* buffer, int bufferSize);

 //  Summary
 //  Allocates the buffer in memory
 //  Description
 //  AllocateBuffer allocates a block of the given size on the
 //  heap, and returns the address of this memory.The bytes of the
 //  allocated buffer are not set to zero. To dispose of the
 //  buffer, use DeallocateBuffer function.
 //  Parameters
 //  bufferSize :  The size of the buffer
 //  Return Value
 //  The pointer to the allocated memory block                     
void* WINAPI AllocateBuffer(int bufferSize);

 //  Summary
 //  Deallocates the memory buffer
 //  Description
 //  DeallocateBuffer frees a memory block previously allocated
 //  with AllocateBuffer.
 //  Use this procedure to dispose of a memory block obtained with
 //  AllocateBuffer.
 //  Parameters
 //  buffer :  The pointer to the memory buffer                    
void WINAPI DeallocateBuffer(void* buffer);

 //  Summary
 //  Returns the names of files in a specified directory.
 //  Description
 //  This function enumerates all files in the specified folder which names match the searchMask parameter
 //  and calls the callback function passing the name of the file to it.
 //  Parameters
 //  lpEnumProc : Callback function
 //  folderName : The name of the folder
 //  searchMask : The search string to match against the names of files in path.
 //  lParam : Specifies an application-defined value to be passed to the callback function
void WINAPI GetAllFiles(FOLDERENUMPROC lpEnumProc, LPWSTR folderName, LPWSTR searchMask, LPARAM lParam);

 //  Summary
 //  Checks to see if the file specified by file name is a Microsoft Windows 
 //  shortcut (.Lnk) file (and is neither a file nor a folder). 
 //  Description
 //  This function is used to check if the file with provided file name is a Windows shortcut
 //  or not
 //  Parameters
 //  fileName : The name of the file to check
 //  Return value
 //  Returns TRUE if the file is a Microsoft Windows shortcut,
 //  otherwise returns FALSE
BOOL WINAPI FileIsLink(LPCWSTR fileName);

#ifdef UNICODE
#define CreateUnicodeFile		CreateUnicodeFileW
#define IsUnicodeFile			IsUnicodeFileW
#define DeleteToRecycleBin		DeleteToRecycleBinW
#define ShellCopyFile			ShellCopyFileW
#define FileGetSize				FileGetSizeW
#define FileExists				FileExistsW
#define FileExtensionIs			FileExtensionIsW
#define FileIsImage				FileIsImageW
#define FileDelete				FileDeleteW
#define ClearFileAttributes		ClearFileAttributesW
#define FileCreateRewrite		FileCreateRewriteW
#define FileClose				FileCloseW
#define FileWrite				FileWriteW
#define FileWriteChar			FileWriteCharW
#define FileWriteNewLine		FileWriteNewLineW
#define IsAnimatedGIF			IsAnimatedGIFW
#define FileRename				FileRenameW
#define StripFileName			StripFileNameW
#define FileCopy				FileCopyW
#define FullPath				FullPathW
#define FileOrFolderExists		FileOrFolderExistsW
#define DirectoryExists			DirectoryExistsW
#define IsDirectory				IsDirectoryW
#define FileIsExe				FileIsExeW
#define FileIsIcon				FileIsIconW
#define IsValidFileName			IsValidFileNameW
#define IsValidPathName			IsValidPathNameW
#define GetFilesCount			GetFilesCountW
#define WriteBufferToFile		WriteBufferToFileW
#define ReadBufferFromFile		ReadBufferFromFileW
#else
#define CreateUnicodeFile		CreateUnicodeFileA
#define IsUnicodeFile			IsUnicodeFileA
#define DeleteToRecycleBin		DeleteToRecycleBinA
#define ShellCopyFile			ShellCopyFileA
#define FileGetSize				FileGetSizeA
#define FileExists				FileExistsA
#define FileExtensionIs			FileExtensionIsA
#define FileIsImage				FileIsImageA
#define FileDelete				FileDeleteA
#define ClearFileAttributes		ClearFileAttributesA
#define FileCreateRewrite		FileCreateRewriteA
#define FileClose				FileCloseA
#define FileWrite				FileWriteA
#define FileWriteChar			FileWriteCharA
#define FileWriteNewLine		FileWriteNewLineA
#define IsAnimatedGIF			IsAnimatedGIFA
#define FileRename				FileRenameA
#define StripFileName			StripFileNameA
#define FileCopy				FileCopyA
#define FullPath				FullPathA
#define FileOrFolderExists		FileOrFolderExistsA
#define DirectoryExists			DirectoryExistsA
#define IsDirectory				IsDirectoryA
#define FileIsExe				FileIsExeA
#define FileIsIcon				FileIsIconA
#define IsValidFileName			IsValidFileNameA
#define IsValidPathName			IsValidPathNameA
#define GetFilesCount			GetFilesCountA
#define WriteBufferToFile		WriteBufferToFileA
#define ReadBufferFromFile		ReadBufferFromFileA
#endif

#ifdef __cplusplus
}
#endif
