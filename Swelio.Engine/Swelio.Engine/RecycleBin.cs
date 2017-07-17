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
    /// <summary>
    /// Send files directly to the recycle bin.
    /// </summary>
    public static class RecycleBin
    {

        /// <summary>
        /// Send file to recycle bin.  Display dialog, display warning if files are too big to fit 
        /// </summary>
        /// <param name="path">Location of directory or file to recycle</param>
        public static void Send(string path)
        {
            NativeMethods.DeleteToRecycleBin(path, false);
        }

        /// <summary>
        /// Send file silently to recycle bin.  Surpress dialog, surpress errors, delete if too large.
        /// </summary>
        /// <param name="path">Location of directory or file to recycle</param>
        public static void SendSilent(string path)
        {
            NativeMethods.DeleteToRecycleBin(path, true);
        }

        /// <summary>
        /// Gets a value indicating whether thee recycle bin is empty.
        /// </summary>
        /// <value>
        ///   <c>true</c> if recycle bin is empty; otherwise, <c>false</c>.
        /// </value>
        public static bool IsEmpty
        {
            get { return NativeMethods.RecycleBinEmpty(); }
        }

        public static void Clear()
        {
            NativeMethods.EmptyRecycleBin();
        }
    }
}
