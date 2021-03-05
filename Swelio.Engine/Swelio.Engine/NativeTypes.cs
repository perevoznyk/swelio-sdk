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
    internal enum ChangeWindowMessageFilterFlags : int
    {
        Add = 1, Remove = 2
    };
    
    /// <summary>
    /// Maximum length of EID fields
    /// </summary>
    internal static class EIDDataLength
    {
        /// <summary>
        /// Max length of the card number field
        /// </summary>
        public const int EidMaxCardNumberLen = 12;
        /// <summary>
        /// Max length of the chip number field
        /// </summary>
        public const int EidMaxChipNumberLen = 32;
        /// <summary>
        /// Max length of the begin date field
        /// </summary>
        public const int EidMaxDateBeginLen = 10;
        /// <summary>
        /// Max length of the end date field
        /// </summary>
        public const int EidMaxDateEndLen = 10;
        /// <summary>
        /// Max length of the name of the devivery municipality
        /// </summary>
        public const int EidMaxDeliveryMunicipalityLen = 80;
        /// <summary>
        /// Max length of the national number
        /// </summary>
        public const int EidMaxNationalNumberLen = 11;
        /// <summary>
        /// Max length of the surname
        /// </summary>
        public const int EidMaxNameLen = 110;
        /// <summary>
        /// Max length of the first name
        /// </summary>
        public const int EidMaxFirstNameLen = 95;
        /// <summary>
        /// Max length of the first name
        /// </summary>
        public const int EidMaxMiddleNameLen = 3;
        /// <summary>
        /// Max length of the nationality
        /// </summary>
        public const int EidMaxNationalityLen = 85;
        /// <summary>
        /// Max length of the birthplace
        /// </summary>
        public const int EidMaxBirthplaceLen = 80;
        /// <summary>
        /// Max length of the birthdate
        /// </summary>
        public const int EidMaxBirthDateLen = 12;
        /// <summary>
        /// Max length of the sex field
        /// </summary>
        public const int EidMaxSexLen = 1;
        /// <summary>
        /// Max length of the noble condition field
        /// </summary>
        public const int EidMaxNobleConditionLen = 50;
        /// <summary>
        /// Max length of the document type field
        /// </summary>
        public const int EidMaxDocumentTypeLen = 2;
        /// <summary>
        /// Max length of the special status field
        /// </summary>
        public const int EidMaxSpecialStatusLen = 2;
        /// <summary>
        /// Max length of the street name field
        /// </summary>
        public const int EidMaxStreetNameLen = 80;
        /// <summary>
        /// Max length of the ZIP code field
        /// </summary>
        public const int EidMaxZipLen = 4;
        /// <summary>
        /// Max length of the municipality name field
        /// </summary>
        public const int EidMaxMunicipalityName = 67;
        /// <summary>
        /// Max length of the picture data
        /// </summary>
        public const int EidMaxPictureLen = 4096;
        /// <summary>
        /// Max length of the certificate data
        /// </summary>
        public const int EidMaxCertLen = 2048;
        //Duplicate
        public const int EidMaxDuplicateLen = 2;
        // Special organization
        public const int EidMaxSpecialOrganizationLen = 1;
        //Member of family
        public const int EidMaxMemberOfFamilyLen = 1;
        //Date and country of protection
        public const int EidMaxDateAndCountryOfProtectionLen = 13;
        //The type of the workpermit
        public const int EidMaxWorkPermitTypeLen = 1;
        //VAT1
        public const int EidMaxVAT1Len = 13;
        //VAT2
        public const int EidMaxVAT2Len = 13;
        //Regional file number
        public const int EidMaxRegionalFileNumberLen = 18;
        //BREXIT mention
        public const int EidMaxBrexitMention1Len = 1;
        //BREXIT mention
        public const int EidMaxBrexitMention2Len = 1;

    }

    /// <summary>
    /// Identity information stored on EID card
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    [BestFitMapping(false, ThrowOnUnmappableChar = true)]
    internal class EIDIdentity
    {
        /// <summary>
        /// Electronic ID card number
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = EIDDataLength.EidMaxCardNumberLen + 1)]
        internal string cardNumber;
        /// <summary>
        /// Electronic ID card physical chip number
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = EIDDataLength.EidMaxChipNumberLen + 1)]
        internal string chipNumber;
        /// <summary>
        /// Card validity date begin
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = EIDDataLength.EidMaxDateBeginLen + 1)]
        internal string validityDateBegin;
        /// <summary>
        /// Card validity date end
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = EIDDataLength.EidMaxDateEndLen + 1)]
        internal string validityDateEnd;
        /// <summary>
        /// Card delivery municipality
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = EIDDataLength.EidMaxDeliveryMunicipalityLen + 1)]
        internal string municipality;
        /// <summary>
        /// National number
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = EIDDataLength.EidMaxNationalNumberLen + 1)]
        internal string nationalNumber;
        /// <summary>
        /// Surname
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = EIDDataLength.EidMaxNameLen + 1)]
        internal string name;
        /// <summary>
        /// First name
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = EIDDataLength.EidMaxFirstNameLen + 1)]
        internal string firstName1;
        /// <summary>
        /// First name
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = EIDDataLength.EidMaxMiddleNameLen + 1)]
        internal string firstName2;
        /// <summary>
        /// Nationality
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = EIDDataLength.EidMaxNationalityLen + 1)]
        internal string nationality;
        /// <summary>
        /// Birth location
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = EIDDataLength.EidMaxBirthplaceLen + 1)]
        internal string birthLocation;
        /// <summary>
        /// Birth date
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = EIDDataLength.EidMaxBirthDateLen + 1)]
        internal string birthDate;
        /// <summary>
        /// Sex
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = EIDDataLength.EidMaxSexLen + 1)]
        internal string sex;
        /// <summary>
        /// Noble condition
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = EIDDataLength.EidMaxNobleConditionLen + 1)]
        internal string nobleCondition;
        /// <summary>
        /// Document type (Belgian citizen, European Community citizen, ...)
        /// </summary>
        [MarshalAs(UnmanagedType.I4)]
        internal int documentType;
        /// <summary>
        /// White cane allowed (blind people)
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        internal bool whiteCane;
        /// <summary>
        /// Yellow cane allowed (partially sighted people)
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        internal bool yellowCane;
        /// <summary>
        /// Extended minority
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        internal bool extendedMinority;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = EIDDataLength.EidMaxDuplicateLen + 1)]
        internal string duplicate;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = EIDDataLength.EidMaxSpecialOrganizationLen + 1)]
        internal string specialOrganization;
        
        [MarshalAs(UnmanagedType.Bool)] 
        internal bool memberOfFamily;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = EIDDataLength.EidMaxDateAndCountryOfProtectionLen + 1)]
        internal string dateAndCountryOfProtection;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = EIDDataLength.EidMaxWorkPermitTypeLen + 1)]
        internal string workPermitType;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = EIDDataLength.EidMaxVAT1Len + 1)]
        internal string vat1;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = EIDDataLength.EidMaxVAT2Len + 1)]
        internal string vat2;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = EIDDataLength.EidMaxRegionalFileNumberLen + 1)]
        internal string regionalFileNumber;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = EIDDataLength.EidMaxBrexitMention1Len + 1)]
        internal string brexitMention1;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = EIDDataLength.EidMaxBrexitMention2Len + 1)]
        internal string brexitMention2;
    }

    /// <summary>
    /// Certificate, stored on EID card
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    internal class EIDCertificate
    {
        /// <summary>
        /// Certificate raw data buffer
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = EIDDataLength.EidMaxCertLen + 1)]
        internal byte[] certificate;
        /// <summary>
        /// Certificate data length
        /// </summary>
        [MarshalAs(UnmanagedType.I4)]
        internal int certificateLength;
    }

    /// <summary>
    /// Raw picture data from EID card
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    internal class EIDPicture
    {
        /// <summary>
        /// Picture raw data buffer
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = EIDDataLength.EidMaxPictureLen + 1)]
        internal byte[] picture;
        /// <summary>
        /// Picture raw data buffer length
        /// </summary>
        [MarshalAs(UnmanagedType.I4)]
        internal int pictureLength;
    }

    /// <summary>
    /// EID address information, stored on the card
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    [BestFitMapping(false, ThrowOnUnmappableChar = true)]
    internal class EIDAddress
    {
        /// <summary>
        /// Street name
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = EIDDataLength.EidMaxStreetNameLen + 1)]
        internal string street;
        /// <summary>
        /// ZIP code
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = EIDDataLength.EidMaxZipLen + 1)]
        internal string zip;
        /// <summary>
        /// Municipality
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = EIDDataLength.EidMaxMunicipalityName + 1)]
        internal string municipality;
    }
}
