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

namespace Swelio.Engine
{
    /// <summary>
    /// National number formatter
    /// </summary>
    public static class NationalNumber
    {
        /// <summary>
        /// Converts the natinal number value to its formatted String representation
        /// </summary>
        /// <param name="nationalNumber">The unformatted national number</param>
        /// <returns></returns>
        public static string ToString(string nationalNumber)
        {
            if (string.IsNullOrEmpty(nationalNumber))
                return string.Empty;

            if (nationalNumber.Length != EIDDataLength.EidMaxNationalNumberLen)
                return string.Empty;
            else
                return nationalNumber.Substring(0, 2) + "." +
                   nationalNumber.Substring(2, 2) + "." +
                   nationalNumber.Substring(4, 2) + "-" +
                   nationalNumber.Substring(6, 3) + "." +
                   nationalNumber.Substring(9, 2);
        }
    }
}
