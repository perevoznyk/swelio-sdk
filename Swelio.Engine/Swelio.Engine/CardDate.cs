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
using System.Globalization;

namespace Swelio.Engine
{
    /// <summary>
    /// Handles dates conversion between internal EID format and YYYYMMDD format
    /// </summary>
    public static class CardDate
    {
        /// <summary>
        /// Converts the value from YYYYMMDD format to its equivalent short date string representation
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>A string containing the numeric month, the numeric day of the month, and the year equivalent to the date value</returns>
        public static string ToShortDateString(string date)
        {
            return ToDate(date).ToShortDateString();
        }

        /// <summary>
        /// Converts the value from YYYYMMDD format to its equivalent long date string representation
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>A string containing the name of the day of the week, the name of the month, the numeric day of the month, and the year equivalent to the date value</returns>
        public static string ToLongDateString(string date)
        {
            return ToDate(date).ToLongDateString();
        }

        /// <summary>
        /// Converts from the internal EID representation to System.DateTime
        /// </summary>
        /// <param name="date">The unformated date string</param>
        /// <returns>System.DateTime</returns>
        public static DateTime ToDate(string date)
        {
            int d, m, y = 0;
            NumberFormatInfo numberInfo = CultureInfo.CurrentCulture.NumberFormat;

            if (string.IsNullOrEmpty(date))
                throw new ArgumentNullException("date");

            if (date.Length == 8)
            {
                y = int.Parse(date.Substring(0, 4), numberInfo);
                m = int.Parse(date.Substring(4, 2), numberInfo);
                d = int.Parse(date.Substring(6, 2), numberInfo);

                if (m == 0)
                    m = 1;

                if (d == 0)
                    d = 1;
                return new DateTime(y, m, d);
            }
            else
                throw new ArgumentException("Wrong date format", "date");
        }
    }
}
