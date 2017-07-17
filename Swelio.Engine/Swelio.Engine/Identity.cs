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
    /// Holds identity information that is stored on EID card
    /// </summary>
    [Browsable(false)]
    public class Identity
    {
        private string cardNumber;
        private string chipNumber;
        private DateTime validityDateBegin;
        private DateTime validityDateEnd;
        private string municipality;
        private string nationalNumber;
        private string nationalityISO;
        private string surname;
        private string firstName1;
        private string firstName2;
        private string nationality;
        private string birthLocation;
        private DateTime birthDate;
        private Gender sex;
        private string nobleCondition;
        private DocumentType documentType;
        private bool whiteCane;
        private bool yellowCane;
        private bool extendedMinority;

        /// <summary>
        /// Clear all stored information
        /// </summary>
        public void Clear()
        {
            cardNumber = "";
            chipNumber = "";
            validityDateBegin = DateTime.Now;
            validityDateEnd = DateTime.Now;
            municipality = "";
            nationalNumber = "";
            surname = "";
            firstName1 = "";
            firstName2 = "";
            nationality = "";
            birthLocation = "";
            birthDate = DateTime.Now;
            sex = Gender.Male;
            nobleCondition = "";
            documentType = DocumentType.Unknown;
            whiteCane = false;
            yellowCane = false;
            extendedMinority = false;
        }
        /// <summary>
        /// Electronic ID card number
        /// </summary>
        [Description("Electronic ID card number")]
        [ReadOnly(true)]
        public string CardNumber
        {
            get { return cardNumber; }
            set { cardNumber = value; }
        }
        /// <summary>
        /// Electronic ID card physical chip number
        /// </summary>
        [Description("Electronic ID card physical chip number")]
        [ReadOnly(true)]
        public string ChipNumber
        {
            get { return chipNumber; }
            set { chipNumber = value; }
        }
        /// <summary>
        /// Card validity date begin in YYYYMMDD format
        /// </summary>
        [Description("Card validity date begin")]
        [ReadOnly(true)]
        public DateTime ValidityDateBegin
        {
            get { return validityDateBegin; }
            set { validityDateBegin = value; }
        }
        /// <summary>
        /// Card validity date end in YYYYMMDD format
        /// </summary>
        [Description("Card validity date end")]
        [ReadOnly(true)]
        public DateTime ValidityDateEnd
        {
            get { return validityDateEnd; }
            set { validityDateEnd = value; }
        }

        /// <summary>
        /// Card delivery municipality
        /// </summary>
        [Description("Card delivery municipality")]
        [ReadOnly(true)]
        public string Municipality
        {
            get { return municipality; }
            set { municipality = value; }
        }

        /// <summary>
        /// National number
        /// </summary>
        [Description("Unique national number")]
        [ReadOnly(true)]
        public string NationalNumber
        {
            get { return nationalNumber; }
            set { nationalNumber = value; }
        }

        /// <summary>
        /// Surname
        /// </summary>
        [Description("Surname of the card owner")]
        [ReadOnly(true)]
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        /// <summary>
        /// First name
        /// </summary>
        [Description("First name of the card owner")]
        [ReadOnly(true)]
        public string FirstName1
        {
            get { return firstName1; }
            set { firstName1 = value; }
        }

        /// <summary>
        /// First name
        /// </summary>
        [Description("First name of the card owner")]
        [ReadOnly(true)]
        public string FirstName2
        {
            get { return firstName2; }
            set { firstName2 = value; }
        }

        /// <summary>
        /// Nationality
        /// </summary>
        [Description("Nationality of the card owner")]
        [ReadOnly(true)]
        public string Nationality
        {
            get { return nationality; }
            set { nationality = value; }
        }

        /// <summary>
        /// Gets the nationality ISO 3166 code.
        /// </summary>
        /// <value>The nationality ISO 3166 code.</value>
        public string NationalityISO
        {
            get { return nationalityISO; }
            set { nationalityISO = value; }
        }

        /// <summary>
        /// Birth location
        /// </summary>
        [Description("Birth location")]
        [ReadOnly(true)]
        public string BirthLocation
        {
            get { return birthLocation; }
            set { birthLocation = value; }
        }

        /// <summary>
        /// Birth date in YYYYMMDD format
        /// </summary>
        [Description("Birth date")]
        [ReadOnly(true)]
        public DateTime BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }

        /// <summary>
        /// Sex
        /// </summary>
        [Description("Sex of the card owner")]
        [ReadOnly(true)]
        public Gender Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        /// <summary>
        /// Noble condition
        /// </summary>
        [Description("Noble condition")]
        [ReadOnly(true)]
        public string NobleCondition
        {
            get { return nobleCondition; }
            set { nobleCondition = value; }
        }

        /// <summary>
        /// Document type (Belgian citizen, European Community citizen, ...)
        /// </summary>
        [Description("Document type (Belgian citizen, European Community citizen, ...)")]
        [ReadOnly(true)]
        public DocumentType DocumentType
        {
            get { return documentType; }
            set { documentType = value; }
        }

        /// <summary>
        /// White cane allowed (blind people)
        /// </summary>
        [Description("White cane allowed (blind people)")]
        [ReadOnly(true)]
        public bool WhiteCane
        {
            get { return whiteCane; }
            set { whiteCane = value; }
        }

        /// <summary>
        /// Yellow cane allowed (partially sighted people)
        /// </summary>
        [Description("Yellow cane allowed (partially sighted people)")]
        [ReadOnly(true)]
        public bool YellowCane
        {
            get { return yellowCane; }
            set { yellowCane = value; }
        }

        /// <summary>
        /// Extended minority
        /// </summary>
        [Description("Extended minotity")]
        [ReadOnly(true)]
        public bool ExtendedMinority
        {
            get { return extendedMinority; }
            set { extendedMinority = value; }
        }
    }
}
