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

namespace Swelio.Engine
{
    /// <summary>
    /// 
    /// </summary>
    public static class Encryption
    {

        /// <summary>
        /// Encrypts the file.
        /// </summary>
        /// <param name="sourceFileName">Name of the source file.</param>
        /// <param name="destinationFileName">Name of the destination file.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public static bool EncryptFile(string sourceFileName, string destinationFileName, string password)
        {
            return NativeMethods.EncryptFileAES(sourceFileName, destinationFileName, password);
        }

        /// <summary>
        /// Decrypts the file.
        /// </summary>
        /// <param name="sourceFileName">Name of the source file.</param>
        /// <param name="destinationFileName">Name of the destination file.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public static bool DecryptFile(string sourceFileName, string destinationFileName, string password)
        {
            return NativeMethods.DecryptFileAES(sourceFileName, destinationFileName, password);
        }

        /// <summary>
        /// Encrypts the file.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="source">The source.</param>
        /// <param name="destination">The destination.</param>
        /// <returns></returns>
        public static bool EncryptFile(CardReader reader, string source, string destination)
        {
            if (reader != null)
            {
                NativeMethods.SelectReaderByName(reader.Name);
                return NativeMethods.CardEncryptFile(source, destination);
            }
            else
                return false;
        }

        /// <summary>
        /// Decrypts the file.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="source">The source.</param>
        /// <param name="destination">The destination.</param>
        /// <returns></returns>
        public static bool DecryptFile(CardReader reader, string source, string destination)
        {
            if (reader != null)
            {
                NativeMethods.SelectReaderByName(reader.Name);
                return NativeMethods.CardDecryptFile(source, destination);
            }
            else
                return false;
        }

        /// <summary>
        /// Generates the authentication signature.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="pinCode">The pin code.</param>
        /// <param name="dataHash">The data hash.</param>
        /// <param name="hashSize">Size of the hash.</param>
        /// <returns></returns>
        public static byte[] GenerateAuthenticationSignature(CardReader reader, string pinCode, byte[] dataHash, int hashSize)
        {
            if (reader != null)
            {
                int index = NativeMethods.GetReaderIndex(reader.Name);
                byte[] signature = new byte[1024];
                int signatureSize = 1024;
                if (NativeMethods.GenerateAuthenticationSignatureEx(index, pinCode, dataHash, hashSize, signature, ref signatureSize))
                {
                    byte[] result = new byte[signatureSize];
                    Array.Copy(signature, result, signatureSize);
                    return result;
                }
                else
                    return null;
            }
            else
                return null;
        }

        /// <summary>
        /// Generates the non repudiation signature.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="pinCode">The pin code.</param>
        /// <param name="dataHash">The data hash.</param>
        /// <param name="hashSize">Size of the hash.</param>
        /// <returns></returns>
        public static byte[] GenerateNonRepudiationSignature(CardReader reader, string pinCode, byte[] dataHash, int hashSize)
        { 
            if (reader != null)
            {
                int index = NativeMethods.GetReaderIndex(reader.Name);
                byte[] signature = new byte[4096];
                int signatureSize = 4096;
                if (NativeMethods.GenerateNonRepudiationSignatureEx(index, pinCode, dataHash, hashSize, signature, ref signatureSize))
                {
                    byte[] result = new byte[signatureSize];
                    Array.Copy(signature, result, signatureSize);
                    return result;
                }
                else
                    return null;
            }
            else
                return null;
        }


        /// <summary>
        /// Verifies the signature.
        /// </summary>
        /// <param name="certificate">The certificate.</param>
        /// <param name="dataHash">The data hash.</param>
        /// <param name="hashSize">Size of the hash.</param>
        /// <param name="signature">The signature.</param>
        /// <param name="signatureSize">Size of the signature.</param>
        /// <returns></returns>
        public static bool VerifySignature(byte[] certificate, byte[] dataHash, int hashSize, byte[] signature, int signatureSize)
        {
            EIDCertificate cert = new EIDCertificate();
            cert.certificateLength = certificate.Length;
            Array.Copy(certificate, cert.certificate, Math.Min(certificate.Length, EIDDataLength.EidMaxCertLen));
            return NativeMethods.VerifySignature(cert, dataHash, hashSize, signature, signatureSize);
        }

        /// <summary>
        /// Gets the M d5.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public static byte[] GetMD5(string message)
        {
            if (string.IsNullOrEmpty(message))
                return null;

            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] data = encoding.GetBytes(message);
            byte[] hash = new byte[16];
            if (NativeMethods.GetMD5(data, data.Length, hash, hash.Length))
                return hash;
            else
                return null;

        }

        /// <summary>
        /// Gets the M d5.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public static byte[] GetMD5(byte[] message)
        {
            if (message == null)
                return null;

            byte[] hash = new byte[16];

            if (NativeMethods.GetMD5(message, message.Length, hash, hash.Length))
                return hash;
            else
                return null;
        }

        /// <summary>
        /// Gets the file M d5.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        public static byte[] GetFileMD5(string fileName)
        {
            byte[] hash = new byte[16];

            if (NativeMethods.GetFileMD5(fileName, hash, hash.Length))
                return hash;
            else
                return null;
        }

        /// <summary>
        /// Gets the file SH a1.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        public static byte[] GetFileSHA1(string fileName)
        {
            byte[] hash = new byte[20];

            if (NativeMethods.GetFileSHA1(fileName, hash, hash.Length))
                return hash;
            else
                return null;
        }

        /// <summary>
        /// Checks the M d5.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="md5sum">The md5sum.</param>
        /// <returns></returns>
        public static bool CheckMD5(string message, byte[] md5sum)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] data = encoding.GetBytes(message);
            return NativeMethods.CheckMD5(data, data.Length, md5sum, md5sum.Length);
        }

        /// <summary>
        /// Checks the M d5.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="md5sum">The md5sum.</param>
        /// <returns></returns>
        public static bool CheckMD5(byte[] message, byte[] md5sum)
        {
            return NativeMethods.CheckMD5(message, message.Length, md5sum, md5sum.Length);
        }

        /// <summary>
        /// Checks the file M d5.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="md5sum">The md5sum.</param>
        /// <returns></returns>
        public static bool CheckFileMD5(string fileName, byte[] md5sum)
        {
            byte[] data = File.ReadAllBytes(fileName);
            return NativeMethods.CheckMD5(data, data.Length, md5sum, md5sum.Length);
        }

        /// <summary>
        /// Gets the SH a1.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public static byte[] GetSHA1(string message)
        {
            if (string.IsNullOrEmpty(message))
                return null;

            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] data = encoding.GetBytes(message);
            byte[] hash = new byte[20];
            if (NativeMethods.GetSHA1(data, data.Length, hash, hash.Length))
                return hash;
            else
                return null;

        }

        /// <summary>
        /// Gets the SH a1.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public static byte[] GetSHA1(byte[] message)
        {
            if (message == null)
                return null;

            byte[] hash = new byte[20];

            if (NativeMethods.GetSHA1(message, message.Length, hash, hash.Length))
                return hash;
            else
                return null;
        }


        /// <summary>
        /// Checks the SH a1.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="sha1sum">The sha1sum.</param>
        /// <returns></returns>
        public static bool CheckSHA1(string message, byte[] sha1sum)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] data = encoding.GetBytes(message);
            return NativeMethods.CheckSHA1(data, data.Length, sha1sum, sha1sum.Length);
        }

        /// <summary>
        /// Checks the SH a1.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="sha1sum">The sha1sum.</param>
        /// <returns></returns>
        public static bool CheckSHA1(byte[] message, byte[] sha1sum)
        {
            return NativeMethods.CheckSHA1(message, message.Length, sha1sum, sha1sum.Length);
        }

        /// <summary>
        /// Checks the file SH a1.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="sha1sum">The sha1sum.</param>
        /// <returns></returns>
        public static bool CheckFileSHA1(string fileName, byte[] sha1sum)
        {
            byte[] data = File.ReadAllBytes(fileName);
            return NativeMethods.CheckSHA1(data, data.Length, sha1sum, sha1sum.Length);
        }

    }
}
