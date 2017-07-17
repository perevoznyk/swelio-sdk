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
    /// The physical smart card reader
    /// </summary>
    public sealed class CardReader : IDisposable
    {
        internal Card card;

        /// <summary>
        /// Initializes a new instance of the <see cref="CardReader"/> class.
        /// </summary>
        internal CardReader() : base()  { }

        /// <summary>
        /// Gets the name of the smart card reader.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Gets the index of the smart card reader.
        /// </summary>
        public int Index { get; internal set; }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="CardReader"/> is reclaimed by garbage collection.
        /// </summary>
        ~CardReader()
        {
            Dispose(false);
        }

        /// <summary>
        /// Gets or sets the tag.
        /// </summary>
        /// <value>
        /// The tag.
        /// </value>
        public int Tag { get; set; }

        /// <summary>
        /// Activates the card.
        /// </summary>
        /// <returns></returns>
        public bool ActivateCard()
        {
            try
            {
                if (card != null)
                    card.Dispose();
            }
            finally
            {
                card = null;
            }
            bool result = NativeMethods.ActivateCardEx(this.Index);
            if (result && (card == null))
            {
                card = new Card(this);
            }
            return result;
        }

        /// <summary>
        /// Deactivates the card.
        /// </summary>
        public void DeactivateCard()
        {
            NativeMethods.DeactivateCardEx(this.Index);
            try
            {
                if (card != null)
                    card.Dispose();
            }
            finally
            {
                card = null;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [card activated].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [card activated]; otherwise, <c>false</c>.
        /// </value>
        public bool CardActivated
        {
            get { return NativeMethods.IsCardActivatedEx(this.Index); }
        }

        /// <summary>
        /// Gets a value indicating whether [card present].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [card present]; otherwise, <c>false</c>.
        /// </value>
        public bool CardPresent
        {
            get { return NativeMethods.IsCardPresentEx(this.Index); }
        }


        /// <summary>
        /// Gets the card.
        /// </summary>
        /// <returns></returns>
        public Card GetCard()
        {
            if (card == null)
            {
                if (NativeMethods.IsCardActivatedEx(this.Index))
                {
                    card = new Card(this);
                }
            }
            return card;
        }

        /// <summary>
        /// Gets the card.
        /// </summary>
        /// <param name="activate">if set to <c>true</c> [activate].</param>
        /// <returns></returns>
        public Card GetCard(bool activate)
        {
            if (card == null)
            {
                if (activate)
                {
                    if (NativeMethods.IsCardPresentEx(this.Index))
                    {
                        card = new Card(this);
                    }
                }
                else
                {
                    if (NativeMethods.IsCardActivatedEx(this.Index))
                    {
                        card = new Card(this);
                    }
                }
            }
            return card;
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="CardReader"/> is selected.
        /// </summary>
        /// <value>
        ///   <c>true</c> if selected; otherwise, <c>false</c>.
        /// </value>
        public bool Selected
        {
            get
            {
                return (NativeMethods.GetSelectedReaderIndex() == this.Index);
            }
        }

        #region IDisposable Members

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        internal void Dispose(bool disposing)
        {
            DeactivateCard();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
