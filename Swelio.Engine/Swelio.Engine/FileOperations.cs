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
using System.IO;
using System.Runtime.InteropServices;

namespace Swelio.Engine
{

    /// <summary>
    /// Helper class for common file oprations
    /// </summary>
    public static class FileOperations
    {

        public static bool IsUnicodeFile(string fileName)
        {
            return NativeMethods.IsUnicodeFile(fileName);
        }

        public static void CreateUnicodeFile(string fileName)
        {
            NativeMethods.CreateUnicodeFile(fileName);
        }

        public static int GetFilesCount(string folderName)
        {
            return NativeMethods.GetFilesCount(folderName);
        }

        public static int GetFileSize(string fileName)
        {
            return NativeMethods.FileGetSize(fileName);
        }

        /// <summary>
        /// If file exists in the current folder then this method simply returns the file name.
        /// if not, it will search the file with provided name in every folder, specified in the system
        /// search path. 
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>Returns the full file name including the full path to it</returns>
        public static string FullPath(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return string.Empty;

            // search machine
            StringBuilder sb = new StringBuilder(260);
            if (NativeMethods.FullPath(fileName, sb))
                return sb.ToString();
            else
                return fileName;
        }

        public static string GetExtension(string path, bool includeDot)
        {
            if (path == null)
            {
                return string.Empty;
            }
            if (!IsValidPathName(path))
                return string.Empty;

            int length = path.Length;
            int startIndex = length;
            while (--startIndex >= 0)
            {
                char ch = path[startIndex];
                if (ch == '.')
                {
                    if (startIndex != (length - 1))
                    {
                        if (includeDot)
                            return path.Substring(startIndex, length - startIndex);
                        else
                            return path.Substring(startIndex + 1, length - startIndex - 1);
                    }
                    return string.Empty;
                }
                if (((ch == Path.DirectorySeparatorChar) || (ch == Path.AltDirectorySeparatorChar)) || (ch == Path.VolumeSeparatorChar))
                {
                    break;
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// Deletes file to recycle bin.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        public static void DeleteToRecycleBin(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return;
            RecycleBin.SendSilent(fileName);
        }

        public static void ClearFileAttributes(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return;
            NativeMethods.ClearFileAttributes(fileName);
        }

        public static string ExcludeTrailingPathDelimiter(string fullPath)
        {
            if (string.IsNullOrEmpty(fullPath))
                return string.Empty;
            else
            {
                if (fullPath.EndsWith(@"\", StringComparison.Ordinal) || fullPath.EndsWith(@"/", StringComparison.Ordinal))
                    return fullPath.Substring(0, fullPath.Length - 1);
                else
                    return fullPath;
            }
        }

        public static string IncludeTrailingPathDelimiter(string fullPath)
        {
            if (string.IsNullOrEmpty(fullPath))
                return string.Empty;
            else
            {
                if (fullPath.EndsWith(@"\", StringComparison.Ordinal) || fullPath.EndsWith(@"/", StringComparison.Ordinal))
                    return fullPath;
                else
                    return fullPath + "\\";
            }
        }

        public static bool IsValidFileName(string path)
        {
            if (string.IsNullOrEmpty(path))
                return false;

            return NativeMethods.IsValidFileName(path);
        }

        public static bool IsValidPathName(string path)
        {
            if (string.IsNullOrEmpty(path))
                return false;

            return NativeMethods.IsValidPathName(path);
        }

        public static void ShellCopyFile(string oldName, string newName)
        {
            if (!string.IsNullOrEmpty(oldName) && !string.IsNullOrEmpty(newName))
            {
                NativeMethods.ShellCopyFile(oldName, newName);
            }
        }


        /// <summary>
        /// Expand environment values and relace it with the full value. This method removes
        /// environment varaibles from the file name. To insert environment variable to the 
        /// file name use <see cref="UnExpandPath"/> method
        /// </summary>
        /// <param name="name">The name of the file.</param>
        /// <returns>A string with each environment variable replaced by its value.</returns>
        public static string StripFileName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return name;

            StringBuilder sb = new StringBuilder(259);
            NativeMethods.StripFileName(name, sb);
            return sb.ToString();
        }

        /// <summary>
        /// Replace known path by environment variables. This function does the opposite work to <see cref="StripFileName"/> function
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public static string UnExpandPath(string path)
        {
            if (string.IsNullOrEmpty(path))
                return path;

            string result;
            StringBuilder sb = new StringBuilder(259);
            bool b = NativeMethods.PathUnExpandEnvStrings(path, sb, sb.Capacity);
            if (b)
                result = sb.ToString();
            else
            {
                result = path;
            }
            return result;
        }

        public static bool FileExtensionIs(string fileName, string extension)
        {
            if (string.IsNullOrEmpty(fileName) || string.IsNullOrEmpty(extension))
                return false;

            return NativeMethods.FileExtensionIs(fileName, extension);

        }


        /// <summary>
        /// The file is an image (jpeg, bmp, gif, png or ico)
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        public static bool FileIsImage(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return false;

            return NativeMethods.FileIsImage(fileName);

        }

        /// <summary>
        /// Checks if the file is a Windows icon file
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>Returns true if the file is a Windows icon file; otherwise returns false</returns>
        public static bool FileIsIcon(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return false;

            return NativeMethods.FileIsIcon(fileName);
        }

        public static bool FileIsExe(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return false;

            return NativeMethods.FileIsExe(fileName);
        }

        public static bool FileIsLink(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return false;

            return NativeMethods.FileIsLink(fileName);
        }


        public static bool FileIsAnimatedGif(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return false;

            return NativeMethods.IsAnimatedGIF(fileName);
        }

        /// <summary>
        /// Deletes the file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        public static void DeleteFile(string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                NativeMethods.FileDelete(fileName);
            }
        }


        public static void RenameFile(string oldFileName, string newFileName)
        {
            if (!string.IsNullOrEmpty(oldFileName) && !string.IsNullOrEmpty(newFileName))
            {
                NativeMethods.FileRename(oldFileName, newFileName);
            }

        }

        public static void CopyFile(string sourceFileName, string destinationFileName)
        {
            if (!string.IsNullOrEmpty(sourceFileName) && !string.IsNullOrEmpty(destinationFileName))
            {
                NativeMethods.FileCopy(sourceFileName, destinationFileName);
            }
        }

        /// <summary>
        /// Checks if file exists
        /// </summary>
        /// <param name="name">The file name.</param>
        /// <returns>True, if file exists, otherwise false</returns>
        public static bool FileExists(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return false;

            return NativeMethods.FileExists(fileName);
        }

        public static bool DirectoryExists(string directoryName)
        {
            if (string.IsNullOrEmpty(directoryName))
                return false;

            return NativeMethods.DirectoryExists(directoryName);
        }

        /// <summary>
        /// Check if file or folder with given name exists
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public static bool FileOrFolderExists(string name)
        {
            if (string.IsNullOrEmpty(name))
                return false;

            return NativeMethods.FileOrFolderExists(name);
        }

        public static bool IsDirectory(string directoryName)
        {
            return NativeMethods.IsDirectory(directoryName);
        }

    }
}
