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
    /// EID card number formatter. This class takes EID card number in raw form as input 
    /// and return formatted EID card number
    /// </summary>
    public static class CardNumber
    {
        /// <summary>
        /// Converts the value of the card number to its String representation
        /// </summary>
        /// <param name="cardNumber">The unformatted card number</param>
        /// <returns>Formatted card number</returns>
        public static string ToString(string cardNumber)
        {
            if (string.IsNullOrEmpty(cardNumber))
                return string.Empty;

            if (cardNumber.Length == EIDDataLength.EidMaxCardNumberLen)
                return
                    cardNumber.Substring(0, 3) + "-" +
                    cardNumber.Substring(3, 7) + "-" +
                    cardNumber.Substring(10, 2);
            else
                if (cardNumber.Length == 10)
                    return
            cardNumber.Substring(0, 1) +
            " " +
            cardNumber.Substring(1, 7) +
            " " +
            cardNumber.Substring(8, 2);
                else
                    return string.Empty;

        }
    }
}
