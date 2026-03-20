namespace EIDTestApp
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.buttonClose = new System.Windows.Forms.Button();
            this.picturePerson = new System.Windows.Forms.PictureBox();
            this.btnReadCard = new System.Windows.Forms.Button();
            this.Log = new System.Windows.Forms.TextBox();
            this.btnCertificate = new System.Windows.Forms.Button();
            this.gbPersonalData = new System.Windows.Forms.GroupBox();
            this.edtISO = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.edtMunicipality = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.edtSex = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.edtNationality = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.edtNationalNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.edtBirthPlace = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.edtBirthDate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.edtFirstName = new System.Windows.Forms.TextBox();
            this.edtLastName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.edtCity = new System.Windows.Forms.TextBox();
            this.edtZipCode = new System.Windows.Forms.TextBox();
            this.edtHouse = new System.Windows.Forms.TextBox();
            this.edtStreet = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.edtValidUntil = new System.Windows.Forms.TextBox();
            this.edtCardType = new System.Windows.Forms.TextBox();
            this.edtChipNumber = new System.Windows.Forms.TextBox();
            this.edtValidFrom = new System.Windows.Forms.TextBox();
            this.edtCardNumber = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.readerSelector = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.picturePerson)).BeginInit();
            this.gbPersonalData.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonClose.Location = new System.Drawing.Point(792, 324);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(192, 28);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // picturePerson
            // 
            this.picturePerson.Location = new System.Drawing.Point(792, 15);
            this.picturePerson.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picturePerson.Name = "picturePerson";
            this.picturePerson.Size = new System.Drawing.Size(193, 230);
            this.picturePerson.TabIndex = 4;
            this.picturePerson.TabStop = false;
            // 
            // btnReadCard
            // 
            this.btnReadCard.Enabled = false;
            this.btnReadCard.Location = new System.Drawing.Point(792, 288);
            this.btnReadCard.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReadCard.Name = "btnReadCard";
            this.btnReadCard.Size = new System.Drawing.Size(192, 28);
            this.btnReadCard.TabIndex = 5;
            this.btnReadCard.Text = "Read Card";
            this.btnReadCard.UseVisualStyleBackColor = true;
            this.btnReadCard.Click += new System.EventHandler(this.ReadCardData);
            // 
            // Log
            // 
            this.Log.Location = new System.Drawing.Point(16, 538);
            this.Log.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Log.Multiline = true;
            this.Log.Name = "Log";
            this.Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Log.Size = new System.Drawing.Size(967, 98);
            this.Log.TabIndex = 7;
            // 
            // btnCertificate
            // 
            this.btnCertificate.Enabled = false;
            this.btnCertificate.Location = new System.Drawing.Point(792, 252);
            this.btnCertificate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCertificate.Name = "btnCertificate";
            this.btnCertificate.Size = new System.Drawing.Size(192, 28);
            this.btnCertificate.TabIndex = 8;
            this.btnCertificate.Text = "Sign Certificate";
            this.btnCertificate.UseVisualStyleBackColor = true;
            this.btnCertificate.Click += new System.EventHandler(this.button1_Click);
            // 
            // gbPersonalData
            // 
            this.gbPersonalData.Controls.Add(this.edtISO);
            this.gbPersonalData.Controls.Add(this.label15);
            this.gbPersonalData.Controls.Add(this.edtMunicipality);
            this.gbPersonalData.Controls.Add(this.label7);
            this.gbPersonalData.Controls.Add(this.edtSex);
            this.gbPersonalData.Controls.Add(this.label6);
            this.gbPersonalData.Controls.Add(this.edtNationality);
            this.gbPersonalData.Controls.Add(this.label5);
            this.gbPersonalData.Controls.Add(this.edtNationalNumber);
            this.gbPersonalData.Controls.Add(this.label4);
            this.gbPersonalData.Controls.Add(this.edtBirthPlace);
            this.gbPersonalData.Controls.Add(this.label3);
            this.gbPersonalData.Controls.Add(this.edtBirthDate);
            this.gbPersonalData.Controls.Add(this.label2);
            this.gbPersonalData.Controls.Add(this.edtFirstName);
            this.gbPersonalData.Controls.Add(this.edtLastName);
            this.gbPersonalData.Controls.Add(this.label1);
            this.gbPersonalData.Location = new System.Drawing.Point(16, 50);
            this.gbPersonalData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbPersonalData.Name = "gbPersonalData";
            this.gbPersonalData.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbPersonalData.Size = new System.Drawing.Size(748, 230);
            this.gbPersonalData.TabIndex = 9;
            this.gbPersonalData.TabStop = false;
            this.gbPersonalData.Text = "Personal Information";
            // 
            // edtISO
            // 
            this.edtISO.Location = new System.Drawing.Point(412, 198);
            this.edtISO.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.edtISO.Name = "edtISO";
            this.edtISO.ReadOnly = true;
            this.edtISO.Size = new System.Drawing.Size(65, 22);
            this.edtISO.TabIndex = 16;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(380, 202);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 16);
            this.label15.TabIndex = 15;
            this.label15.Text = "ISO";
            // 
            // edtMunicipality
            // 
            this.edtMunicipality.Location = new System.Drawing.Point(384, 169);
            this.edtMunicipality.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.edtMunicipality.Name = "edtMunicipality";
            this.edtMunicipality.ReadOnly = true;
            this.edtMunicipality.Size = new System.Drawing.Size(321, 22);
            this.edtMunicipality.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(223, 172);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "Municipality";
            // 
            // edtSex
            // 
            this.edtSex.Location = new System.Drawing.Point(151, 169);
            this.edtSex.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.edtSex.Name = "edtSex";
            this.edtSex.ReadOnly = true;
            this.edtSex.Size = new System.Drawing.Size(35, 22);
            this.edtSex.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 172);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Sex";
            // 
            // edtNationality
            // 
            this.edtNationality.Location = new System.Drawing.Point(487, 134);
            this.edtNationality.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.edtNationality.Name = "edtNationality";
            this.edtNationality.ReadOnly = true;
            this.edtNationality.Size = new System.Drawing.Size(219, 22);
            this.edtNationality.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(404, 138);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Nationality";
            // 
            // edtNationalNumber
            // 
            this.edtNationalNumber.Location = new System.Drawing.Point(151, 134);
            this.edtNationalNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.edtNationalNumber.Name = "edtNationalNumber";
            this.edtNationalNumber.ReadOnly = true;
            this.edtNationalNumber.Size = new System.Drawing.Size(233, 22);
            this.edtNationalNumber.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 138);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "National Number";
            // 
            // edtBirthPlace
            // 
            this.edtBirthPlace.Location = new System.Drawing.Point(151, 100);
            this.edtBirthPlace.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.edtBirthPlace.Name = "edtBirthPlace";
            this.edtBirthPlace.ReadOnly = true;
            this.edtBirthPlace.Size = new System.Drawing.Size(555, 22);
            this.edtBirthPlace.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 103);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Birth Place";
            // 
            // edtBirthDate
            // 
            this.edtBirthDate.Location = new System.Drawing.Point(151, 65);
            this.edtBirthDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.edtBirthDate.Name = "edtBirthDate";
            this.edtBirthDate.ReadOnly = true;
            this.edtBirthDate.Size = new System.Drawing.Size(132, 22);
            this.edtBirthDate.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 69);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Birth Date";
            // 
            // edtFirstName
            // 
            this.edtFirstName.Location = new System.Drawing.Point(408, 31);
            this.edtFirstName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.edtFirstName.Name = "edtFirstName";
            this.edtFirstName.ReadOnly = true;
            this.edtFirstName.Size = new System.Drawing.Size(297, 22);
            this.edtFirstName.TabIndex = 2;
            // 
            // edtLastName
            // 
            this.edtLastName.Location = new System.Drawing.Point(151, 31);
            this.edtLastName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.edtLastName.Name = "edtLastName";
            this.edtLastName.ReadOnly = true;
            this.edtLastName.Size = new System.Drawing.Size(233, 22);
            this.edtLastName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.edtCity);
            this.groupBox1.Controls.Add(this.edtZipCode);
            this.groupBox1.Controls.Add(this.edtHouse);
            this.groupBox1.Controls.Add(this.edtStreet);
            this.groupBox1.Location = new System.Drawing.Point(16, 288);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(748, 98);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Address";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 59);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 16);
            this.label9.TabIndex = 11;
            this.label9.Text = "City";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 31);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "Street";
            // 
            // edtCity
            // 
            this.edtCity.Location = new System.Drawing.Point(227, 59);
            this.edtCity.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.edtCity.Name = "edtCity";
            this.edtCity.ReadOnly = true;
            this.edtCity.Size = new System.Drawing.Size(479, 22);
            this.edtCity.TabIndex = 9;
            // 
            // edtZipCode
            // 
            this.edtZipCode.Location = new System.Drawing.Point(151, 59);
            this.edtZipCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.edtZipCode.Name = "edtZipCode";
            this.edtZipCode.ReadOnly = true;
            this.edtZipCode.Size = new System.Drawing.Size(67, 22);
            this.edtZipCode.TabIndex = 8;
            this.edtZipCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtHouse
            // 
            this.edtHouse.Location = new System.Drawing.Point(616, 22);
            this.edtHouse.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.edtHouse.Name = "edtHouse";
            this.edtHouse.ReadOnly = true;
            this.edtHouse.Size = new System.Drawing.Size(89, 22);
            this.edtHouse.TabIndex = 7;
            this.edtHouse.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtStreet
            // 
            this.edtStreet.Location = new System.Drawing.Point(151, 22);
            this.edtStreet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.edtStreet.Name = "edtStreet";
            this.edtStreet.ReadOnly = true;
            this.edtStreet.Size = new System.Drawing.Size(456, 22);
            this.edtStreet.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.edtValidUntil);
            this.groupBox2.Controls.Add(this.edtCardType);
            this.groupBox2.Controls.Add(this.edtChipNumber);
            this.groupBox2.Controls.Add(this.edtValidFrom);
            this.groupBox2.Controls.Add(this.edtCardNumber);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(16, 395);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(748, 134);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Card Information";
            // 
            // edtValidUntil
            // 
            this.edtValidUntil.Location = new System.Drawing.Point(471, 55);
            this.edtValidUntil.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.edtValidUntil.Name = "edtValidUntil";
            this.edtValidUntil.ReadOnly = true;
            this.edtValidUntil.Size = new System.Drawing.Size(132, 22);
            this.edtValidUntil.TabIndex = 9;
            // 
            // edtCardType
            // 
            this.edtCardType.Location = new System.Drawing.Point(471, 20);
            this.edtCardType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.edtCardType.Name = "edtCardType";
            this.edtCardType.ReadOnly = true;
            this.edtCardType.Size = new System.Drawing.Size(235, 22);
            this.edtCardType.TabIndex = 8;
            // 
            // edtChipNumber
            // 
            this.edtChipNumber.Location = new System.Drawing.Point(151, 91);
            this.edtChipNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.edtChipNumber.Name = "edtChipNumber";
            this.edtChipNumber.ReadOnly = true;
            this.edtChipNumber.Size = new System.Drawing.Size(555, 22);
            this.edtChipNumber.TabIndex = 7;
            // 
            // edtValidFrom
            // 
            this.edtValidFrom.Location = new System.Drawing.Point(151, 55);
            this.edtValidFrom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.edtValidFrom.Name = "edtValidFrom";
            this.edtValidFrom.ReadOnly = true;
            this.edtValidFrom.Size = new System.Drawing.Size(132, 22);
            this.edtValidFrom.TabIndex = 6;
            // 
            // edtCardNumber
            // 
            this.edtCardNumber.Location = new System.Drawing.Point(151, 20);
            this.edtCardNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.edtCardNumber.Name = "edtCardNumber";
            this.edtCardNumber.ReadOnly = true;
            this.edtCardNumber.Size = new System.Drawing.Size(221, 22);
            this.edtCardNumber.TabIndex = 5;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(408, 59);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(33, 16);
            this.label14.TabIndex = 4;
            this.label14.Text = "Until";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(404, 23);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(39, 16);
            this.label13.TabIndex = 3;
            this.label13.Text = "Type";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 95);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(85, 16);
            this.label12.TabIndex = 2;
            this.label12.Text = "Chip Number";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 59);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 16);
            this.label11.TabIndex = 1;
            this.label11.Text = "Valid From";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 23);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 16);
            this.label10.TabIndex = 0;
            this.label10.Text = "Card Number";
            // 
            // readerSelector
            // 
            this.readerSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.readerSelector.FormattingEnabled = true;
            this.readerSelector.Location = new System.Drawing.Point(16, 17);
            this.readerSelector.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.readerSelector.Name = "readerSelector";
            this.readerSelector.Size = new System.Drawing.Size(747, 24);
            this.readerSelector.TabIndex = 12;
            this.readerSelector.SelectedIndexChanged += new System.EventHandler(this.readerSelector_SelectedIndexChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 651);
            this.Controls.Add(this.readerSelector);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbPersonalData);
            this.Controls.Add(this.btnCertificate);
            this.Controls.Add(this.Log);
            this.Controls.Add(this.btnReadCard);
            this.Controls.Add(this.picturePerson);
            this.Controls.Add(this.buttonClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EID";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.picturePerson)).EndInit();
            this.gbPersonalData.ResumeLayout(false);
            this.gbPersonalData.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.PictureBox picturePerson;
        private System.Windows.Forms.Button btnReadCard;
        private System.Windows.Forms.TextBox Log;
        private System.Windows.Forms.Button btnCertificate;
        private System.Windows.Forms.GroupBox gbPersonalData;
        private System.Windows.Forms.TextBox edtFirstName;
        private System.Windows.Forms.TextBox edtLastName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox edtSex;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox edtNationality;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox edtNationalNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox edtBirthPlace;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox edtBirthDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox edtCity;
        private System.Windows.Forms.TextBox edtZipCode;
        private System.Windows.Forms.TextBox edtHouse;
        private System.Windows.Forms.TextBox edtStreet;
        private System.Windows.Forms.TextBox edtValidUntil;
        private System.Windows.Forms.TextBox edtCardType;
        private System.Windows.Forms.TextBox edtChipNumber;
        private System.Windows.Forms.TextBox edtValidFrom;
        private System.Windows.Forms.TextBox edtCardNumber;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox edtMunicipality;
        private System.Windows.Forms.ComboBox readerSelector;
        private System.Windows.Forms.TextBox edtISO;
        private System.Windows.Forms.Label label15;
    }
}

