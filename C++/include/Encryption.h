//===============================================================================
//= Copyright (c) Serhiy Perevoznyk.  All rights reserved.
//= THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//= OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//= LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//= FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

#pragma once

#if !defined( _ENCRYPTION_H_ )
#define _ENCRYPTION_H_

#ifdef __cplusplus
extern "C" {
#endif

 //  Summary
 //  Gets the SHA1 hash value for the file
 //  Description
 //  Calculates SHA1 hash value for the given file
 //  Parameters
 //  fileName :    The name of the file
 //  buffer :      The buffer to store the hash value
 //  bufferSize :  The size of the buffer
 //  
 //  Return Value
 //  The result of the function is equal to TRUE if operation is
 //  completed successfully, otherwise the result is FALSE       
BOOL WINAPI GetFileSHA1W(LPWSTR fileName, BYTE* buffer, int bufferSize);

 //  Summary
 //  Gets the SHA1 hash value for the file
 //  Description
 //  Calculates SHA1 hash value for the given file
 //  Parameters
 //  fileName :    The name of the file
 //  buffer :      The buffer to store the hash value
 //  bufferSize :  The size of the buffer
 //  Return Value
 //  The result of the function is equal to TRUE if operation is
 //  completed successfully, otherwise the result is FALSE       
BOOL WINAPI GetFileSHA1A(LPSTR fileName, BYTE* buffer, int bufferSize);

 //  Summary
 //  Gets the MD5 hash value for the file
 //  Description
 //  Calculates MD5 hash value for the given file
 //  Parameters
 //  fileName :    The name of the file
 //  buffer :      The buffer to store the hash value
 //  bufferSize :  The size of the buffer
 //  Return Value
 //  The result of the function is equal to TRUE if operation is
 //  completed successfully, otherwise the result is FALSE       
BOOL WINAPI GetFileMD5W(LPWSTR fileName, BYTE* buffer, int bufferSize);

 //  Summary
 //  Gets the MD5 hash value for the file
 //  Description
 //  Calculates MD5 hash value for the given file
 //  Parameters
 //  fileName :    The name of the file
 //  buffer :      The buffer to store the hash value
 //  bufferSize :  The size of the buffer
 //  Return Value
 //  The result of the function is equal to TRUE if operation is
 //  completed successfully, otherwise the result is FALSE       
BOOL WINAPI GetFileMD5A(LPSTR fileName, BYTE* buffer, int bufferSize);

 //  Summary
 //  Gets the SHA1 hash value for the content of the memory buffer
 //  Description
 //  Calculates SHA1 hash value for the given memory buffer
 //  Return Value
 //  The result of the function is equal to TRUE if operation is
 //  completed successfully, otherwise the result is FALSE
 //  Parameters
 //  source :      The source memory block
 //  sourceSize :  The size of the source memory block
 //  buffer :      The buffer for the hash value
 //  bufferSize :  The size of the destination buffer              
BOOL WINAPI GetSHA1(BYTE* source, int sourceSize, BYTE* buffer, int bufferSize);

 //  Summary
 //  Gets the MD5 hash value for the content of the memory buffer
 //  Description
 //  Calculates MD5 hash value for the given memory buffer
 //  Return Value
 //  The result of the function is equal to TRUE if operation is
 //  completed successfully, otherwise the result is FALSE
 //  Parameters
 //  source :      The source memory block
 //  sourceSize :  The size of the source memory block
 //  buffer :      The buffer for the hash value
 //  bufferSize :  The size of the destination buffer              
BOOL WINAPI GetMD5(BYTE* source, int sourceSize, BYTE* buffer, int bufferSize);

 //  Summary
 //  Checks the SHA1 hash value of the memory buffer
 //  Description
 //  This function checks if the provided value of the hash is
 //  valid
 //  Parameters
 //  source :      The source bytes
 //  sourceSize :  The size of the source buffer
 //  buffer :      The hash value buffer
 //  bufferSize :  The size of the hash value buffer
 //  Return Value
 //  Returns TRUE if the hash value is correct, otherwise returns
 //  false                                                                
BOOL WINAPI CheckSHA1(BYTE* source, int sourceSize, BYTE* buffer, int bufferSize);

 //  Summary
 //  Checks the MD5 hash value of the memory buffer
 //  Description
 //  This function checks if the provided value of the hash is
 //  valid
 //  Parameters
 //  source :      The source bytes
 //  sourceSize :  The size of the source buffer
 //  buffer :      The hash value buffer
 //  bufferSize :  The size of the hash value buffer
 //  Return Value
 //  Returns TRUE if the hash value is correct, otherwise returns
 //  false                                                                
BOOL WINAPI CheckMD5(BYTE* source, int sourceSize, BYTE* buffer, int bufferSize);

 //  Summary
 //  Encrypts file using AES algorithm.
 //  Description
 //  Use this function to encrypt the file using AES algorithm
 //  Parameters
 //  szSource :       The source file name
 //  szDestination :  The encrypted file name
 //  szPassword :     The password
 //  Return Value
 //  Returns TRUE if the file is successfully encrypted, otherwise
 //  returns FALSE                                                 
BOOL WINAPI EncryptFileAESW(LPWSTR szSource, LPWSTR szDestination, LPWSTR szPassword);

 //  Summary
 //  Encrypts file using AES algorithm.
 //  Description
 //  Use this function to encrypt the file using AES algorithm
 //  Parameters
 //  szSource :       The source file name
 //  szDestination :  The encrypted file name
 //  szPassword :     The password
 //  Return Value
 //  Returns TRUE if the file is successfully encrypted, otherwise
 //  returns FALSE                                                 
BOOL WINAPI EncryptFileAESA(LPSTR szSource, LPSTR szDestination, LPSTR szPassword);

 //  Summary
 //  Decrypts file using AES algorithm.
 //  Description
 //  Use this function to decrypt the file using AES algorithm
 //  Parameters
 //  szSource :       The source file name
 //  szDestination :  The decrypted file name
 //  szPassword :     The password
 //  Return Value
 //  Returns TRUE if the file is successfully decrypted, otherwise
 //  returns FALSE.                                                
BOOL WINAPI DecryptFileAESW(LPWSTR szSource, LPWSTR szDestination, LPWSTR szPassword);

 //  Summary
 //  Decrypts file using AES algorithm.
 //  Description
 //  Use this function to decrypt the file using AES algorithm
 //  Parameters
 //  szSource :       The source file name
 //  szDestination :  The decrypted file name
 //  szPassword :     The password
 //  Return Value
 //  Returns TRUE if the file is successfully decrypted, otherwise
 //  returns FALSE.                                                
BOOL WINAPI DecryptFileAESA(LPSTR szSource, LPSTR szDestination, LPSTR szPassword);

 //  Summary
 //  Encrypt file using Belgian Id card
 //  Description
 //  Encrypt file using Belgian Id card. The card must be inserted
 //  in the reader
 //  Parameters
 //  szSource :       The name of the source file
 //  szDestination :  The name of the encrypted file               
BOOL WINAPI CardEncryptFileW(LPWSTR szSource, LPWSTR szDestination);

 //  Summary
 //  Encrypt file using Belgian Id card
 //  Description
 //  Encrypt file using Belgian Id card. The card must be inserted
 //  in the reader
 //  Parameters
 //  szSource :       The name of the source file
 //  szDestination :  The name of the encrypted file               
BOOL WINAPI CardEncryptFileA(LPSTR szSource, LPSTR szDestination);

 //  Summary
 //  Decrypt file using Belgian Id card
 //  Description
 //  Decrypt file which was encrypted using CardEncryptFile
 //  function
 //  Parameters
 //  szSource :       The name of the encrypted file
 //  szDestination :  The name of the decrypted file        
BOOL WINAPI CardDecryptFileW(LPWSTR szSource, LPWSTR szDestination);

 //  Summary
 //  Decrypt file using Belgian Id card
 //  Description
 //  Decrypt file which was encrypted using CardEncryptFile
 //  function
 //  Parameters
 //  szSource :       The name of the encrypted file
 //  szDestination :  The name of the decrypted file        
BOOL WINAPI CardDecryptFileA(LPSTR szSource, LPSTR szDestination);

#ifdef UNICODE
#define GetFileSHA1 GetFileSHA1W
#define GetFileMD5 GetFileMD5W
#define EncryptFileAES EncryptFileAESW
#define DecryptFileAES DecryptFileAESW
#define CardEncryptFile CardEncryptFileW
#define CardDecryptFile CardDecryptFileW
#else
#define GetFileSHA1 GetFileSHA1A
#define GetFileMD5 GetFileMD5A
#define EncryptFileAES EncryptFileAESA
#define DecryptFileAES DecryptFileAESA
#define CardEncryptFile CardEncryptFileA
#define CardDecryptFile CardDecryptFileA
#endif

#ifdef __cplusplus
}
#endif

#endif     // __ENCRYPTION_H__
