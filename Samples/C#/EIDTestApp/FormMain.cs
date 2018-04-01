//Security Note
//
//This sample code is provided to illustrate a concept and should not be used in applications, 
//as it may not illustrate the safest coding practices. 
//Author assumes no liability for incidental or consequential damages should the sample code be 
//used for purposes other than as intended.

using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Swelio.Engine;

namespace EIDTestApp
{
    public partial class FormMain : Form
    {

        private Manager engine;

        public FormMain()
        {
            InitializeComponent();
        }


        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GetInfoFromCard()
        {
            string street;

            DoClearData();

            CardReader reader = engine.GetReader();
            if (reader == null)
            {
                MessageBox.Show("Can not connect to the card reader");
                return;
            }

            Card card = engine.GetReader().GetCard(true);
            if (card == null)
                return;

            Identity identity = card.ReadIdentity();
            Address address = card.ReadAddress();

            if ((identity != null) && (address != null))
            {
                street = address.Street;
                street = street.Trim();
                int idx = street.Length - 1;

                while (idx > 0)
                {
                    if (street[idx] == ' ')
                        break;
                    else
                        --idx;
                }

                if (idx > 1)
                {
                    edtHouse.Text = street.Substring(idx + 1, street.Length - idx - 1);
                    if (edtHouse.Text[0] == '/')
                        edtHouse.Text = edtHouse.Text.Substring(1);
                    edtStreet.Text = street.Substring(0, idx);
                }
                else
                {
                    edtStreet.Text = street;
                }

                edtBirthDate.Text = identity.BirthDate.ToShortDateString();
                edtBirthPlace.Text = identity.BirthLocation;
                edtCardNumber.Text = CardNumber.ToString(identity.CardNumber);
                switch (identity.DocumentType)
                {
                    case DocumentType.Unknown:
                        edtCardType.Text = "Unknown";
                        break;
                    case DocumentType.BelgianCitizen:
                        edtCardType.Text = "Belgian Citizen";
                        break;
                    case DocumentType.EuropeanCommunity:
                        edtCardType.Text = "European Community";
                        break;
                    case DocumentType.NonEuropeanCommunity:
                        edtCardType.Text = "Non European Community";
                        break;
                    case DocumentType.KidsCard:
                        edtCardType.Text = "Kids Card";
                        break;
                    case DocumentType.BootstrapCard:
                        edtCardType.Text = "Bootstrap Card";
                        break;
                    case DocumentType.HabilitationCard:
                        edtCardType.Text = "Habilitation Card";
                        break;
                    case DocumentType.ForeignerCard:
                        edtCardType.Text = "Foreigner Card";
                        break;
                    default:
                        break;
                }

                edtChipNumber.Text = identity.ChipNumber;
                edtCity.Text = address.Municipality;
                edtFirstName.Text = identity.FirstName1 + " " + identity.FirstName2;
                edtLastName.Text = identity.Surname;
                edtMunicipality.Text = identity.Municipality;
                edtNationality.Text = identity.Nationality;
                edtNationalNumber.Text = NationalNumber.ToString(identity.NationalNumber);
                if (identity.Sex == Gender.Female)
                    edtSex.Text = "F";
                else
                    edtSex.Text = "M";
                edtValidFrom.Text = identity.ValidityDateBegin.ToShortDateString();
                edtValidUntil.Text = identity.ValidityDateEnd.ToShortDateString();
                edtZipCode.Text = address.Zip;
                edtISO.Text = identity.NationalityISO;

                Image photo = card.ReadPhoto();
                if (photo != null)
                {
                    picturePerson.Image = photo;
                }
                else
                    MessageBox.Show("Can not read EID picture");

                btnCertificate.Enabled = true;
            }
            else
                MessageBox.Show("Can not read EID card");
        }

        private void ReadCardData(object sender, EventArgs e)
        {
            GetInfoFromCard();
        }

        private void DoClearData()
        {
            picturePerson.Image = null;

            edtBirthDate.Text = "";
            edtBirthPlace.Text = "";
            edtCardNumber.Text = "";
            edtCardType.Text = "";
            edtChipNumber.Text = "";
            edtCity.Text = "";
            edtFirstName.Text = "";
            edtHouse.Text = "";
            edtLastName.Text = "";
            edtMunicipality.Text = "";
            edtNationality.Text = "";
            edtNationalNumber.Text = "";
            edtSex.Text = "";
            edtStreet.Text = "";
            edtValidFrom.Text = "";
            edtValidUntil.Text = "";
            edtZipCode.Text = "";
            edtISO.Text = "";
        }



        /// <summary>
        /// Prepares the Swelio Engine and makes the list of the available card readers
        /// </summary>
        private void PrepareSystemForAction()
        {
            engine = new Manager();
            engine.Active = true;
            UpdateReadersList();
        }

        private void ActivateCardEventsTracing()
        {
            engine.CardInserted += new EventHandler<CardEventArgs>(engine_CardInserted);
            engine.CardRemoved += new EventHandler<CardEventArgs>(engine_CardRemoved);
            engine.ReadersListChanged += new EventHandler(engine_ReadersListChanged);
            engine.TraceEvents = true;
        }

        private void UpdateReadersList()
        {
            readerSelector.Items.Clear();
            string[] readers = engine.ListReaders();
            if (readers != null)
            {
                readerSelector.Items.AddRange(readers);
                readerSelector.Enabled = true;
            }
            else
            {
                readerSelector.Enabled = false;
                readerSelector.Items.Add("No card readers available");
            }


            if (readerSelector.Items.Count > 0)
            {
                readerSelector.SelectedIndex = 0;
            }
        }

        void engine_ReadersListChanged(object sender, EventArgs e)
        {

            btnCertificate.Enabled = false;
            btnReadCard.Enabled = false;
            DoClearData();
            Log.AppendText(DateTime.Now.ToLongTimeString() + " Readers list changed" + Environment.NewLine);
            UpdateReadersList();
            engine.TraceEvents = true;
        }

        void engine_CardRemoved(object sender, CardEventArgs e)
        {
            btnCertificate.Enabled = false;
            btnReadCard.Enabled = false;
            DoClearData();
            Log.AppendText(DateTime.Now.ToLongTimeString() + " Card removed from the reader N " + e.ReaderNumber.ToString() + Environment.NewLine);
        }

        void engine_CardInserted(object sender, CardEventArgs e)
        {
            btnCertificate.Enabled = true;
            btnReadCard.Enabled = true;
            readerSelector.SelectedIndex = e.ReaderNumber;
            Log.AppendText(DateTime.Now.ToLongTimeString() + " Card inserted in the reader N " + e.ReaderNumber.ToString() + Environment.NewLine);
            GetInfoFromCard();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            PrepareSystemForAction();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            engine.Active = false;
            engine.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CardReader reader = engine.GetReader();
            if (reader != null)
            {
                Card card = reader.GetCard();
                if (card != null)
                    card.DisplayCertificate(CertificateType.AuthenticationCertificate);
            }
        }

        private void readerSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            engine.SetDefaultReader(readerSelector.SelectedIndex);
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            ActivateCardEventsTracing();
        }


    }
}