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
using System.ComponentModel;

namespace Swelio.Engine
{
    /// <summary>
    /// Represents a postal address of the person
    /// </summary>
    [Browsable(false)]
    public class Address
    {
        private string zip;
        private string street;
        private string municipality;


        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> class.
        /// </summary>
        /// <param name="street">The street.</param>
        /// <param name="zip">The zip code.</param>
        /// <param name="municipality">The municipality.</param>
        public Address(string street, string zip, string municipality)
        {
            this.street = street;
            this.zip = zip;
            this.municipality = municipality;
        }

        /// <summary>Parses adress string to street name and house number</summary>
        /// <returns>
        ///  The postal address 
        /// </returns>
        public PostalAddress Parse()
        {
            return new PostalAddress(this);
        }

        /// <summary>
        /// Street name
        /// </summary>
        [Description("Street name")]
        public string Street
        {
            get { return street; }
        }
        /// <summary>
        /// ZIP code
        /// </summary>
        [Description("ZIP code")]
        public string Zip
        {
            get { return zip; }
        }
        /// <summary>
        /// Municipality
        /// </summary>
        [Description("Municipality")]
        public string Municipality
        {
            get { return municipality; }
        }
    }
}
