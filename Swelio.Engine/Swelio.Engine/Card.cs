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
using System.Globalization;

namespace Swelio.Engine
{
    /// <summary>
    /// This class represents a Belgian EID card
    /// </summary>
    public sealed class Card : IDisposable
    {
        CardReader reader;

        /// <summary>
        /// Initializes a new instance of the <see cref="Card"/> class.
        /// </summary>
        /// <param name="reader">The reader.</param>
        internal Card(CardReader reader)
        {
            this.reader = reader;
        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="Card"/> is reclaimed by garbage collection.
        /// </summary>
        ~Card()
        {
            Dispose(false);
        }

        public int Tag { get; set; }

        /// <summary>
        /// Gets a value indicating whether the <see cref="Card"/> is inserted in the card reader.
        /// </summary>
        /// <value>
        ///   <c>true</c> if inserted; otherwise, <c>false</c>.
        /// </value>
        public bool Inserted
        {
            get { return NativeMethods.IsCardStillInsertedEx(reader.Index); }
        }

        /// <summary>
        /// Gets a value indicating whether the card is eid card.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the card is eid card; otherwise, <c>false</c>.
        /// </value>
        public bool EidCard
        {
            get { return NativeMethods.IsEIDCardEx(reader.Index); }
        }

        public Identity ReadIdentity()
        {
            RegionInfo region = null;
            bool doConvert = false;
            EIDIdentity eid = new EIDIdentity();
            if (NativeMethods.ReadIdentityEx(reader.Index, eid))
            {
                Identity id = new Identity();
                id.BirthDate = CardDate.ToDate(eid.birthDate);
                id.BirthLocation = eid.birthLocation;
                id.CardNumber = eid.cardNumber;
                id.ChipNumber = eid.chipNumber;
                switch (eid.documentType)
                {
                    case 01:
                        id.DocumentType = DocumentType.BelgianCitizen;
                        break;
                    case 02:
                        id.DocumentType = DocumentType.EuropeanCommunity;
                        break;
                    case 03:
                        id.DocumentType = DocumentType.NonEuropeanCommunity;
                        break;
                    case 04:
                        id.DocumentType = DocumentType.KidsCard;
                        break;
                    case 06:
                        id.DocumentType = DocumentType.KidsCard;
                        break;
                    case 07:
                        id.DocumentType = DocumentType.BootstrapCard;
                        break;
                    case 08:
                        id.DocumentType = DocumentType.HabilitationCard;
                        break;
                    case 11:
                        id.DocumentType = DocumentType.ForeignerCard;
                        break;
                    case 12:
                        id.DocumentType = DocumentType.ForeignerCard;
                        break;
                    case 13:
                        id.DocumentType = DocumentType.ForeignerCard;
                        break;
                    case 14:
                        id.DocumentType = DocumentType.ForeignerCard;
                        break;
                    case 15:
                        id.DocumentType = DocumentType.ForeignerCard;
                        break;
                    case 16:
                        id.DocumentType = DocumentType.ForeignerCard;
                        break;
                    case 17:
                        id.DocumentType = DocumentType.ForeignerCard;
                        break;
                    case 18:
                        id.DocumentType = DocumentType.ForeignerCard;
                        break;
                    default:
                        id.DocumentType = DocumentType.Unknown;
                        break;
                }
                id.ExtendedMinority = eid.extendedMinority;

                id.FirstName1 = eid.firstName1;
                id.FirstName2 = eid.firstName2;

                int idx = id.FirstName1.IndexOf(' ');
                if (idx > 0)
                {
                    string name1 = id.FirstName1.Substring(0, idx);
                    string name2 = id.FirstName1.Substring(idx + 1, id.FirstName1.Length - idx - 1);
                    id.FirstName1 = name1;
                    id.FirstName2 = name2 + " " + id.FirstName2;
                }
                id.Municipality = eid.municipality;
                id.Nationality = eid.nationality;

                if (string.IsNullOrEmpty(id.Nationality))
                {
                    region = new RegionInfo("BE");
                    id.Nationality = region.EnglishName;
                    id.NationalityISO = region.TwoLetterISORegionName;
                }
                else
                {
                    if (id.Nationality.Length < 4)
                    {
                        string ISOName = id.Nationality;
                        try
                        {
                            region = new RegionInfo(ISOName);
                            doConvert = true;
                        }
                        catch (ArgumentException)
                        {
                            doConvert = false;
                        }
                        if (doConvert)
                        {
                            id.NationalityISO = ISOName;
                            if (region != null)
                                id.Nationality = region.EnglishName;
                        }
                    }
                    else
                    {
                        StringBuilder sb = new StringBuilder(3);
                        bool res = NativeMethods.GetISOCode(id.Nationality, sb, 3);
                        if (res)
                            id.NationalityISO = sb.ToString();
                        else
                            id.NationalityISO = id.Nationality;
                    }
                }
                id.NationalNumber = eid.nationalNumber;
                id.NobleCondition = eid.nobleCondition;
                if (NativeMethods.IsMale(eid))
                    id.Sex = Gender.Male;
                else
                    id.Sex = Gender.Female;
                id.Surname = eid.name;
                id.ValidityDateBegin = CardDate.ToDate(eid.validityDateBegin);
                id.ValidityDateEnd = CardDate.ToDate(eid.validityDateEnd);
                id.WhiteCane = eid.whiteCane;
                id.YellowCane = eid.yellowCane;

                id.Duplicate = eid.duplicate;
                id.SpecialOrganization = eid.specialOrganization;
                id.MemberOfFamily = eid.memberOfFamily;
                id.DateAndCountryOfProtection = eid.dateAndCountryOfProtection;
                id.WorkPermitType = eid.workPermitType;
                id.Vat1 = eid.vat1;
                id.Vat2 = eid.vat2;
                id.RegionalFileNumber = eid.regionalFileNumber;
                id.BrexitMention1 = eid.brexitMention1;
                id.BrexitMention2 = eid.brexitMention2;

                return id;
            }
            else
                return null;
        }

        /// <summary>
        /// Reads the address of the person from the card.
        /// </summary>
        /// <returns>Returns the postal adress of the person</returns>
        public Address ReadAddress()
        {
            if (reader == null)
                return null;

            EIDAddress eadr = new EIDAddress();
            if (NativeMethods.ReadAddressEx(reader.Index, eadr))
            {
                Address adr = new Address(eadr.street, eadr.zip, eadr.municipality);
                return adr;
            }
            else
                return null;
        }

        public string SerialNumber
        {
            get
            {
                if (reader == null)
                    return null;

                byte[] serial = new byte[16];
                int len = 16;
                if (NativeMethods.GetCardSerialNumber(reader.Index, serial, ref len))
                {
                    StringBuilder hex = new StringBuilder(serial.Length * 2);
                    foreach (byte b in serial)
                        hex.AppendFormat("{0:x2}", b);
                    return hex.ToString();

                }
                else
                {
                    return null;
                }

            }
        }
        /// <summary>
        /// Reads the photo.
        /// </summary>
        /// <returns></returns>
        public Image ReadPhoto()
        {
            if (reader == null)
                return null;

            EIDPicture photo = new EIDPicture();
            MemoryStream ms = null;

            if (NativeMethods.ReadPhotoEx(reader.Index, photo))
            {
                if (photo.pictureLength == 0)
                    return null;

                ms = new MemoryStream(photo.picture);
                Image result = Image.FromStream(ms);
                ms.Dispose();
                return result;

            }
            else
                return null;
        }

        /// <summary>
        /// Encodes the photo.
        /// </summary>
        /// <returns></returns>
        public byte[] EncodePhoto()
        {
            if (reader == null)
                return null;

            EIDPicture photo = new EIDPicture();
            if (NativeMethods.ReadPhotoEx(reader.Index, photo))
            {
                if (photo.pictureLength == 0)
                    return null;

                int len = NativeMethods.GetEncodedPhotoSize(photo);
                byte[] buffer = new byte[len];
                int encodedLen = NativeMethods.EncodePhoto(photo, buffer, len);

                encodedLen--;

                if (encodedLen > len)
                    return null;

                if (encodedLen == len)
                    return buffer;

                byte[] result = new byte[encodedLen];
                Array.Copy(buffer, result, encodedLen);
                return result;
            }
            else
                return null;
        }

        /// <summary>Encodes the photo.</summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        public byte[] EncodePhoto(string fileName)
        {
            EIDPicture photo = new EIDPicture();
            NativeMethods.LoadPhoto(photo, fileName);
            if (photo.pictureLength == 0)
                return null;

            if (photo.pictureLength > 0)
            {

                int len = NativeMethods.GetEncodedPhotoSize(photo);
                byte[] buffer = new byte[len];
                int encodedLen = NativeMethods.EncodePhoto(photo, buffer, len);

                encodedLen--;

                if (encodedLen > len)
                    return null;

                if (encodedLen == len)
                    return buffer;

                byte[] result = new byte[encodedLen];
                Array.Copy(buffer, result, encodedLen);
                return result;
            }
            else
                return null;
        }

        /// <summary>
        /// Saves the photo.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="format">The format.</param>
        /// <returns></returns>
        public bool SavePhoto(string fileName, PhotoFormat format)
        {
            bool result = false;
            switch (format)
            {
                case PhotoFormat.Bmp:
                    result = NativeMethods.SavePhotoAsBitmapEx(reader.Index, fileName);
                    break;
                case PhotoFormat.Jpeg:
                    result = NativeMethods.SavePhotoAsJpegEx(reader.Index, fileName);
                    break;
                default:
                    break;
            }

            return result;
        }

        /// <summary>
        /// Saves the certificate.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="certificate">The certificate.</param>
        public void SaveCertificate(string fileName, CertificateType certificate)
        {

            switch (certificate)
            {
                case CertificateType.CaCertificate:
                    NativeMethods.SaveCaCertificateEx(fileName, reader.Index);
                    break;
                case CertificateType.RootCaCertificate:
                    NativeMethods.SaveRootCaCertificateEx(fileName, reader.Index);
                    break;
                case CertificateType.RrnCertificate:
                    NativeMethods.SaveRrnCertificateEx(fileName, reader.Index);
                    break;
                case CertificateType.AuthenticationCertificate:
                    NativeMethods.SaveAuthenticationCertificateEx(fileName, reader.Index);
                    break;
                case CertificateType.NonRepudiationCertificate:
                    NativeMethods.SaveNonRepudiationCertificateEx(fileName, reader.Index);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Displays the certificate.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        public void DisplayCertificate(string fileName)
        {
            if (reader != null)
            {
                EIDCertificate cert = new EIDCertificate();
                NativeMethods.LoadCertificate(fileName, cert);
                NativeMethods.DisplayCertificate(cert);
            }
        }

        /// <summary>
        /// Displays the certificate.
        /// </summary>
        /// <param name="certificate">The certificate.</param>
        public void DisplayCertificate(CertificateType certificate)
        {
            if (reader != null)
            {
                NativeMethods.SelectReader(reader.Index);
            }

            bool result = false;
            EIDCertificate cert = new EIDCertificate();

            switch (certificate)
            {
                case CertificateType.CaCertificate:
                    result = NativeMethods.ReadCaCertificate(cert);
                    break;
                case CertificateType.RootCaCertificate:
                    result = NativeMethods.ReadRootCaCertificate(cert);
                    break;
                case CertificateType.RrnCertificate:
                    result = NativeMethods.ReadRrnCertificate(cert);
                    break;
                case CertificateType.AuthenticationCertificate:
                    result = NativeMethods.ReadAuthenticationCertificate(cert);
                    break;
                case CertificateType.NonRepudiationCertificate:
                    result = NativeMethods.ReadNonRepudiationCertificate(cert);
                    break;
                default:
                    break;
            }

            if (result)
                NativeMethods.DisplayCertificate(cert);
        }



        /// <summary>
        /// Encodes the certificate.
        /// </summary>
        /// <param name="certificate">The certificate.</param>
        /// <returns></returns>
        public byte[] EncodeCertificate(CertificateType certificate)
        {
            if (reader != null)
            {
                NativeMethods.SelectReader(reader.Index);
            }

            bool result = false;
            EIDCertificate cert = new EIDCertificate();

            switch (certificate)
            {
                case CertificateType.CaCertificate:
                    result = NativeMethods.ReadCaCertificate(cert);
                    break;
                case CertificateType.RootCaCertificate:
                    result = NativeMethods.ReadRootCaCertificate(cert);
                    break;
                case CertificateType.RrnCertificate:
                    result = NativeMethods.ReadRrnCertificate(cert);
                    break;
                case CertificateType.AuthenticationCertificate:
                    result = NativeMethods.ReadAuthenticationCertificate(cert);
                    break;
                case CertificateType.NonRepudiationCertificate:
                    result = NativeMethods.ReadNonRepudiationCertificate(cert);
                    break;
                default:
                    break;
            }

            if (result)
            {
                if (cert.certificateLength == 0)
                    return null;

                int len = NativeMethods.GetEncodedCertificateSize(cert);
                byte[] buffer = new byte[len];
                int encodedLen = NativeMethods.EncodeCertificate(cert, buffer, len);

                if (encodedLen > len)
                    return null;

                if (encodedLen == len)
                    return buffer;

                byte[] encodedCert = new byte[encodedLen];
                Array.Copy(buffer, encodedCert, encodedLen);
                return encodedCert;
            }
            else
                return null;
        }


        /// <summary>
        /// Reads the certificate.
        /// </summary>
        /// <param name="certificate">The certificate.</param>
        /// <returns></returns>
        public byte[] ReadCertificate(CertificateType certificate)
        {
            if (reader != null)
            {
                NativeMethods.SelectReader(reader.Index);
            }

            bool result = false;
            EIDCertificate cert = new EIDCertificate();

            switch (certificate)
            {
                case CertificateType.CaCertificate:
                    result = NativeMethods.ReadCaCertificate(cert);
                    break;
                case CertificateType.RootCaCertificate:
                    result = NativeMethods.ReadRootCaCertificate(cert);
                    break;
                case CertificateType.RrnCertificate:
                    result = NativeMethods.ReadRrnCertificate(cert);
                    break;
                case CertificateType.AuthenticationCertificate:
                    result = NativeMethods.ReadAuthenticationCertificate(cert);
                    break;
                case CertificateType.NonRepudiationCertificate:
                    result = NativeMethods.ReadNonRepudiationCertificate(cert);
                    break;
                default:
                    break;
            }

            if (result)
            {
                if (cert.certificateLength == 0)
                    return null;

                byte[] buffer = new byte[cert.certificateLength];
                Array.Copy(cert.certificate, buffer, cert.certificateLength);
                return buffer;
            }
            else
                return null;
        }

        /// <summary>
        /// Verifies the pin code.
        /// </summary>
        /// <param name="pinCode">The pin code.</param>
        /// <returns></returns>
        public bool VerifyPinCode(string pinCode)
        {
            if (reader != null)
            {
                return NativeMethods.VerifyPinEx(reader.Index, pinCode);
            }
            else
                return false;
        }


        /// <summary>
        /// Saves information from the card to the file with specified file name.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="format">The format of the export.</param>
        /// <returns></returns>
        public bool Save(string fileName, ExportFormat format)
        {
            return Save(fileName, format, FileEncoding.Utf16);
        }


        private bool SaveCardToXmlExUtf8(string fileName)
        {
            string xmlBuffer = GetXmlStringW();
            if (String.IsNullOrEmpty(xmlBuffer))
                return false;

            StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8);
            writer.Write(xmlBuffer);
            writer.Close();
            return true;
        }


        private bool SavePersonToCsvExUtf8(string fileName)
        {
            string csvBuffer = GetCsvStringW();
            if (String.IsNullOrEmpty(csvBuffer))
                return false;

            StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8);
            writer.Write(csvBuffer);
            writer.Close();
            return true;
        }

        /// <summary>
        /// Saves information from the card to the file with specified file name.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="format">The format.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns></returns>
        public bool Save(string fileName, ExportFormat format, FileEncoding encoding)
        {
            switch (encoding)
            {
                case FileEncoding.Ansi:
                    switch (format)
                    {
                        case ExportFormat.Csv:
                            return NativeMethods.SavePersonToCsvExAnsi(reader.Index, fileName);
                        case ExportFormat.Xml:
                            return NativeMethods.SaveCardToXmlExAnsi(reader.Index, fileName);
                        default:
                            return false;
                    }
                case FileEncoding.Utf16:
                    switch (format)
                    {
                        case ExportFormat.Csv:
                            return NativeMethods.SavePersonToCsvEx(reader.Index, fileName);
                        case ExportFormat.Xml:
                            return NativeMethods.SaveCardToXmlEx(reader.Index, fileName);
                        default:
                            return false;
                    }
                case FileEncoding.Utf8:
                    switch (format)
                    {
                        case ExportFormat.Csv:
                            return SavePersonToCsvExUtf8(fileName);
                        case ExportFormat.Xml:
                            return SaveCardToXmlExUtf8(fileName);
                        default:
                            return false;
                    }
                default:
                    return false;
            }
        }


        private string GetXmlStringW()
        {
            string result = String.Empty;
            IntPtr buffer = NativeMethods.CreateCardBuffer();
            if (NativeMethods.SaveCardToToXMLStreamExW(reader.Index, buffer))
            {
                int size = NativeMethods.GetCardBufferSize(buffer);
                StringBuilder sb = new StringBuilder(size);
                NativeMethods.GetCardBufferW(buffer, sb, size);
                result = sb.ToString();
            }
            NativeMethods.DeleteCardBuffer(buffer);
            return result;
        }

        private string GetCsvStringW()
        {
            string result = String.Empty;
            IntPtr buffer = NativeMethods.CreateCardBuffer();
            if (NativeMethods.SavePersonCsvToStreamW(reader.Index, buffer))
            {
                int size = NativeMethods.GetCardBufferSize(buffer);
                StringBuilder sb = new StringBuilder(size);
                NativeMethods.GetCardBufferW(buffer, sb, size);
                result = sb.ToString();
            }
            NativeMethods.DeleteCardBuffer(buffer);
            return result;
        }

        /// <summary>
        /// Saves information from the card to the string.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="format">The format.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns></returns>
        public string Save(ExportFormat format)
        {
            switch (format)
            {
                case ExportFormat.Csv:
                    return GetCsvStringW();
                case ExportFormat.Xml:
                    return GetXmlStringW();
                default:
                    return null;
            }
        }

        /// <summary>
        /// Saves the QR code.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        public bool SaveQRCode(string fileName)
        {
            return NativeMethods.GenerateQRCodeEx(reader.Index, fileName);
        }

        #region IDisposable Members

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        internal void Dispose(bool disposing)
        {
            reader = null;
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
