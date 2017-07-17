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
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

namespace Swelio.Engine
{

    public enum ErrorCorrectionLevel : int
    {
        LowQuality,
        MediumQuality,
        StandardQuality,
        HighQuality
    }
    
    /// <summary>
    /// QR Code encoder class
    /// </summary>
    public static class QRCode
    {
        /// <summary>
        /// Generates the bitmap file with encoded string
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="text">The text to encode.</param>
        /// <param name="margin">The margin.</param>
        /// <param name="pixelSize">Size of the pixel.</param>
        public static void GenerateBitmap(string fileName, string text, int margin, int pixelSize, ErrorCorrectionLevel level)
        {
            if (string.IsNullOrEmpty(fileName) || string.IsNullOrEmpty(text))
                return;

            NativeMethods.GenerateBMP(fileName, text, margin, pixelSize, (int)level);
        }

        /// <summary>
        /// Generates the bitmap.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="text">The text.</param>
        public static void GenerateBitmap(string fileName, string text, ErrorCorrectionLevel level)
        {
            if (string.IsNullOrEmpty(fileName) || string.IsNullOrEmpty(text))
                return;

            NativeMethods.GenerateBMP(fileName, text, 4, 3, (int)level);
        }


        /// <summary>
        /// Generates the PNG.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="text">The text.</param>
        /// <param name="margin">The margin.</param>
        /// <param name="pixelSize">Size of the pixel.</param>
        public static void GeneratePng(string fileName, string text, int margin, int pixelSize, ErrorCorrectionLevel level)
        {
            if (string.IsNullOrEmpty(fileName) || string.IsNullOrEmpty(text))
                return;

            NativeMethods.GeneratePNG(fileName, text, margin, pixelSize, (int)level);
        }

        /// <summary>
        /// Generates the PNG.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="text">The text.</param>
        public static void GeneratePng(string fileName, string text, ErrorCorrectionLevel level)
        {
            if (string.IsNullOrEmpty(fileName) || string.IsNullOrEmpty(text))
                return;

            NativeMethods.GeneratePNG(fileName, text, 4, 3, (int)level);
        }

        /// <summary>
        /// Gets the bitmap.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="margin">The margin.</param>
        /// <param name="pixelSize">Size of the pixel.</param>
        /// <returns></returns>
        public static Bitmap GetBitmap(string text, int margin, int pixelSize, ErrorCorrectionLevel level)
        {
            if (string.IsNullOrEmpty(text))
                return null;

            IntPtr handle = NativeMethods.GetHBitmap(text, margin, pixelSize, (int)level);

            if (handle == IntPtr.Zero)
                return null;

            Bitmap result = Bitmap.FromHbitmap(handle);

            NativeMethods.DeleteObject(handle);
            return result;
        }

        /// <summary>
        /// Gets the bitmap.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public static Bitmap GetBitmap(string text, ErrorCorrectionLevel level)
        {
            return GetBitmap(text, 4, 3, level);
        }

    }
}
