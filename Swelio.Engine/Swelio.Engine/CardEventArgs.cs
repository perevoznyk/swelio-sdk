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
    public class CardEventArgs : EventArgs
    {
        private readonly int readerNumber;

        /// <summary>Gets the reader number.</summary>
        /// <value>The reader number.</value>
        public int ReaderNumber
        {
            get { return readerNumber; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CardEventArgs"/> class.
        /// </summary>
        /// <param name="readerNumber">The reader number.</param>
        public CardEventArgs(int readerNumber)
        {
            this.readerNumber = readerNumber;
        }
    }
}
