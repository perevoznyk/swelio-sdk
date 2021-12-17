//===============================================================================
// Copyright (c) Serhiy Perevoznyk.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Swelio.Engine
{

    [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Unicode)]
    public delegate void ReaderCallbackDelegate(ref int readerNumber, ref int eventCode, IntPtr userContext);

    [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Auto)]
    internal delegate IntPtr WndProcDelegate(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

    internal static class NativeMethods
    {
#if WIN64
        public const string DLL_FILE_NAME = "Swelio64.dll";
#else
        public const string DLL_FILE_NAME = "Swelio32.dll";
#endif

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteObject(IntPtr hObject);

        [DllImport("shlwapi.dll", CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool PathUnExpandEnvStrings([MarshalAs(UnmanagedType.LPWStr)] string pszPath, [Out] StringBuilder pszBuf, int cchBuf);



        [DllImport(DLL_FILE_NAME, EntryPoint = "GetCardVersion", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetCardVersion(int readerNumber);

        [DllImport(DLL_FILE_NAME, EntryPoint = "IsCardActivatedEx", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsCardActivatedEx(int readerNumber);

        [DllImport(DLL_FILE_NAME, EntryPoint = "IsCardStillInsertedEx", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsCardStillInsertedEx(int readerNumber);

        [DllImport(DLL_FILE_NAME, EntryPoint = "FileIsLink", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FileIsLink([MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport(DLL_FILE_NAME, EntryPoint = "RecycleBinEmpty", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RecycleBinEmpty();

        [DllImport(DLL_FILE_NAME, EntryPoint = "ActivateCardEx", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ActivateCardEx(int readerNumber);

        [DllImport(DLL_FILE_NAME, EntryPoint = "CardDecryptFileW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CardDecryptFile([MarshalAs(UnmanagedType.LPWStr)] string Source, [MarshalAs(UnmanagedType.LPWStr)] string Destination);

        [DllImport(DLL_FILE_NAME, EntryPoint = "CardEncryptFileW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CardEncryptFile([MarshalAs(UnmanagedType.LPWStr)] string Source, [MarshalAs(UnmanagedType.LPWStr)] string Destination);

        [DllImport(DLL_FILE_NAME, EntryPoint = "CheckMD5", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CheckMD5(byte[] source, int sourceSize, byte[] buffer, int bufferSize);

        [DllImport(DLL_FILE_NAME, EntryPoint = "CheckSHA1", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CheckSHA1(byte[] source, int sourceSize, byte[] buffer, int bufferSize);

        [DllImport(DLL_FILE_NAME, EntryPoint = "ClearFileAttributesW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern void ClearFileAttributes([MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport(DLL_FILE_NAME, EntryPoint = "ClearUnusedMemory", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern void ClearUnusedMemory();

        [DllImport(DLL_FILE_NAME, EntryPoint = "CreateUnicodeFileW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern void CreateUnicodeFile([MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport(DLL_FILE_NAME, EntryPoint = "CurrentIPAddressW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern void CurrentIPAddress(StringBuilder Address, uint Len);

        [DllImport(DLL_FILE_NAME, EntryPoint = "DeactivateCardEx", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern void DeactivateCardEx(int readerNumber);

        [DllImport(DLL_FILE_NAME, EntryPoint = "DecryptFileAESW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DecryptFileAES([MarshalAs(UnmanagedType.LPWStr)] string Source, [MarshalAs(UnmanagedType.LPWStr)] string Destination, [MarshalAs(UnmanagedType.LPWStr)] string Password);

        [DllImport(DLL_FILE_NAME, EntryPoint = "DeleteToRecycleBinW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern void DeleteToRecycleBin([MarshalAs(UnmanagedType.LPWStr)] string fileName, [MarshalAs(UnmanagedType.Bool)] bool Silent);

        [DllImport(DLL_FILE_NAME, EntryPoint = "DirectoryExistsW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DirectoryExists([MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport(DLL_FILE_NAME, EntryPoint = "DisplayCertificate", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern void DisplayCertificate([In, Out] EIDCertificate Certificate);

        [DllImport(DLL_FILE_NAME, EntryPoint = "ReadAuthenticationCertificate", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ReadAuthenticationCertificate([In, Out] EIDCertificate Certificate);

        [DllImport(DLL_FILE_NAME, EntryPoint = "ReadNonRepudiationCertificate", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ReadNonRepudiationCertificate([In, Out] EIDCertificate Certificate);

        [DllImport(DLL_FILE_NAME, EntryPoint = "ReadCaCertificate", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ReadCaCertificate([In, Out] EIDCertificate Certificate);

        [DllImport(DLL_FILE_NAME, EntryPoint = "ReadRootCaCertificate", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ReadRootCaCertificate([In, Out] EIDCertificate Certificate);

        [DllImport(DLL_FILE_NAME, EntryPoint = "ReadRrnCertificate", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ReadRrnCertificate([In, Out] EIDCertificate Certificate);

        [DllImport(DLL_FILE_NAME, EntryPoint = "EmptyRecycleBin", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern void EmptyRecycleBin();

        [DllImport(DLL_FILE_NAME, EntryPoint = "EncodeCertificate", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern int EncodeCertificate([In, Out] EIDCertificate Certificate, byte[] buffer, int bufferSize);

        [DllImport(DLL_FILE_NAME, EntryPoint = "EncodePhoto", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern int EncodePhoto([In, Out] EIDPicture Photo, byte[] buffer, int bufferSize);

        [DllImport(DLL_FILE_NAME, EntryPoint = "LoadPhotoW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern void LoadPhoto([In, Out] EIDPicture Photo, [MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport(DLL_FILE_NAME, EntryPoint = "EncryptFileAESW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EncryptFileAES([MarshalAs(UnmanagedType.LPWStr)] string Source, [MarshalAs(UnmanagedType.LPWStr)] string Destination, [MarshalAs(UnmanagedType.LPWStr)] string Password);

        [DllImport(DLL_FILE_NAME, EntryPoint = "FileCopyW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FileCopy([MarshalAs(UnmanagedType.LPWStr)] string OldName, [MarshalAs(UnmanagedType.LPWStr)] string NewName);

        [DllImport(DLL_FILE_NAME, EntryPoint = "FileDeleteW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern void FileDelete([MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport(DLL_FILE_NAME, EntryPoint = "FileExistsW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FileExists([MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport(DLL_FILE_NAME, EntryPoint = "FileExtensionIsW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FileExtensionIs([MarshalAs(UnmanagedType.LPWStr)] string fileName, [MarshalAs(UnmanagedType.LPWStr)] string Ext);

        [DllImport(DLL_FILE_NAME, EntryPoint = "FileGetSizeW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern int FileGetSize([MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport(DLL_FILE_NAME, EntryPoint = "FileIsExeW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FileIsExe([MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport(DLL_FILE_NAME, EntryPoint = "FileIsIconW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FileIsIcon([MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport(DLL_FILE_NAME, EntryPoint = "FileIsImageW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FileIsImage([MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport(DLL_FILE_NAME, EntryPoint = "FileOrFolderExistsW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FileOrFolderExists([MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport(DLL_FILE_NAME, EntryPoint = "FileRenameW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FileRename([MarshalAs(UnmanagedType.LPWStr)] string OldName, [MarshalAs(UnmanagedType.LPWStr)] string NewName);

        [DllImport(DLL_FILE_NAME, EntryPoint = "FullPathW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FullPath([MarshalAs(UnmanagedType.LPWStr)] string fileName, StringBuilder sb);

        [DllImport(DLL_FILE_NAME, EntryPoint = "GenerateBMPW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern void GenerateBMP([MarshalAs(UnmanagedType.LPWStr)] string fileName, [MarshalAs(UnmanagedType.LPWStr)] string Text, int Margin, int Size, int Level);

        [DllImport(DLL_FILE_NAME, EntryPoint = "GenerateAuthenticationSignatureExW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GenerateAuthenticationSignatureEx(int readerNumber, [MarshalAs(UnmanagedType.LPWStr)] string pinCode, byte[] dataHash, int hashSize, byte[] signature, ref int signatureSize);

        [DllImport(DLL_FILE_NAME, EntryPoint = "GenerateNonRepudiationSignatureExW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GenerateNonRepudiationSignatureEx(int readerNumber, [MarshalAs(UnmanagedType.LPWStr)] string pinCode, byte[] dataHash, int hashSize, byte[] signature, ref int signatureSize);

        [DllImport(DLL_FILE_NAME, EntryPoint = "GeneratePNGW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern void GeneratePNG([MarshalAs(UnmanagedType.LPWStr)] string fileName, [MarshalAs(UnmanagedType.LPWStr)] string Text, int Margin, int Size, int Level);

        [DllImport(DLL_FILE_NAME, EntryPoint = "GenerateQRCodeExW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GenerateQRCodeEx(int readerNumber, [MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport(DLL_FILE_NAME, EntryPoint = "GetEncodedCertificateSize", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern int GetEncodedCertificateSize([In, Out] EIDCertificate Certificate);

        [DllImport(DLL_FILE_NAME, EntryPoint = "GetEncodedPhotoSize", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern int GetEncodedPhotoSize([In, Out] EIDPicture Photo);

        [DllImport(DLL_FILE_NAME, EntryPoint = "GetFilesCountW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern int GetFilesCount([MarshalAs(UnmanagedType.LPWStr)] string FolderName);

        [DllImport(DLL_FILE_NAME, EntryPoint = "GetHBitmapW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern IntPtr GetHBitmap([MarshalAs(UnmanagedType.LPWStr)] string Text, int Margin, int Size, int Level);

        [DllImport(DLL_FILE_NAME, EntryPoint = "GetISOCodeW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetISOCode([MarshalAs(UnmanagedType.LPWStr)] string Nationality, StringBuilder IsoCode, int BufferSize);

        [DllImport(DLL_FILE_NAME, EntryPoint = "GetMD5", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetMD5(byte[] source, int sourceSize, byte[] buffer, int bufferSize);

        [DllImport(DLL_FILE_NAME, EntryPoint = "GetSHA1", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetSHA1(byte[] source, int sourceSize, byte[] buffer, int bufferSize);

        [DllImport(DLL_FILE_NAME, EntryPoint = "GetFileSHA1W", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetFileSHA1([MarshalAs(UnmanagedType.LPWStr)] string fileName, byte[] buffer, int bufferSize);

        [DllImport(DLL_FILE_NAME, EntryPoint = "GetFileMD5W", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetFileMD5([MarshalAs(UnmanagedType.LPWStr)] string fileName, byte[] buffer, int bufferSize);

        [DllImport(DLL_FILE_NAME, EntryPoint = "GetReaderIndexW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern int GetReaderIndex([MarshalAs(UnmanagedType.LPWStr)] string ReaderName);

        [DllImport(DLL_FILE_NAME, EntryPoint = "GetReaderNameW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern int GetReaderName(int readerNumber, StringBuilder StrDest, int Count);

        [DllImport(DLL_FILE_NAME, EntryPoint = "GetReaderNameLenW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern int GetReaderNameLen(int readerNumber);

        [DllImport(DLL_FILE_NAME, EntryPoint = "GetReadersCount", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern int GetReadersCount();

        [DllImport(DLL_FILE_NAME, EntryPoint = "GetSelectedReaderIndex", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern int GetSelectedReaderIndex();

        [DllImport(DLL_FILE_NAME, EntryPoint = "GetStartupW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetStartup([MarshalAs(UnmanagedType.LPWStr)] string AppName);

        [DllImport(DLL_FILE_NAME, EntryPoint = "HibernateWindows", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool HibernateWindows();

        [DllImport(DLL_FILE_NAME, EntryPoint = "IsAnimatedGIFW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsAnimatedGIF([MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport(DLL_FILE_NAME, EntryPoint = "IsCardPresentEx", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsCardPresentEx(int readerNumber);

        [DllImport(DLL_FILE_NAME, EntryPoint = "IsConnectedToInternet", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsConnectedToInternet();

        [DllImport(DLL_FILE_NAME, EntryPoint = "IsDirectoryW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsDirectory([MarshalAs(UnmanagedType.LPWStr)] string FolderName);

        [DllImport(DLL_FILE_NAME, EntryPoint = "IsEIDCardEx", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsEIDCardEx(int readerNumber);

        [DllImport(DLL_FILE_NAME, EntryPoint = "IsEngineActive", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsEngineActive();

        [DllImport(DLL_FILE_NAME, EntryPoint = "IsMaleW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsMale([In, Out] EIDIdentity Identity);

        [DllImport(DLL_FILE_NAME, EntryPoint = "IsMediaCenter", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsMediaCenter();

        [DllImport(DLL_FILE_NAME, EntryPoint = "IsMetroActive", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsMetroActive();

        [DllImport(DLL_FILE_NAME, EntryPoint = "IsMultiTouchReady", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsMultiTouchReady();

        [DllImport(DLL_FILE_NAME, EntryPoint = "IsTabletPC", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsTabletPC();

        [DllImport(DLL_FILE_NAME, EntryPoint = "IsUnicodeFileW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsUnicodeFile([MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport(DLL_FILE_NAME, EntryPoint = "IsValidFileNameW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsValidFileName([MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport(DLL_FILE_NAME, EntryPoint = "IsValidPathNameW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsValidPathName([MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport(DLL_FILE_NAME, EntryPoint = "IsWindows7", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWindows7();

        [DllImport(DLL_FILE_NAME, EntryPoint = "IsWindows10", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWindows10();

        [DllImport(DLL_FILE_NAME, EntryPoint = "IsWindows8", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWindows8();

        [DllImport(DLL_FILE_NAME, EntryPoint = "IsWindowsVista", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWindowsVista();

        [DllImport(DLL_FILE_NAME, EntryPoint = "IsWindowsXP", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWindowsXP();

        [DllImport(DLL_FILE_NAME, EntryPoint = "LoadCertificateW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern void LoadCertificate([MarshalAs(UnmanagedType.LPWStr)] string fileName, [In, Out] EIDCertificate Certificate);

        [DllImport(DLL_FILE_NAME, EntryPoint = "PortAvailable", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool PortAvailable(int portNumber);

        [DllImport(DLL_FILE_NAME, EntryPoint = "GetCardSerialNumber", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetCardSerialNumber(int readerNumber, byte[] serialNumber, ref int serialNumberSize);

        [DllImport(DLL_FILE_NAME, EntryPoint = "ReadAddressExW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ReadAddressEx(int readerNumber, [In, Out] EIDAddress address);

        [DllImport(DLL_FILE_NAME, EntryPoint = "ReadIdentityExW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ReadIdentityEx(int readerNumber, [In, Out] EIDIdentity identity);

        [DllImport(DLL_FILE_NAME, EntryPoint = "ReadPhotoEx", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ReadPhotoEx(int readerNumber, [In, Out] EIDPicture Photo);

        [DllImport(DLL_FILE_NAME, EntryPoint = "ReloadReadersList", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern void ReloadReadersList();

        [DllImport(DLL_FILE_NAME, EntryPoint = "RemoveCallback", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern void RemoveCallback();

        [DllImport(DLL_FILE_NAME, EntryPoint = "IgnoreServiceEvents", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern void IgnoreServiceEvents(bool value);

        [DllImport(DLL_FILE_NAME, EntryPoint = "IgnoreHardwareEvents", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern void IgnoreHardwareEvents(bool value);

        [DllImport(DLL_FILE_NAME, EntryPoint = "RemoveStartupW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern void RemoveStartup([MarshalAs(UnmanagedType.LPWStr)] string AppName);

        [DllImport(DLL_FILE_NAME, EntryPoint = "SaveCardToXmlExW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SaveCardToXmlEx(int readerNumber, [MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport(DLL_FILE_NAME, EntryPoint = "SavePersonToCsvExW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SavePersonToCsvEx(int readerNumber, [MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport(DLL_FILE_NAME, EntryPoint = "SaveCardToXmlExA", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SaveCardToXmlExAnsi(int readerNumber, [MarshalAs(UnmanagedType.LPStr)] string fileName);

        [DllImport(DLL_FILE_NAME, EntryPoint = "SavePersonToCsvExA", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SavePersonToCsvExAnsi(int readerNumber, [MarshalAs(UnmanagedType.LPStr)] string fileName);

        [DllImport(DLL_FILE_NAME, EntryPoint = "SavePhotoAsBitmapExW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SavePhotoAsBitmapEx(int readerNumber, [MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport(DLL_FILE_NAME, EntryPoint = "SavePhotoAsJpegExW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SavePhotoAsJpegEx(int readerNumber, [MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport(DLL_FILE_NAME, EntryPoint = "SelectReader", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SelectReader(int readerNumber);

        [DllImport(DLL_FILE_NAME, EntryPoint = "SelectReaderByNameW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SelectReaderByName([MarshalAs(UnmanagedType.LPWStr)] string ReaderName);

        [DllImport(DLL_FILE_NAME, EntryPoint = "SetCallback", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern void SetCallback(ReaderCallbackDelegate callback, IntPtr userContext);

        [DllImport(DLL_FILE_NAME, EntryPoint = "SetStartupW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern void SetStartup([MarshalAs(UnmanagedType.LPWStr)] string AppName, [MarshalAs(UnmanagedType.LPWStr)] string AppPath);

        [DllImport(DLL_FILE_NAME, EntryPoint = "ShellCopyFileW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern void ShellCopyFile([MarshalAs(UnmanagedType.LPWStr)] string oldName, [MarshalAs(UnmanagedType.LPWStr)] string NewName);

        [DllImport(DLL_FILE_NAME, EntryPoint = "ShowError", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern void ShowError(int ErrorCode);

        [DllImport(DLL_FILE_NAME, EntryPoint = "ShutdownWindows", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ShutdownWindows(int Flags);

        [DllImport(DLL_FILE_NAME, EntryPoint = "StartEngine", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool StartEngine();

        [DllImport(DLL_FILE_NAME, EntryPoint = "StopEngine", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern void StopEngine();

        [DllImport(DLL_FILE_NAME, EntryPoint = "StripFileNameW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern void StripFileName([MarshalAs(UnmanagedType.LPWStr)] string fileName, StringBuilder sb);

        [DllImport(DLL_FILE_NAME, EntryPoint = "SuspendWindows", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SuspendWindows();

        [DllImport(DLL_FILE_NAME, EntryPoint = "TurnMonitorOff", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern void TurnMonitorOff();

        [DllImport(DLL_FILE_NAME, EntryPoint = "TurnMonitorOn", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern void TurnMonitorOn();

        [DllImport(DLL_FILE_NAME, EntryPoint = "VerifyPinExW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool VerifyPinEx(int readerNumber, [MarshalAs(UnmanagedType.LPWStr)] string Value);

        [DllImport(DLL_FILE_NAME, EntryPoint = "VerifySignature", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool VerifySignature([In, Out] EIDCertificate Certificate, byte[] dataHash, int hashSize, byte[] signature, int signatureSize);

        [DllImport(DLL_FILE_NAME, EntryPoint = "SaveAuthenticationCertificateExW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern void SaveAuthenticationCertificateEx([MarshalAs(UnmanagedType.LPWStr)] string fileName, int readerNumber);

        [DllImport(DLL_FILE_NAME, EntryPoint = "SaveCaCertificateExW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern void SaveCaCertificateEx([MarshalAs(UnmanagedType.LPWStr)] string fileName, int readerNumber);

        [DllImport(DLL_FILE_NAME, EntryPoint = "SaveNonRepudiationCertificateExW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern void SaveNonRepudiationCertificateEx([MarshalAs(UnmanagedType.LPWStr)] string fileName, int readerNumber);

        [DllImport(DLL_FILE_NAME, EntryPoint = "SaveRootCaCertificateExW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern void SaveRootCaCertificateEx([MarshalAs(UnmanagedType.LPWStr)] string fileName, int readerNumber);

        [DllImport(DLL_FILE_NAME, EntryPoint = "SaveRrnCertificateExW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern void SaveRrnCertificateEx([MarshalAs(UnmanagedType.LPWStr)] string fileName, int readerNumber);

        [DllImport(DLL_FILE_NAME, EntryPoint = "SaveCardToToXMLStreamExW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SaveCardToToXMLStreamExW(int readerNumber, IntPtr buffer);

        [DllImport(DLL_FILE_NAME, EntryPoint = "SaveCardToToXMLStreamExA", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SaveCardToToXMLStreamExA(int readerNumber, IntPtr buffer);

        [DllImport(DLL_FILE_NAME, EntryPoint = "GetCardBufferSize", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern int GetCardBufferSize(IntPtr buffer);

        [DllImport(DLL_FILE_NAME, EntryPoint = "GetCardBufferA", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
        public static extern void GetCardBufferA(IntPtr buffer, StringBuilder strDest, int count);

        [DllImport(DLL_FILE_NAME, EntryPoint = "GetCardBufferW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern void GetCardBufferW(IntPtr buffer, StringBuilder strDest, int count);

        [DllImport(DLL_FILE_NAME, EntryPoint = "DeleteCardBuffer", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern void DeleteCardBuffer(IntPtr buffer);

        [DllImport(DLL_FILE_NAME, EntryPoint = "CreateCardBuffer", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern IntPtr CreateCardBuffer();

        [DllImport(DLL_FILE_NAME, EntryPoint = "SavePersonCsvToStreamW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SavePersonCsvToStreamW(int readerNumber, IntPtr buffer);

        [DllImport(DLL_FILE_NAME, EntryPoint = "SavePersonCsvToStreamA", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SavePersonCsvToStreamA(int readerNumber, IntPtr buffer);

        [DllImport(DLL_FILE_NAME, EntryPoint = "SendAPDU", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SendAPDU(int readerNumber, byte[] apdu, int apduLen, byte[] result, ref int len);

        [DllImport(DLL_FILE_NAME, EntryPoint = "InitializeContainer", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern IntPtr InitializeContainer();

        [DllImport(DLL_FILE_NAME, EntryPoint = "FreeContainer", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern void FreeContainer(IntPtr container);

        [DllImport(DLL_FILE_NAME, EntryPoint = "SaveContainer", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SaveContainer(IntPtr container, [MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport(DLL_FILE_NAME, EntryPoint = "AddFileToContainer", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AddFileToContainer(IntPtr container, [MarshalAs(UnmanagedType.LPStr)] string fileName);

        [DllImport(DLL_FILE_NAME, EntryPoint = "ContainerCertificate", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ContainerCertificate(IntPtr container, [MarshalAs(UnmanagedType.LPWStr)] string fileName, [MarshalAs(UnmanagedType.LPWStr)] string password);

        [DllImport(DLL_FILE_NAME, EntryPoint = "ContainerPickCertificate", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ContainerPickCertificate(IntPtr container);

        [DllImport(DLL_FILE_NAME, EntryPoint = "ContainerEidCertificate", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ContainerEidCertificate(IntPtr container, int readerNumber);

        [DllImport(DLL_FILE_NAME, EntryPoint = "CardSignCMS", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CardSignCMS(int readerNumber, byte[] data, int dataLen, byte[] signature, ref int signatureLen);

        [DllImport(DLL_FILE_NAME, EntryPoint = "CardSignCMSEx", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CardSignCMSEx(int readerNumber, byte[] data, int dataLen, byte[] signature,ref int signatureLen, [In, Out] EIDError error);

        [DllImport(DLL_FILE_NAME, EntryPoint = "CardSignCadesT", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CardSignCadesT(int readerNumber, byte[] data, int dataLen, byte[] signature, ref int signatureLen);

        [DllImport(DLL_FILE_NAME, EntryPoint = "CardSignCadesTEx", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CardSignCadesTEx(int readerNumber, byte[] data, int dataLen, byte[] signature, ref int signatureLen, [In, Out] EIDError error);

        [DllImport(DLL_FILE_NAME, EntryPoint = "CertSignCMS", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CertSignCMS(string certificate, string password, byte[] data, int dataLen, byte[] signature, ref int signatureLen);

        [DllImport(DLL_FILE_NAME, EntryPoint = "CertSignCMSEx", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CertSignCMSEx(string certificate, string password, byte[] data, int dataLen, byte[] signature, ref int signatureLen, [In, Out] EIDError error);

        [DllImport(DLL_FILE_NAME, EntryPoint = "CertSignCadesT", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CertSignCadesT(string certificate, string password, byte[] data, int dataLen, byte[] signature, ref int signatureLen);

        [DllImport(DLL_FILE_NAME, EntryPoint = "CertSignCadesTEx", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CertSignCadesTEx(string certificate, string password, byte[] data, int dataLen, byte[] signature, ref int signatureLen, [In, Out] EIDError error);

        [DllImport(DLL_FILE_NAME, EntryPoint = "CertSignCMSData", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CertSignCMSData(byte[] certificate, int certLen, string password, byte[] data, int dataLen, byte[] signature, ref int signatureLen, [In, Out] EIDError error);

        [DllImport(DLL_FILE_NAME, EntryPoint = "CertSignCadesTData", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CertSignCadesTData(byte[] certificate, int certLen, string password, byte[] data, int dataLen, byte[] signature, ref int signatureLen, [In, Out] EIDError error);





    }



}
