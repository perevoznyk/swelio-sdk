//===============================================================================
// Copyright (c) Serhiy Perevoznyk.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Swelio.Engine
{

    [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Unicode)]
    public delegate void ReaderCallbackDelegate(ref int readerNumber, ref int eventCode, IntPtr userContext);


    internal static class NativeMethods
    {
        public static bool IsWOW64()
        {
            return IntPtr.Size == 8;
        }

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteObject(IntPtr hObject);

        [DllImport("shlwapi.dll", CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool PathUnExpandEnvStrings([MarshalAs(UnmanagedType.LPWStr)] string pszPath, [Out] StringBuilder pszBuf, int cchBuf);


        [DllImport("Swelio32.dll", EntryPoint = "IsCardActivatedEx", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsCardActivatedEx32(int readerNumber);

        [DllImport("Swelio32.dll", EntryPoint = "IsCardStillInsertedEx", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsCardStillInsertedEx32(int readerNumber);

        [DllImport("Swelio32.dll", EntryPoint = "FileIsLink", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool FileIsLink32([MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport("Swelio32.dll", EntryPoint = "RecycleBinEmpty", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool RecycleBinEmpty32();

        [DllImport("Swelio32.dll", EntryPoint = "ActivateCardEx", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ActivateCardEx32(int readerNumber);

        [DllImport("Swelio32.dll", EntryPoint = "CardDecryptFileW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CardDecryptFile32([MarshalAs(UnmanagedType.LPWStr)] string Source, [MarshalAs(UnmanagedType.LPWStr)] string Destination);

        [DllImport("Swelio32.dll", EntryPoint = "CardEncryptFileW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CardEncryptFile32([MarshalAs(UnmanagedType.LPWStr)] string Source, [MarshalAs(UnmanagedType.LPWStr)] string Destination);

        [DllImport("Swelio32.dll", EntryPoint = "CheckMD5", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CheckMD532(byte[] source, int sourceSize, byte[] buffer, int bufferSize);

        [DllImport("Swelio32.dll", EntryPoint = "CheckSHA1", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CheckSHA132(byte[] source, int sourceSize, byte[] buffer, int bufferSize);

        [DllImport("Swelio32.dll", EntryPoint = "ClearFileAttributesW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void ClearFileAttributes32([MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport("Swelio32.dll", EntryPoint = "ClearUnusedMemory", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void ClearUnusedMemory32();

        [DllImport("Swelio32.dll", EntryPoint = "CreateUnicodeFileW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void CreateUnicodeFile32([MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport("Swelio32.dll", EntryPoint = "CurrentIPAddressW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void CurrentIPAddress32(StringBuilder Address, uint Len);

        [DllImport("Swelio32.dll", EntryPoint = "DeactivateCardEx", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void DeactivateCardEx32(int readerNumber);

        [DllImport("Swelio32.dll", EntryPoint = "DecryptFileAESW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool DecryptFileAES32([MarshalAs(UnmanagedType.LPWStr)] string Source, [MarshalAs(UnmanagedType.LPWStr)] string Destination, [MarshalAs(UnmanagedType.LPWStr)] string Password);

        [DllImport("Swelio32.dll", EntryPoint = "DeleteToRecycleBinW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void DeleteToRecycleBin32([MarshalAs(UnmanagedType.LPWStr)] string fileName, [MarshalAs(UnmanagedType.Bool)] bool Silent);

        [DllImport("Swelio32.dll", EntryPoint = "DirectoryExistsW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool DirectoryExists32([MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport("Swelio32.dll", EntryPoint = "DisplayCertificate", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void DisplayCertificate32([In, Out] EIDCertificate Certificate);

        [DllImport("Swelio32.dll", EntryPoint = "ReadAuthenticationCertificate", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ReadAuthenticationCertificate32([In, Out] EIDCertificate Certificate);

        [DllImport("Swelio32.dll", EntryPoint = "ReadNonRepudiationCertificate", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ReadNonRepudiationCertificate32([In, Out] EIDCertificate Certificate);

        [DllImport("Swelio32.dll", EntryPoint = "ReadCaCertificate", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ReadCaCertificate32([In, Out] EIDCertificate Certificate);

        [DllImport("Swelio32.dll", EntryPoint = "ReadRootCaCertificate", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ReadRootCaCertificate32([In, Out] EIDCertificate Certificate);

        [DllImport("Swelio32.dll", EntryPoint = "ReadRrnCertificate", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ReadRrnCertificate32([In, Out] EIDCertificate Certificate);

        [DllImport("Swelio32.dll", EntryPoint = "EmptyRecycleBin", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void EmptyRecycleBin32();

        [DllImport("Swelio32.dll", EntryPoint = "EncodeCertificate", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern int EncodeCertificate32([In, Out] EIDCertificate Certificate, byte[] buffer, int bufferSize);

        [DllImport("Swelio32.dll", EntryPoint = "EncodePhoto", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern int EncodePhoto32([In, Out] EIDPicture Photo, byte[] buffer, int bufferSize);

        [DllImport("Swelio32.dll", EntryPoint = "LoadPhotoW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void LoadPhoto32([In, Out] EIDPicture Photo, [MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport("Swelio32.dll", EntryPoint = "EncryptFileAESW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EncryptFileAES32([MarshalAs(UnmanagedType.LPWStr)] string Source, [MarshalAs(UnmanagedType.LPWStr)] string Destination, [MarshalAs(UnmanagedType.LPWStr)] string Password);

        [DllImport("Swelio32.dll", EntryPoint = "FileCopyW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool FileCopy32([MarshalAs(UnmanagedType.LPWStr)] string OldName, [MarshalAs(UnmanagedType.LPWStr)] string NewName);

        [DllImport("Swelio32.dll", EntryPoint = "FileDeleteW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void FileDelete32([MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport("Swelio32.dll", EntryPoint = "FileExistsW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool FileExists32([MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport("Swelio32.dll", EntryPoint = "FileExtensionIsW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool FileExtensionIs32([MarshalAs(UnmanagedType.LPWStr)] string fileName, [MarshalAs(UnmanagedType.LPWStr)] string Ext);

        [DllImport("Swelio32.dll", EntryPoint = "FileGetSizeW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern int FileGetSize32([MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport("Swelio32.dll", EntryPoint = "FileIsExeW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool FileIsExe32([MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport("Swelio32.dll", EntryPoint = "FileIsIconW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool FileIsIcon32([MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport("Swelio32.dll", EntryPoint = "FileIsImageW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool FileIsImage32([MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport("Swelio32.dll", EntryPoint = "FileOrFolderExistsW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool FileOrFolderExists32([MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport("Swelio32.dll", EntryPoint = "FileRenameW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool FileRename32([MarshalAs(UnmanagedType.LPWStr)] string OldName, [MarshalAs(UnmanagedType.LPWStr)] string NewName);

        [DllImport("Swelio32.dll", EntryPoint = "FullPathW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool FullPath32([MarshalAs(UnmanagedType.LPWStr)] string fileName, StringBuilder sb);

        [DllImport("Swelio32.dll", EntryPoint = "GenerateBMPW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void GenerateBMP32([MarshalAs(UnmanagedType.LPWStr)] string fileName, [MarshalAs(UnmanagedType.LPWStr)] string Text, int Margin, int Size, int Level);

        [DllImport("Swelio32.dll", EntryPoint = "GenerateAuthenticationSignatureExW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GenerateAuthenticationSignatureEx32(int readerNumber, [MarshalAs(UnmanagedType.LPWStr)] string pinCode, byte[] dataHash, int hashSize, byte[] signature, ref int signatureSize);

        [DllImport("Swelio32.dll", EntryPoint = "GenerateNonRepudiationSignatureExW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GenerateNonRepudiationSignatureEx32(int readerNumber, [MarshalAs(UnmanagedType.LPWStr)] string pinCode, byte[] dataHash, int hashSize, byte[] signature, ref int signatureSize);

        [DllImport("Swelio32.dll", EntryPoint = "GeneratePNGW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void GeneratePNG32([MarshalAs(UnmanagedType.LPWStr)] string fileName, [MarshalAs(UnmanagedType.LPWStr)] string Text, int Margin, int Size, int Level);

        [DllImport("Swelio32.dll", EntryPoint = "GenerateQRCodeExW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GenerateQRCodeEx32(int readerNumber, [MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport("Swelio32.dll", EntryPoint = "GetEncodedCertificateSize", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern int GetEncodedCertificateSize32([In, Out] EIDCertificate Certificate);

        [DllImport("Swelio32.dll", EntryPoint = "GetEncodedPhotoSize", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern int GetEncodedPhotoSize32([In, Out] EIDPicture Photo);

        [DllImport("Swelio32.dll", EntryPoint = "GetFilesCountW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern int GetFilesCount32([MarshalAs(UnmanagedType.LPWStr)] string FolderName);

        [DllImport("Swelio32.dll", EntryPoint = "GetHBitmapW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern IntPtr GetHBitmap32([MarshalAs(UnmanagedType.LPWStr)] string Text, int Margin, int Size, int Level);

        [DllImport("Swelio32.dll", EntryPoint = "GetISOCodeW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetISOCode32([MarshalAs(UnmanagedType.LPWStr)] string Nationality, StringBuilder IsoCode, int BufferSize);

        [DllImport("Swelio32.dll", EntryPoint = "GetMD5", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetMD532(byte[] source, int sourceSize, byte[] buffer, int bufferSize);

        [DllImport("Swelio32.dll", EntryPoint = "GetSHA1", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetSHA132(byte[] source, int sourceSize, byte[] buffer, int bufferSize);

        [DllImport("Swelio32.dll", EntryPoint = "GetFileSHA1W", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetFileSHA132([MarshalAs(UnmanagedType.LPWStr)] string fileName, byte[] buffer, int bufferSize);

        [DllImport("Swelio32.dll", EntryPoint = "GetFileMD5W", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetFileMD532([MarshalAs(UnmanagedType.LPWStr)] string fileName, byte[] buffer, int bufferSize);

        [DllImport("Swelio32.dll", EntryPoint = "GetReaderIndexW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern int GetReaderIndex32([MarshalAs(UnmanagedType.LPWStr)] string ReaderName);

        [DllImport("Swelio32.dll", EntryPoint = "GetReaderNameW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern int GetReaderName32(int readerNumber, StringBuilder StrDest, int Count);

        [DllImport("Swelio32.dll", EntryPoint = "GetReaderNameLenW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern int GetReaderNameLen32(int readerNumber);

        [DllImport("Swelio32.dll", EntryPoint = "GetReadersCount", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern int GetReadersCount32();

        [DllImport("Swelio32.dll", EntryPoint = "GetSelectedReaderIndex", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern int GetSelectedReaderIndex32();

        [DllImport("Swelio32.dll", EntryPoint = "GetStartupW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetStartup32([MarshalAs(UnmanagedType.LPWStr)] string AppName);

        [DllImport("Swelio32.dll", EntryPoint = "HibernateWindows", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool HibernateWindows32();

        [DllImport("Swelio32.dll", EntryPoint = "IsAnimatedGIFW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsAnimatedGIF32([MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport("Swelio32.dll", EntryPoint = "IsCardPresentEx", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsCardPresentEx32(int readerNumber);

        [DllImport("Swelio32.dll", EntryPoint = "IsConnectedToInternet", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsConnectedToInternet32();

        [DllImport("Swelio32.dll", EntryPoint = "IsDirectoryW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsDirectory32([MarshalAs(UnmanagedType.LPWStr)] string FolderName);

        [DllImport("Swelio32.dll", EntryPoint = "IsEIDCardEx", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsEIDCardEx32(int readerNumber);

        [DllImport("Swelio32.dll", EntryPoint = "IsEngineActive", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsEngineActive32();

        [DllImport("Swelio32.dll", EntryPoint = "IsMaleW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsMale32([In, Out] EIDIdentity Identity);

        [DllImport("Swelio32.dll", EntryPoint = "IsMediaCenter", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsMediaCenter32();

        [DllImport("Swelio32.dll", EntryPoint = "IsMetroActive", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsMetroActive32();

        [DllImport("Swelio32.dll", EntryPoint = "IsMultiTouchReady", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsMultiTouchReady32();

        [DllImport("Swelio32.dll", EntryPoint = "IsTabletPC", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsTabletPC32();

        [DllImport("Swelio32.dll", EntryPoint = "IsUnicodeFileW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsUnicodeFile32([MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport("Swelio32.dll", EntryPoint = "IsValidFileNameW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsValidFileName32([MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport("Swelio32.dll", EntryPoint = "IsValidPathNameW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsValidPathName32([MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport("Swelio32.dll", EntryPoint = "IsWindows7", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWindows732();

        [DllImport("Swelio32.dll", EntryPoint = "IsWindows10", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWindows1032();

        [DllImport("Swelio32.dll", EntryPoint = "IsWindows8", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWindows832();

        [DllImport("Swelio32.dll", EntryPoint = "IsWindowsVista", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWindowsVista32();

        [DllImport("Swelio32.dll", EntryPoint = "IsWindowsXP", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWindowsXP32();

        [DllImport("Swelio32.dll", EntryPoint = "LoadCertificateW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void LoadCertificate32([MarshalAs(UnmanagedType.LPWStr)] string fileName, [In, Out] EIDCertificate Certificate);

        [DllImport("Swelio32.dll", EntryPoint = "PortAvailable", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool PortAvailable32(int portNumber);

        [DllImport("Swelio32.dll", EntryPoint = "GetCardSerialNumber", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetCardSerialNumber32(int readerNumber, byte[] serialNumber, ref int serialNumberSize);

        [DllImport("Swelio32.dll", EntryPoint = "ReadAddressExW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ReadAddressEx32(int readerNumber, [In, Out] EIDAddress address);

        [DllImport("Swelio32.dll", EntryPoint = "ReadIdentityExW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ReadIdentityEx32(int readerNumber, [In, Out] EIDIdentity identity);

        [DllImport("Swelio32.dll", EntryPoint = "ReadPhotoEx", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ReadPhotoEx32(int readerNumber, [In, Out] EIDPicture Photo);

        [DllImport("Swelio32.dll", EntryPoint = "ReloadReadersList", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void ReloadReadersList32();

        [DllImport("Swelio32.dll", EntryPoint = "RemoveCallback", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void RemoveCallback32();

        [DllImport("Swelio32.dll", EntryPoint = "RemoveStartupW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void RemoveStartup32([MarshalAs(UnmanagedType.LPWStr)] string AppName);

        [DllImport("Swelio32.dll", EntryPoint = "SaveCardToXmlExW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SaveCardToXmlEx32(int readerNumber, [MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport("Swelio32.dll", EntryPoint = "SavePersonToCsvExW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SavePersonToCsvEx32(int readerNumber, [MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport("Swelio32.dll", EntryPoint = "SaveCardToXmlExA", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SaveCardToXmlExAnsi32(int readerNumber, [MarshalAs(UnmanagedType.LPStr)] string fileName);

        [DllImport("Swelio32.dll", EntryPoint = "SavePersonToCsvExA", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SavePersonToCsvExAnsi32(int readerNumber, [MarshalAs(UnmanagedType.LPStr)] string fileName);

        [DllImport("Swelio32.dll", EntryPoint = "SavePhotoAsBitmapExW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SavePhotoAsBitmapEx32(int readerNumber, [MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport("Swelio32.dll", EntryPoint = "SavePhotoAsJpegExW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SavePhotoAsJpegEx32(int readerNumber, [MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport("Swelio32.dll", EntryPoint = "SelectReader", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SelectReader32(int readerNumber);

        [DllImport("Swelio32.dll", EntryPoint = "SelectReaderByNameW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SelectReaderByName32([MarshalAs(UnmanagedType.LPWStr)] string ReaderName);

        [DllImport("Swelio32.dll", EntryPoint = "SetCallback", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void SetCallback32(ReaderCallbackDelegate callback, IntPtr userContext);

        [DllImport("Swelio32.dll", EntryPoint = "SetStartupW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void SetStartup32([MarshalAs(UnmanagedType.LPWStr)] string AppName, [MarshalAs(UnmanagedType.LPWStr)] string AppPath);

        [DllImport("Swelio32.dll", EntryPoint = "ShellCopyFileW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void ShellCopyFile32([MarshalAs(UnmanagedType.LPWStr)] string oldName, [MarshalAs(UnmanagedType.LPWStr)] string NewName);

        [DllImport("Swelio32.dll", EntryPoint = "ShowError", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void ShowError32(int ErrorCode);

        [DllImport("Swelio32.dll", EntryPoint = "ShutdownWindows", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ShutdownWindows32(int Flags);

        [DllImport("Swelio32.dll", EntryPoint = "StartEngine", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool StartEngine32();

        [DllImport("Swelio32.dll", EntryPoint = "StopEngine", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void StopEngine32();

        [DllImport("Swelio32.dll", EntryPoint = "StripFileNameW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void StripFileName32([MarshalAs(UnmanagedType.LPWStr)] string fileName, StringBuilder sb);

        [DllImport("Swelio32.dll", EntryPoint = "SuspendWindows", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SuspendWindows32();

        [DllImport("Swelio32.dll", EntryPoint = "TurnMonitorOff", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void TurnMonitorOff32();

        [DllImport("Swelio32.dll", EntryPoint = "TurnMonitorOn", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void TurnMonitorOn32();

        [DllImport("Swelio32.dll", EntryPoint = "VerifyPinExW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool VerifyPinEx32(int readerNumber, [MarshalAs(UnmanagedType.LPWStr)] string Value);

        [DllImport("Swelio32.dll", EntryPoint = "VerifySignature", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool VerifySignature32([In, Out] EIDCertificate Certificate, byte[] dataHash, int hashSize, byte[] signature, int signatureSize);

        [DllImport("Swelio32.dll", EntryPoint = "SaveAuthenticationCertificateExW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void SaveAuthenticationCertificateEx32([MarshalAs(UnmanagedType.LPWStr)] string fileName, int readerNumber);

        [DllImport("Swelio32.dll", EntryPoint = "SaveCaCertificateExW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void SaveCaCertificateEx32([MarshalAs(UnmanagedType.LPWStr)] string fileName, int readerNumber);

        [DllImport("Swelio32.dll", EntryPoint = "SaveNonRepudiationCertificateExW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void SaveNonRepudiationCertificateEx32([MarshalAs(UnmanagedType.LPWStr)] string fileName, int readerNumber);

        [DllImport("Swelio32.dll", EntryPoint = "SaveRootCaCertificateExW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void SaveRootCaCertificateEx32([MarshalAs(UnmanagedType.LPWStr)] string fileName, int readerNumber);

        [DllImport("Swelio32.dll", EntryPoint = "SaveRrnCertificateExW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void SaveRrnCertificateEx32([MarshalAs(UnmanagedType.LPWStr)] string fileName, int readerNumber);


        [DllImport("Swelio32.dll", EntryPoint = "SaveCardToToXMLStreamExW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SaveCardToToXMLStreamExW32(int readerNumber, IntPtr buffer);

        [DllImport("Swelio32.dll", EntryPoint = "SaveCardToToXMLStreamExA", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SaveCardToToXMLStreamExA32(int readerNumber, IntPtr buffer);

        [DllImport("Swelio32.dll", EntryPoint = "GetCardBufferSize", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern int GetCardBufferSize32(IntPtr buffer);

        [DllImport("Swelio32.dll", EntryPoint = "GetCardBufferA", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
        private static extern void GetCardBufferA32(IntPtr buffer, StringBuilder strDest, int count);

        [DllImport("Swelio32.dll", EntryPoint = "GetCardBufferW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void GetCardBufferW32(IntPtr buffer, StringBuilder strDest, int count);

        [DllImport("Swelio32.dll", EntryPoint = "DeleteCardBuffer", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void DeleteCardBuffer32(IntPtr buffer);

        [DllImport("Swelio32.dll", EntryPoint = "CreateCardBuffer", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern IntPtr CreateCardBuffer32();

        [DllImport("Swelio32.dll", EntryPoint = "SavePersonCsvToStreamW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SavePersonCsvToStreamW32(int readerNumber, IntPtr buffer);

        [DllImport("Swelio32.dll", EntryPoint = "SavePersonCsvToStreamA", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SavePersonCsvToStreamA32(int readerNumber, IntPtr buffer);

        [DllImport("Swelio32.dll", EntryPoint = "SendAPDU", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SendAPDU32(int readerNumber, byte[] apdu, int apduLen, byte[] result, ref int len);

        [DllImport("Swelio32.dll", EntryPoint = "SendAPDU", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SendAPDU64(int readerNumber, byte[] apdu, int apduLen, byte[] result, ref int len);

        [DllImport("Swelio64.dll", EntryPoint = "IsCardActivatedEx", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsCardActivatedEx64(int readerNumber);

        [DllImport("Swelio64.dll", EntryPoint = "IsCardStillInsertedEx", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsCardStillInsertedEx64(int readerNumber);

        [DllImport("Swelio64.dll", EntryPoint = "FileIsLink", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool FileIsLink64([MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport("Swelio64.dll", EntryPoint = "RecycleBinEmpty", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool RecycleBinEmpty64();

        [DllImport("Swelio64.dll", EntryPoint = "ActivateCardEx", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ActivateCardEx64(int readerNumber);

        [DllImport("Swelio64.dll", EntryPoint = "CardDecryptFileW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CardDecryptFile64([MarshalAs(UnmanagedType.LPWStr)] string Source, [MarshalAs(UnmanagedType.LPWStr)] string Destination);

        [DllImport("Swelio64.dll", EntryPoint = "CardEncryptFileW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CardEncryptFile64([MarshalAs(UnmanagedType.LPWStr)] string Source, [MarshalAs(UnmanagedType.LPWStr)] string Destination);

        [DllImport("Swelio64.dll", EntryPoint = "CheckMD5", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CheckMD564(byte[] source, int sourceSize, byte[] buffer, int bufferSize);

        [DllImport("Swelio64.dll", EntryPoint = "CheckSHA1", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CheckSHA164(byte[] source, int sourceSize, byte[] buffer, int bufferSize);

        [DllImport("Swelio64.dll", EntryPoint = "ClearFileAttributesW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void ClearFileAttributes64([MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport("Swelio64.dll", EntryPoint = "ClearUnusedMemory", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void ClearUnusedMemory64();

        [DllImport("Swelio64.dll", EntryPoint = "CreateUnicodeFileW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void CreateUnicodeFile64([MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport("Swelio64.dll", EntryPoint = "CurrentIPAddressW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void CurrentIPAddress64(StringBuilder Address, uint Len);

        [DllImport("Swelio64.dll", EntryPoint = "DeactivateCardEx", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void DeactivateCardEx64(int readerNumber);

        [DllImport("Swelio64.dll", EntryPoint = "DecryptFileAESW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool DecryptFileAES64([MarshalAs(UnmanagedType.LPWStr)] string Source, [MarshalAs(UnmanagedType.LPWStr)] string Destination, [MarshalAs(UnmanagedType.LPWStr)] string Password);

        [DllImport("Swelio64.dll", EntryPoint = "DeleteToRecycleBinW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void DeleteToRecycleBin64([MarshalAs(UnmanagedType.LPWStr)] string fileName, [MarshalAs(UnmanagedType.Bool)] bool Silent);

        [DllImport("Swelio64.dll", EntryPoint = "DirectoryExistsW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool DirectoryExists64([MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport("Swelio64.dll", EntryPoint = "DisplayCertificate", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void DisplayCertificate64([In, Out] EIDCertificate Certificate);

        [DllImport("Swelio64.dll", EntryPoint = "ReadAuthenticationCertificate", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ReadAuthenticationCertificate64([In, Out] EIDCertificate Certificate);

        [DllImport("Swelio64.dll", EntryPoint = "ReadNonRepudiationCertificate", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ReadNonRepudiationCertificate64([In, Out] EIDCertificate Certificate);

        [DllImport("Swelio64.dll", EntryPoint = "ReadCaCertificate", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ReadCaCertificate64([In, Out] EIDCertificate Certificate);

        [DllImport("Swelio64.dll", EntryPoint = "ReadRootCaCertificate", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ReadRootCaCertificate64([In, Out] EIDCertificate Certificate);

        [DllImport("Swelio64.dll", EntryPoint = "ReadRrnCertificate", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ReadRrnCertificate64([In, Out] EIDCertificate Certificate);

        [DllImport("Swelio64.dll", EntryPoint = "EmptyRecycleBin", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void EmptyRecycleBin64();

        [DllImport("Swelio64.dll", EntryPoint = "EncodeCertificate", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern int EncodeCertificate64([In, Out] EIDCertificate Certificate, byte[] buffer, int bufferSize);

        [DllImport("Swelio64.dll", EntryPoint = "EncodePhoto", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern int EncodePhoto64([In, Out] EIDPicture Photo, byte[] buffer, int bufferSize);

        [DllImport("Swelio64.dll", EntryPoint = "LoadPhotoW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void LoadPhoto64([In, Out] EIDPicture Photo, [MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport("Swelio64.dll", EntryPoint = "EncryptFileAESW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EncryptFileAES64([MarshalAs(UnmanagedType.LPWStr)] string Source, [MarshalAs(UnmanagedType.LPWStr)] string Destination, [MarshalAs(UnmanagedType.LPWStr)] string Password);

        [DllImport("Swelio64.dll", EntryPoint = "FileCopyW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool FileCopy64([MarshalAs(UnmanagedType.LPWStr)] string OldName, [MarshalAs(UnmanagedType.LPWStr)] string NewName);

        [DllImport("Swelio64.dll", EntryPoint = "FileDeleteW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void FileDelete64([MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport("Swelio64.dll", EntryPoint = "FileExistsW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool FileExists64([MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport("Swelio64.dll", EntryPoint = "FileExtensionIsW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool FileExtensionIs64([MarshalAs(UnmanagedType.LPWStr)] string fileName, [MarshalAs(UnmanagedType.LPWStr)] string Ext);

        [DllImport("Swelio64.dll", EntryPoint = "FileGetSizeW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern int FileGetSize64([MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport("Swelio64.dll", EntryPoint = "FileIsExeW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool FileIsExe64([MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport("Swelio64.dll", EntryPoint = "FileIsIconW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool FileIsIcon64([MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport("Swelio64.dll", EntryPoint = "FileIsImageW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool FileIsImage64([MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport("Swelio64.dll", EntryPoint = "FileOrFolderExistsW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool FileOrFolderExists64([MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport("Swelio64.dll", EntryPoint = "FileRenameW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool FileRename64([MarshalAs(UnmanagedType.LPWStr)] string OldName, [MarshalAs(UnmanagedType.LPWStr)] string NewName);

        [DllImport("Swelio64.dll", EntryPoint = "FullPathW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool FullPath64([MarshalAs(UnmanagedType.LPWStr)] string fileName, StringBuilder sb);

        [DllImport("Swelio64.dll", EntryPoint = "GenerateBMPW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void GenerateBMP64([MarshalAs(UnmanagedType.LPWStr)] string fileName, [MarshalAs(UnmanagedType.LPWStr)] string Text, int Margin, int Size, int Level);

        [DllImport("Swelio64.dll", EntryPoint = "GenerateAuthenticationSignatureExW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GenerateAuthenticationSignatureEx64(int readerNumber, [MarshalAs(UnmanagedType.LPWStr)] string pinCode, byte[] dataHash, int hashSize, byte[] signature, ref int signatureSize);

        [DllImport("Swelio64.dll", EntryPoint = "GenerateNonRepudiationSignatureExW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GenerateNonRepudiationSignatureEx64(int readerNumber, [MarshalAs(UnmanagedType.LPWStr)] string pinCode, byte[] dataHash, int hashSize, byte[] signature, ref int signatureSize);

        [DllImport("Swelio64.dll", EntryPoint = "GeneratePNGW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void GeneratePNG64([MarshalAs(UnmanagedType.LPWStr)] string fileName, [MarshalAs(UnmanagedType.LPWStr)] string Text, int Margin, int Size, int Level);

        [DllImport("Swelio64.dll", EntryPoint = "GenerateQRCodeExW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GenerateQRCodeEx64(int readerNumber, [MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport("Swelio64.dll", EntryPoint = "GetEncodedCertificateSize", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern int GetEncodedCertificateSize64([In, Out] EIDCertificate Certificate);

        [DllImport("Swelio64.dll", EntryPoint = "GetEncodedPhotoSize", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern int GetEncodedPhotoSize64([In, Out] EIDPicture Photo);

        [DllImport("Swelio64.dll", EntryPoint = "GetFilesCountW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern int GetFilesCount64([MarshalAs(UnmanagedType.LPWStr)] string FolderName);

        [DllImport("Swelio64.dll", EntryPoint = "GetHBitmapW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern IntPtr GetHBitmap64([MarshalAs(UnmanagedType.LPWStr)] string Text, int Margin, int Size, int Level);

        [DllImport("Swelio64.dll", EntryPoint = "GetISOCodeW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetISOCode64([MarshalAs(UnmanagedType.LPWStr)] string Nationality, StringBuilder IsoCode, int BufferSize);

        [DllImport("Swelio64.dll", EntryPoint = "GetMD5", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetMD564(byte[] source, int sourceSize, byte[] buffer, int bufferSize);

        [DllImport("Swelio64.dll", EntryPoint = "GetSHA1", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetSHA164(byte[] source, int sourceSize, byte[] buffer, int bufferSize);

        [DllImport("Swelio64.dll", EntryPoint = "GetFileSHA1W", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetFileSHA164([MarshalAs(UnmanagedType.LPWStr)] string fileName, byte[] buffer, int bufferSize);

        [DllImport("Swelio64.dll", EntryPoint = "GetFileMD5W", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetFileMD564([MarshalAs(UnmanagedType.LPWStr)] string fileName, byte[] buffer, int bufferSize);

        [DllImport("Swelio64.dll", EntryPoint = "GetReaderIndexW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern int GetReaderIndex64([MarshalAs(UnmanagedType.LPWStr)] string ReaderName);

        [DllImport("Swelio64.dll", EntryPoint = "GetReaderNameW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern int GetReaderName64(int readerNumber, StringBuilder StrDest, int Count);

        [DllImport("Swelio64.dll", EntryPoint = "GetReaderNameLenW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern int GetReaderNameLen64(int readerNumber);

        [DllImport("Swelio64.dll", EntryPoint = "GetReadersCount", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern int GetReadersCount64();

        [DllImport("Swelio64.dll", EntryPoint = "GetSelectedReaderIndex", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern int GetSelectedReaderIndex64();

        [DllImport("Swelio64.dll", EntryPoint = "GetStartupW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetStartup64([MarshalAs(UnmanagedType.LPWStr)] string AppName);

        [DllImport("Swelio64.dll", EntryPoint = "HibernateWindows", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool HibernateWindows64();

        [DllImport("Swelio64.dll", EntryPoint = "IsAnimatedGIFW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsAnimatedGIF64([MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport("Swelio64.dll", EntryPoint = "IsCardPresentEx", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsCardPresentEx64(int readerNumber);

        [DllImport("Swelio64.dll", EntryPoint = "IsConnectedToInternet", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsConnectedToInternet64();

        [DllImport("Swelio64.dll", EntryPoint = "IsDirectoryW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsDirectory64([MarshalAs(UnmanagedType.LPWStr)] string FolderName);

        [DllImport("Swelio64.dll", EntryPoint = "IsEIDCardEx", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsEIDCardEx64(int readerNumber);

        [DllImport("Swelio64.dll", EntryPoint = "IsEngineActive", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsEngineActive64();

        [DllImport("Swelio64.dll", EntryPoint = "IsMaleW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsMale64([In, Out] EIDIdentity Identity);

        [DllImport("Swelio64.dll", EntryPoint = "IsMediaCenter", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsMediaCenter64();

        [DllImport("Swelio64.dll", EntryPoint = "IsMetroActive", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsMetroActive64();

        [DllImport("Swelio64.dll", EntryPoint = "IsMultiTouchReady", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsMultiTouchReady64();

        [DllImport("Swelio64.dll", EntryPoint = "IsTabletPC", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsTabletPC64();

        [DllImport("Swelio64.dll", EntryPoint = "IsUnicodeFileW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsUnicodeFile64([MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport("Swelio64.dll", EntryPoint = "IsValidFileNameW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsValidFileName64([MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport("Swelio64.dll", EntryPoint = "IsValidPathNameW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsValidPathName64([MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport("Swelio64.dll", EntryPoint = "IsWindows7", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWindows764();

        [DllImport("Swelio64.dll", EntryPoint = "IsWindows10", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWindows1064();

        [DllImport("Swelio64.dll", EntryPoint = "IsWindows8", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWindows864();

        [DllImport("Swelio64.dll", EntryPoint = "IsWindowsVista", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWindowsVista64();

        [DllImport("Swelio64.dll", EntryPoint = "IsWindowsXP", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWindowsXP64();

        [DllImport("Swelio64.dll", EntryPoint = "LoadCertificateW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void LoadCertificate64([MarshalAs(UnmanagedType.LPWStr)] string fileName, [In, Out] EIDCertificate Certificate);

        [DllImport("Swelio64.dll", EntryPoint = "PortAvailable", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool PortAvailable64(int portNumber);

        [DllImport("Swelio64.dll", EntryPoint = "GetCardSerialNumber", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetCardSerialNumber64(int readerNumber, byte[] serialNumber, ref int serialNumberSize);

        [DllImport("Swelio64.dll", EntryPoint = "ReadAddressExW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ReadAddressEx64(int readerNumber, [In, Out] EIDAddress address);

        [DllImport("Swelio64.dll", EntryPoint = "ReadIdentityExW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ReadIdentityEx64(int readerNumber, [In, Out] EIDIdentity identity);

        [DllImport("Swelio64.dll", EntryPoint = "ReadPhotoEx", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ReadPhotoEx64(int readerNumber, [In, Out] EIDPicture Photo);

        [DllImport("Swelio64.dll", EntryPoint = "ReloadReadersList", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void ReloadReadersList64();

        [DllImport("Swelio64.dll", EntryPoint = "RemoveCallback", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void RemoveCallback64();

        [DllImport("Swelio64.dll", EntryPoint = "RemoveStartupW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void RemoveStartup64([MarshalAs(UnmanagedType.LPWStr)] string AppName);

        [DllImport("Swelio64.dll", EntryPoint = "SaveCardToXmlExW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SaveCardToXmlEx64(int readerNumber, [MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport("Swelio64.dll", EntryPoint = "SavePersonToCsvExW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SavePersonToCsvEx64(int readerNumber, [MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport("Swelio64.dll", EntryPoint = "SaveCardToXmlExA", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SaveCardToXmlExAnsi64(int readerNumber, [MarshalAs(UnmanagedType.LPStr)] string fileName);

        [DllImport("Swelio64.dll", EntryPoint = "SavePersonToCsvExA", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SavePersonToCsvExAnsi64(int readerNumber, [MarshalAs(UnmanagedType.LPStr)] string fileName);

        [DllImport("Swelio64.dll", EntryPoint = "SavePhotoAsBitmapExW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SavePhotoAsBitmapEx64(int readerNumber, [MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport("Swelio64.dll", EntryPoint = "SavePhotoAsJpegExW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SavePhotoAsJpegEx64(int readerNumber, [MarshalAs(UnmanagedType.LPWStr)] string fileName);

        [DllImport("Swelio64.dll", EntryPoint = "SelectReader", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SelectReader64(int readerNumber);

        [DllImport("Swelio64.dll", EntryPoint = "SelectReaderByNameW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SelectReaderByName64([MarshalAs(UnmanagedType.LPWStr)] string ReaderName);

        [DllImport("Swelio64.dll", EntryPoint = "SetCallback", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void SetCallback64(ReaderCallbackDelegate callback, IntPtr userContext);

        [DllImport("Swelio64.dll", EntryPoint = "SetStartupW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void SetStartup64([MarshalAs(UnmanagedType.LPWStr)] string AppName, [MarshalAs(UnmanagedType.LPWStr)] string AppPath);

        [DllImport("Swelio64.dll", EntryPoint = "ShellCopyFileW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void ShellCopyFile64([MarshalAs(UnmanagedType.LPWStr)] string oldName, [MarshalAs(UnmanagedType.LPWStr)] string NewName);

        [DllImport("Swelio64.dll", EntryPoint = "ShowError", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void ShowError64(int ErrorCode);

        [DllImport("Swelio64.dll", EntryPoint = "ShutdownWindows", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ShutdownWindows64(int Flags);

        [DllImport("Swelio64.dll", EntryPoint = "StartEngine", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool StartEngine64();

        [DllImport("Swelio64.dll", EntryPoint = "StopEngine", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void StopEngine64();

        [DllImport("Swelio64.dll", EntryPoint = "StripFileNameW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void StripFileName64([MarshalAs(UnmanagedType.LPWStr)] string fileName, StringBuilder sb);

        [DllImport("Swelio64.dll", EntryPoint = "SuspendWindows", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SuspendWindows64();

        [DllImport("Swelio64.dll", EntryPoint = "TurnMonitorOff", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void TurnMonitorOff64();

        [DllImport("Swelio64.dll", EntryPoint = "TurnMonitorOn", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void TurnMonitorOn64();

        [DllImport("Swelio64.dll", EntryPoint = "VerifyPinExW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool VerifyPinEx64(int readerNumber, [MarshalAs(UnmanagedType.LPWStr)] string Value);

        [DllImport("Swelio64.dll", EntryPoint = "VerifySignature", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool VerifySignature64([In, Out] EIDCertificate Certificate, byte[] dataHash, int hashSize, byte[] signature, int signatureSize);

        [DllImport("Swelio64.dll", EntryPoint = "SaveAuthenticationCertificateExW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void SaveAuthenticationCertificateEx64([MarshalAs(UnmanagedType.LPWStr)] string fileName, int readerNumber);

        [DllImport("Swelio64.dll", EntryPoint = "SaveCaCertificateExW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void SaveCaCertificateEx64([MarshalAs(UnmanagedType.LPWStr)] string fileName, int readerNumber);

        [DllImport("Swelio64.dll", EntryPoint = "SaveNonRepudiationCertificateExW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void SaveNonRepudiationCertificateEx64([MarshalAs(UnmanagedType.LPWStr)] string fileName, int readerNumber);

        [DllImport("Swelio64.dll", EntryPoint = "SaveRootCaCertificateExW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void SaveRootCaCertificateEx64([MarshalAs(UnmanagedType.LPWStr)] string fileName, int readerNumber);

        [DllImport("Swelio64.dll", EntryPoint = "SaveRrnCertificateExW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void SaveRrnCertificateEx64([MarshalAs(UnmanagedType.LPWStr)] string fileName, int readerNumber);


        [DllImport("Swelio64.dll", EntryPoint = "SaveCardToToXMLStreamExW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SaveCardToToXMLStreamExW64(int readerNumber, IntPtr buffer);

        [DllImport("Swelio64.dll", EntryPoint = "SaveCardToToXMLStreamExA", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SaveCardToToXMLStreamExA64(int readerNumber, IntPtr buffer);

        [DllImport("Swelio64.dll", EntryPoint = "GetCardBufferSize", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern int GetCardBufferSize64(IntPtr buffer);

        [DllImport("Swelio64.dll", EntryPoint = "GetCardBufferA", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
        private static extern void GetCardBufferA64(IntPtr buffer, StringBuilder strDest, int count);

        [DllImport("Swelio64.dll", EntryPoint = "GetCardBufferW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void GetCardBufferW64(IntPtr buffer, StringBuilder strDest, int count);

        [DllImport("Swelio64.dll", EntryPoint = "DeleteCardBuffer", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void DeleteCardBuffer64(IntPtr buffer);

        [DllImport("Swelio64.dll", EntryPoint = "CreateCardBuffer", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern IntPtr CreateCardBuffer64();

        [DllImport("Swelio64.dll", EntryPoint = "SavePersonCsvToStreamW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SavePersonCsvToStreamW64(int readerNumber, IntPtr buffer);

        [DllImport("Swelio64.dll", EntryPoint = "SavePersonCsvToStreamA", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SavePersonCsvToStreamA64(int readerNumber, IntPtr buffer);

        public static bool SendAPDU(int readerNumber, byte[] apdu, int apduLen, byte[] result, ref int len)
        {
            if (IsWOW64())
            {
                return SendAPDU64(readerNumber, apdu, apduLen, result, ref len);
            }
            else
            {
                return SendAPDU32(readerNumber, apdu, apduLen, result, ref len);
            }
        }

        public static bool IsCardActivatedEx(int readerNumber)
        {
            if (IsWOW64())
            {
                return IsCardActivatedEx64(readerNumber);
            }
            else
            {
                return IsCardActivatedEx32(readerNumber);
            }
        }

        public static bool IsCardStillInsertedEx(int readerNumber)
        {
            if (IsWOW64())
            {
                return IsCardStillInsertedEx64(readerNumber);
            }
            else
            {
                return IsCardStillInsertedEx32(readerNumber);
            }
        }

        public static bool FileIsLink(string fileName)
        {
            if (IsWOW64())
            {
                return FileIsLink64(fileName);
            }
            else
            {
                return FileIsLink32(fileName);
            }
        }

        public static bool RecycleBinEmpty()
        {
            if (IsWOW64())
            {
                return RecycleBinEmpty64();
            }
            else
            {
                return RecycleBinEmpty32();
            }
        }



        public static bool ActivateCardEx(int readerNumber)
        {
            if (IsWOW64())
            {
                return ActivateCardEx64(readerNumber);
            }
            else
            {
                return ActivateCardEx32(readerNumber);
            }
        }


        public static bool CardDecryptFile(string source, string destination)
        {
            if (IsWOW64())
            {
                return CardDecryptFile64(source, destination);
            }
            else
            {
                return CardDecryptFile32(source, destination);
            }
        }



        public static bool CardEncryptFile(string source, string destination)
        {
            if (IsWOW64())
            {
                return CardEncryptFile64(source, destination);
            }
            else
            {
                return CardEncryptFile32(source, destination);
            }
        }

        public static bool CheckMD5(byte[] source, int sourceSize, byte[] buffer, int bufferSize)
        {
            if (IsWOW64())
            {
                return CheckMD564(source, sourceSize, buffer, bufferSize);
            }
            else
            {
                return CheckMD532(source, sourceSize, buffer, bufferSize);
            }
        }

        public static bool CheckSHA1(byte[] source, int sourceSize, byte[] buffer, int bufferSize)
        {
            if (IsWOW64())
            {
                return CheckSHA164(source, sourceSize, buffer, bufferSize);
            }
            else
            {
                return CheckSHA132(source, sourceSize, buffer, bufferSize);
            }
        }


        public static void ClearFileAttributes(string fileName)
        {
            if (IsWOW64())
            {
                ClearFileAttributes64(fileName);
            }
            else
            {
                ClearFileAttributes32(fileName);
            }
        }


        public static void ClearUnusedMemory()
        {
            if (IsWOW64())
            {
                ClearUnusedMemory64();
            }
            else
            {
                ClearUnusedMemory32();
            }
        }


        public static void CreateUnicodeFile(string fileName)
        {
            if (IsWOW64())
            {
                CreateUnicodeFile64(fileName);
            }
            else
            {
                CreateUnicodeFile32(fileName);
            }
        }


        public static void CurrentIPAddress(StringBuilder address, uint bufferSize)
        {
            if (IsWOW64())
            {
                CurrentIPAddress64(address, bufferSize);
            }
            else
            {
                CurrentIPAddress32(address, bufferSize);
            }
        }


        public static void DeactivateCardEx(int readerNumber)
        {
            if (IsWOW64())
            {
                DeactivateCardEx64(readerNumber);
            }
            else
            {
                DeactivateCardEx32(readerNumber);
            }
        }



        public static bool DecryptFileAES(string source, string destination, string password)
        {
            if (IsWOW64())
            {
                return DecryptFileAES64(source, destination, password);
            }
            else
            {
                return DecryptFileAES32(source, destination, password);
            }
        }


        public static void DeleteToRecycleBin(string fileName, bool silent)
        {
            if (IsWOW64())
            {
                DeleteToRecycleBin64(fileName, silent);
            }
            else
            {
                DeleteToRecycleBin32(fileName, silent);
            }
        }

        public static bool DirectoryExists(string fileName)
        {
            if (IsWOW64())
            {
                return DirectoryExists64(fileName);
            }
            else
            {
                return DirectoryExists32(fileName);
            }
        }


        public static void DisplayCertificate([In, Out] EIDCertificate certificate)
        {
            if (IsWOW64())
            {
                DisplayCertificate64(certificate);
            }
            else
            {
                DisplayCertificate32(certificate);
            }
        }


        public static bool ReadAuthenticationCertificate([In, Out] EIDCertificate certificate)
        {
            if (IsWOW64())
            {
                return ReadAuthenticationCertificate64(certificate);
            }
            else
            {
                return ReadAuthenticationCertificate32(certificate);
            }
        }


        public static bool ReadNonRepudiationCertificate([In, Out] EIDCertificate certificate)
        {
            if (IsWOW64())
            {
                return ReadNonRepudiationCertificate64(certificate);
            }
            else
            {
                return ReadNonRepudiationCertificate32(certificate);
            }
        }


        public static bool ReadCaCertificate([In, Out] EIDCertificate certificate)
        {
            if (IsWOW64())
            {
                return ReadCaCertificate64(certificate);
            }
            else
            {
                return ReadCaCertificate32(certificate);
            }
        }


        public static bool ReadRootCaCertificate([In, Out] EIDCertificate certificate)
        {
            if (IsWOW64())
            {
                return ReadRootCaCertificate64(certificate);
            }
            else
            {
                return ReadRootCaCertificate32(certificate);
            }
        }


        public static bool ReadRrnCertificate([In, Out] EIDCertificate certificate)
        {
            if (IsWOW64())
            {
                return ReadRrnCertificate64(certificate);
            }
            else
            {
                return ReadRrnCertificate32(certificate);
            }
        }

        public static void EmptyRecycleBin()
        {
            if (IsWOW64())
            {
                EmptyRecycleBin64();
            }
            else
            {
                EmptyRecycleBin32();
            }
        }


        public static int EncodeCertificate([In, Out] EIDCertificate certificate, byte[] buffer, int bufferSize)
        {
            if (IsWOW64())
            {
                return EncodeCertificate64(certificate, buffer, bufferSize);
            }
            else
            {
                return EncodeCertificate32(certificate, buffer, bufferSize);
            }
        }


        public static int EncodePhoto([In, Out] EIDPicture photo, byte[] buffer, int bufferSize)
        {
            if (IsWOW64())
            {
                return EncodePhoto64(photo, buffer, bufferSize);
            }
            else
            {
                return EncodePhoto32(photo, buffer, bufferSize);
            }
        }


        public static void LoadPhoto([In, Out] EIDPicture photo, string fileName)
        {
            if (IsWOW64())
            {
                LoadPhoto64(photo, fileName);
            }
            else
            {
                LoadPhoto32(photo, fileName);
            }
        }

        public static bool EncryptFileAES(string source, string destination, string password)
        {
            if (IsWOW64())
            {
                return EncryptFileAES64(source, destination, password);
            }
            else
            {
                return EncryptFileAES32(source, destination, password);
            }
        }

        public static bool FileCopy(string oldName, string newName)
        {
            if (IsWOW64())
            {
                return FileCopy64(oldName, newName);
            }
            else
            {
                return FileCopy32(oldName, newName);
            }
        }

        public static void FileDelete(string fileName)
        {
            if (IsWOW64())
            {
                FileDelete64(fileName);
            }
            else
            {
                FileDelete32(fileName);
            }
        }

        public static bool FileExists(string fileName)
        {
            if (IsWOW64())
            {
                return FileExists64(fileName);
            }
            else
            {
                return FileExists32(fileName);
            }
        }

        public static bool FileExtensionIs(string fileName, string extension)
        {
            if (IsWOW64())
            {
                return FileExtensionIs64(fileName, extension);
            }
            else
            {
                return FileExtensionIs32(fileName, extension);
            }
        }

        public static int FileGetSize(string fileName)
        {
            if (IsWOW64())
            {
                return FileGetSize64(fileName);
            }
            else
            {
                return FileGetSize32(fileName);
            }
        }

        public static bool FileIsExe(string fileName)
        {
            if (IsWOW64())
            {
                return FileIsExe64(fileName);
            }
            else
            {
                return FileIsExe32(fileName);
            }
        }



        public static bool FileIsIcon(string fileName)
        {
            if (IsWOW64())
            {
                return FileIsIcon64(fileName);
            }
            else
            {
                return FileIsIcon32(fileName);
            }
        }

        public static bool FileIsImage(string fileName)
        {
            if (IsWOW64())
            {
                return FileIsImage64(fileName);
            }
            else
            {
                return FileIsImage32(fileName);
            }
        }


        public static bool FileOrFolderExists(string fileName)
        {
            if (IsWOW64())
            {
                return FileOrFolderExists64(fileName);
            }
            else
            {
                return FileOrFolderExists32(fileName);
            }
        }

        public static bool FileRename(string oldName, string newName)
        {
            if (IsWOW64())
            {
                return FileRename64(oldName, newName);
            }
            else
            {
                return FileRename32(oldName, newName);
            }
        }


        public static bool FullPath(string fileName, StringBuilder sb)
        {
            if (IsWOW64())
            {
                return FullPath64(fileName, sb);
            }
            else
            {
                return FullPath32(fileName, sb);
            }
        }


        public static void GenerateBMP(string fileName, string Text, int Margin, int Size, int Level)
        {
            if (IsWOW64())
            {
                GenerateBMP64(fileName, Text, Margin, Size, Level);
            }
            else
            {
                GenerateBMP32(fileName, Text, Margin, Size, Level);
            }
        }

        public static bool GenerateAuthenticationSignatureEx(int readerNumber, string pinCode, byte[] dataHash, int hashSize, byte[] signature, ref int signatureSize)
        {
            if (IsWOW64())
            {
                return GenerateAuthenticationSignatureEx64(readerNumber, pinCode, dataHash, hashSize, signature, ref signatureSize);
            }
            else
            {
                return GenerateAuthenticationSignatureEx32(readerNumber, pinCode, dataHash, hashSize, signature, ref signatureSize);
            }
        }


        public static bool GenerateNonRepudiationSignatureEx(int readerNumber, string pinCode, byte[] dataHash, int hashSize, byte[] signature, ref int signatureSize)
        {
            if (IsWOW64())
            {
                return GenerateNonRepudiationSignatureEx64(readerNumber, pinCode, dataHash, hashSize, signature, ref signatureSize);
            }
            else
            {
                return GenerateNonRepudiationSignatureEx32(readerNumber, pinCode, dataHash, hashSize, signature, ref signatureSize);
            }
        }


        public static void GeneratePNG(string fileName, string Text, int Margin, int Size, int Level)
        {
            if (IsWOW64())
            {
                GeneratePNG64(fileName, Text, Margin, Size, Level);
            }
            else
            {
                GeneratePNG32(fileName, Text, Margin, Size, Level);
            }
        }

        public static bool GenerateQRCodeEx(int readerNumber, string fileName)
        {
            if (IsWOW64())
            {
                return GenerateQRCodeEx64(readerNumber, fileName);
            }
            else
            {
                return GenerateQRCodeEx32(readerNumber, fileName);
            }
        }


        public static int GetEncodedCertificateSize([In, Out] EIDCertificate Certificate)
        {
            if (IsWOW64())
            {
                return GetEncodedCertificateSize64(Certificate);
            }
            else
            {
                return GetEncodedCertificateSize32(Certificate);
            }
        }


        public static int GetEncodedPhotoSize([In, Out] EIDPicture Photo)
        {
            if (IsWOW64())
            {
                return GetEncodedPhotoSize64(Photo);
            }
            else
            {
                return GetEncodedPhotoSize32(Photo);
            }
        }


        public static int GetFilesCount(string FolderName)
        {
            if (IsWOW64())
            {
                return GetFilesCount64(FolderName);
            }
            else
            {
                return GetFilesCount32(FolderName);
            }
        }


        public static IntPtr GetHBitmap(string Text, int Margin, int Size, int Level)
        {
            if (IsWOW64())
            {
                return GetHBitmap64(Text, Margin, Size, Level);
            }
            else
            {
                return GetHBitmap32(Text, Margin, Size, Level);
            }
        }



        public static bool GetISOCode(string Nationality, StringBuilder IsoCode, int BufferSize)
        {
            if (IsWOW64())
            {
                return GetISOCode64(Nationality, IsoCode, BufferSize);
            }
            else
            {
                return GetISOCode32(Nationality, IsoCode, BufferSize);
            }
        }



        public static bool GetMD5(byte[] source, int sourceSize, byte[] buffer, int bufferSize)
        {
            if (IsWOW64())
            {
                return GetMD564(source, sourceSize, buffer, bufferSize);
            }
            else
            {
                return GetMD532(source, sourceSize, buffer, bufferSize);
            }
        }



        public static bool GetSHA1(byte[] source, int sourceSize, byte[] buffer, int bufferSize)
        {
            if (IsWOW64())
            {
                return GetSHA164(source, sourceSize, buffer, bufferSize);
            }
            else
            {
                return GetSHA132(source, sourceSize, buffer, bufferSize);
            }
        }

        public static bool GetFileSHA1(string fileName, byte[] buffer, int bufferSize)
        {
            if (IsWOW64())
            {
                return GetFileSHA164(fileName, buffer, bufferSize);
            }
            else
            {
                return GetFileSHA132(fileName, buffer, bufferSize);
            }
        }


        public static bool GetFileMD5(string fileName, byte[] buffer, int bufferSize)
        {
            if (IsWOW64())
            {
                return GetFileMD564(fileName, buffer, bufferSize);
            }
            else
            {
                return GetFileMD532(fileName, buffer, bufferSize);
            }
        }


        public static int GetReaderIndex(string ReaderName)
        {
            if (IsWOW64())
            {
                return GetReaderIndex64(ReaderName);
            }
            else
            {
                return GetReaderIndex32(ReaderName);
            }
        }


        public static int GetReaderName(int readerNumber, StringBuilder StrDest, int Count)
        {
            if (IsWOW64())
            {
                return GetReaderName64(readerNumber, StrDest, Count);
            }
            else
            {
                return GetReaderName32(readerNumber, StrDest, Count);
            }
        }


        public static int GetReaderNameLen(int readerNumber)
        {
            if (IsWOW64())
            {
                return GetReaderNameLen64(readerNumber);
            }
            else
            {
                return GetReaderNameLen32(readerNumber);
            }
        }


        public static int GetReadersCount()
        {
            if (IsWOW64())
            {
                return GetReadersCount64();
            }
            else
            {
                return GetReadersCount32();
            }
        }

        public static int GetSelectedReaderIndex()
        {
            if (IsWOW64())
            {
                return GetSelectedReaderIndex64();
            }
            else
            {
                return GetSelectedReaderIndex32();
            }
        }

        public static bool GetStartup(string AppName)
        {
            if (IsWOW64())
            {
                return GetStartup64(AppName);
            }
            else
            {
                return GetStartup32(AppName);
            }
        }



        public static bool HibernateWindows()
        {
            if (IsWOW64())
            {
                return HibernateWindows64();
            }
            else
            {
                return HibernateWindows32();
            }
        }

        public static bool IsAnimatedGIF(string fileName)
        {
            if (IsWOW64())
            {
                return IsAnimatedGIF64(fileName);
            }
            else
            {
                return IsAnimatedGIF32(fileName);
            }
        }


        public static bool IsCardPresentEx(int readerNumber)
        {
            if (IsWOW64())
            {
                return IsCardPresentEx64(readerNumber);
            }
            else
            {
                return IsCardPresentEx32(readerNumber);
            }
        }



        public static bool IsConnectedToInternet()
        {
            if (IsWOW64())
            {
                return IsConnectedToInternet64();
            }
            else
            {
                return IsConnectedToInternet32();
            }
        }



        public static bool IsDirectory(string FolderName)
        {
            if (IsWOW64())
            {
                return IsDirectory64(FolderName);
            }
            else
            {
                return IsDirectory32(FolderName);
            }
        }



        public static bool IsEIDCardEx(int readerNumber)
        {
            if (IsWOW64())
            {
                return IsEIDCardEx64(readerNumber);
            }
            else
            {
                return IsEIDCardEx32(readerNumber);
            }
        }



        public static bool IsEngineActive()
        {
            if (IsWOW64())
            {
                return IsEngineActive64();
            }
            else
            {
                return IsEngineActive32();
            }
        }



        public static bool IsMale([In, Out] EIDIdentity Identity)
        {
            if (IsWOW64())
            {
                return IsMale64(Identity);
            }
            else
            {
                return IsMale32(Identity);
            }
        }



        public static bool IsMediaCenter()
        {
            if (IsWOW64())
            {
                return IsMediaCenter64();
            }
            else
            {
                return IsMediaCenter32();
            }
        }



        public static bool IsMetroActive()
        {
            if (IsWOW64())
            {
                return IsMetroActive64();
            }
            else
            {
                return IsMetroActive32();
            }
        }



        public static bool IsMultiTouchReady()
        {
            if (IsWOW64())
            {
                return IsMultiTouchReady64();
            }
            else
            {
                return IsMultiTouchReady32();
            }
        }



        public static bool IsTabletPC()
        {
            if (IsWOW64())
            {
                return IsTabletPC64();
            }
            else
            {
                return IsTabletPC32();
            }
        }



        public static bool IsUnicodeFile(string fileName)
        {
            if (IsWOW64())
            {
                return IsUnicodeFile64(fileName);
            }
            else
            {
                return IsUnicodeFile32(fileName);
            }
        }



        public static bool IsValidFileName(string fileName)
        {
            if (IsWOW64())
            {
                return IsValidFileName64(fileName);
            }
            else
            {
                return IsValidFileName32(fileName);
            }
        }

        public static bool IsValidPathName(string fileName)
        {
            if (IsWOW64())
            {
                return IsValidPathName64(fileName);
            }
            else
            {
                return IsValidPathName32(fileName);
            }
        }

        public static bool IsWindows7()
        {
            if (IsWOW64())
            {
                return IsWindows764();
            }
            else
            {
                return IsWindows732();
            }
        }

        public static bool IsWindows10()
        {
            if (IsWOW64())
            {
                return IsWindows1064();
            }
            else
            {
                return IsWindows1032();
            }
        }

        public static bool IsWindows8()
        {
            if (IsWOW64())
            {
                return IsWindows864();
            }
            else
            {
                return IsWindows832();
            }
        }

        public static bool IsWindowsVista()
        {
            if (IsWOW64())
            {
                return IsWindowsVista64();
            }
            else
            {
                return IsWindowsVista32();
            }
        }

        public static bool IsWindowsXP()
        {
            if (IsWOW64())
            {
                return IsWindowsXP64();
            }
            else
            {
                return IsWindowsXP32();
            }
        }


        public static void LoadCertificate(string fileName, [In, Out] EIDCertificate Certificate)
        {
            if (IsWOW64())
            {
                LoadCertificate64(fileName, Certificate);
            }
            else
            {
                LoadCertificate32(fileName, Certificate);
            }
        }

        public static bool PortAvailable(int portNumber)
        {
            if (IsWOW64())
            {
                return PortAvailable64(portNumber);
            }
            else
            {
                return PortAvailable32(portNumber);
            }
        }

        public static bool GetCardSerialNumber(int readerNumber, byte[] serialNumber, ref int serialNumberSize)
        {
            if (IsWOW64())
            {
                return GetCardSerialNumber64(readerNumber, serialNumber, ref serialNumberSize);
            }
            else
            {
                return GetCardSerialNumber32(readerNumber, serialNumber, ref serialNumberSize);
            }
        }

        public static bool ReadAddressEx(int readerNumber, [In, Out] EIDAddress address)
        {
            if (IsWOW64())
            {
                return ReadAddressEx64(readerNumber, address);
            }
            else
            {
                return ReadAddressEx32(readerNumber, address);
            }
        }



        public static bool ReadIdentityEx(int readerNumber, [In, Out] EIDIdentity identity)
        {
            if (IsWOW64())
            {
                return ReadIdentityEx64(readerNumber, identity);
            }
            else
            {
                return ReadIdentityEx32(readerNumber, identity);
            }
        }



        public static bool ReadPhotoEx(int readerNumber, [In, Out] EIDPicture Photo)
        {
            if (IsWOW64())
            {
                return ReadPhotoEx64(readerNumber, Photo);
            }
            else
            {
                return ReadPhotoEx32(readerNumber, Photo);
            }
        }


        public static void ReloadReadersList()
        {
            if (IsWOW64())
            {
                ReloadReadersList64();
            }
            else
            {
                ReloadReadersList32();
            }
        }

        public static void RemoveCallback()
        {
            if (IsWOW64())
            {
                RemoveCallback64();
            }
            else
            {
                RemoveCallback32();
            }
        }


        public static void RemoveStartup(string AppName)
        {
            if (IsWOW64())
            {
                RemoveStartup64(AppName);
            }
            else
            {
                RemoveStartup32(AppName);
            }
        }


        public static bool SaveCardToXmlEx(int readerNumber, string fileName)
        {
            if (IsWOW64())
            {
                return SaveCardToXmlEx64(readerNumber, fileName);
            }
            else
            {
                return SaveCardToXmlEx32(readerNumber, fileName);
            }
        }



        public static bool SavePersonToCsvEx(int readerNumber, string fileName)
        {
            if (IsWOW64())
            {
                return SavePersonToCsvEx64(readerNumber, fileName);
            }
            else
            {
                return SavePersonToCsvEx32(readerNumber, fileName);
            }
        }



        public static bool SaveCardToXmlExAnsi(int readerNumber, string fileName)
        {
            if (IsWOW64())
            {
                return SaveCardToXmlExAnsi64(readerNumber, fileName);
            }
            else
            {
                return SaveCardToXmlExAnsi32(readerNumber, fileName);
            }
        }


        public static bool SavePersonToCsvExAnsi(int readerNumber, string fileName)
        {
            if (IsWOW64())
            {
                return SavePersonToCsvExAnsi64(readerNumber, fileName);
            }
            else
            {
                return SavePersonToCsvExAnsi32(readerNumber, fileName);
            }
        }



        public static bool SavePhotoAsBitmapEx(int readerNumber, string fileName)
        {
            if (IsWOW64())
            {
                return SavePhotoAsBitmapEx64(readerNumber, fileName);
            }
            else
            {
                return SavePhotoAsBitmapEx32(readerNumber, fileName);
            }
        }


        public static bool SavePhotoAsJpegEx(int readerNumber, string fileName)
        {
            if (IsWOW64())
            {
                return SavePhotoAsJpegEx64(readerNumber, fileName);
            }
            else
            {
                return SavePhotoAsJpegEx32(readerNumber, fileName);
            }
        }



        public static bool SelectReader(int readerNumber)
        {
            if (IsWOW64())
            {
                return SelectReader64(readerNumber);
            }
            else
            {
                return SelectReader32(readerNumber);
            }
        }


        public static bool SelectReaderByName(string ReaderName)
        {
            if (IsWOW64())
            {
                return SelectReaderByName64(ReaderName);
            }
            else
            {
                return SelectReaderByName32(ReaderName);
            }
        }


        public static void SetCallback(ReaderCallbackDelegate callback, IntPtr userContext)
        {
            if (IsWOW64())
            {
                SetCallback64(callback, userContext);
            }
            else
            {
                SetCallback32(callback, userContext);
            }
        }


        public static void SetStartup(string AppName, string AppPath)
        {
            if (IsWOW64())
            {
                SetStartup64(AppName, AppPath);
            }
            else
            {
                SetStartup32(AppName, AppPath);
            }
        }

        public static void ShellCopyFile(string oldName, string NewName)
        {
            if (IsWOW64())
            {
                ShellCopyFile64(oldName, NewName);
            }
            else
            {
                ShellCopyFile32(oldName, NewName);
            }
        }


        public static void ShowError(int errorCode)
        {
            if (IsWOW64())
            {
                ShowError64(errorCode);
            }
            else
            {
                ShowError32(errorCode);
            }
        }


        public static bool ShutdownWindows(int Flags)
        {
            if (IsWOW64())
            {
                return ShutdownWindows64(Flags);
            }
            else
            {
                return ShutdownWindows32(Flags);
            }
        }


        public static bool StartEngine()
        {
            if (IsWOW64())
            {
                return StartEngine64();
            }
            else
            {
                return StartEngine32();
            }
        }


        public static void StopEngine()
        {
            if (IsWOW64())
            {
                StopEngine64();
            }
            else
            {
                StopEngine32();
            }
        }


        public static void StripFileName(string fileName, StringBuilder sb)
        {
            if (IsWOW64())
            {
                StripFileName64(fileName, sb);
            }
            else
            {
                StripFileName32(fileName, sb);
            }
        }



        public static bool SuspendWindows()
        {
            if (IsWOW64())
            {
                return SuspendWindows64();
            }
            else
            {
                return SuspendWindows32();
            }
        }


        public static void TurnMonitorOff()
        {
            if (IsWOW64())
            {
                TurnMonitorOff64();
            }
            else
            {
                TurnMonitorOff32();
            }
        }


        public static void TurnMonitorOn()
        {
            if (IsWOW64())
            {
                TurnMonitorOn64();
            }
            else
            {
                TurnMonitorOn32();
            }
        }



        public static bool VerifyPinEx(int readerNumber, string Value)
        {
            if (IsWOW64())
            {
                return VerifyPinEx64(readerNumber, Value);
            }
            else
            {
                return VerifyPinEx32(readerNumber, Value);
            }
        }



        public static bool VerifySignature([In, Out] EIDCertificate Certificate, byte[] dataHash, int hashSize, byte[] signature, int signatureSize)
        {
            if (IsWOW64())
            {
                return VerifySignature64(Certificate, dataHash, hashSize, signature, signatureSize);
            }
            else
            {
                return VerifySignature32(Certificate, dataHash, hashSize, signature, signatureSize);
            }
        }


        public static void SaveAuthenticationCertificateEx(string fileName, int readerNumber)
        {
            if (IsWOW64())
            {
                SaveAuthenticationCertificateEx64(fileName, readerNumber);
            }
            else
            {
                SaveAuthenticationCertificateEx32(fileName, readerNumber);
            }
        }


        public static void SaveCaCertificateEx(string fileName, int readerNumber)
        {
            if (IsWOW64())
            {
                SaveCaCertificateEx64(fileName, readerNumber);
            }
            else
            {
                SaveCaCertificateEx32(fileName, readerNumber);
            }
        }


        public static void SaveNonRepudiationCertificateEx(string fileName, int readerNumber)
        {
            if (IsWOW64())
            {
                SaveNonRepudiationCertificateEx64(fileName, readerNumber);
            }
            else
            {
                SaveNonRepudiationCertificateEx32(fileName, readerNumber);
            }
        }


        public static void SaveRootCaCertificateEx(string fileName, int readerNumber)
        {
            if (IsWOW64())
            {
                SaveRootCaCertificateEx64(fileName, readerNumber);
            }
            else
            {
                SaveRootCaCertificateEx32(fileName, readerNumber);
            }
        }


        public static void SaveRrnCertificateEx(string fileName, int readerNumber)
        {
            if (IsWOW64())
            {
                SaveRrnCertificateEx64(fileName, readerNumber);
            }
            else
            {
                SaveRrnCertificateEx32(fileName, readerNumber);
            }
        }


        public static bool SaveCardToToXMLStreamExW(int readerNumber, IntPtr buffer)
        {
            if (IsWOW64())
            {
                return SaveCardToToXMLStreamExW64(readerNumber, buffer);
            }
            else
            {
                return SaveCardToToXMLStreamExW32(readerNumber, buffer);
            }
        }

        public static bool SaveCardToToXMLStreamExA(int readerNumber, IntPtr buffer)
        {
            if (IsWOW64())
            {
                return SaveCardToToXMLStreamExA64(readerNumber, buffer);
            }
            else
            {
                return SaveCardToToXMLStreamExA32(readerNumber, buffer);
            }
        }

        public static int GetCardBufferSize(IntPtr buffer)
        {
            if (IsWOW64())
            {
                return GetCardBufferSize64(buffer);
            }
            else
            {
                return GetCardBufferSize32(buffer);
            }
        }

        public static void GetCardBufferA(IntPtr buffer, StringBuilder strDest, int count)
        {
            if (IsWOW64())
            {
                GetCardBufferA64(buffer, strDest, count);
            }
            else
            {
                GetCardBufferA32(buffer, strDest, count);
            }
        }

        public static void GetCardBufferW(IntPtr buffer, StringBuilder strDest, int count)
        {
            if (IsWOW64())
            {
                GetCardBufferW64(buffer, strDest, count);
            }
            else
            {
                GetCardBufferW32(buffer, strDest, count);
            }
        }

        public static void DeleteCardBuffer(IntPtr buffer)
        {
            if (IsWOW64())
            {
                DeleteCardBuffer64(buffer);
            }
            else
            {
                DeleteCardBuffer32(buffer);
            }
        }

        public static IntPtr CreateCardBuffer()
        {
            if (IsWOW64())
            {
                return CreateCardBuffer64();
            }
            else
            {
                return CreateCardBuffer32();
            }
        }

        public static bool SavePersonCsvToStreamW(int readerNumber, IntPtr buffer)
        {
            if (IsWOW64())
            {
                return SavePersonCsvToStreamW64(readerNumber, buffer);
            }
            else
            {
                return SavePersonCsvToStreamW32(readerNumber, buffer);
            }
        }

        public static bool SavePersonCsvToStreamA(int readerNumber, IntPtr buffer)
        {
            if (IsWOW64())
            {
                return SavePersonCsvToStreamA64(readerNumber, buffer);
            }
            else
            {
                return SavePersonCsvToStreamA32(readerNumber, buffer);
            }
        }


    }



}
