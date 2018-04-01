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
            this.buttonClose.Location = new System.Drawing.Point(594, 263);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(144, 23);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // picturePerson
            // 
            this.picturePerson.Location = new System.Drawing.Point(594, 12);
            this.picturePerson.Name = "picturePerson";
            this.picturePerson.Size = new System.Drawing.Size(145, 187);
            this.picturePerson.TabIndex = 4;
            this.picturePerson.TabStop = false;
            // 
            // btnReadCard
            // 
            this.btnReadCard.Enabled = false;
            this.btnReadCard.Location = new System.Drawing.Point(594, 234);
            this.btnReadCard.Name = "btnReadCard";
            this.btnReadCard.Size = new System.Drawing.Size(144, 23);
            this.btnReadCard.TabIndex = 5;
            this.btnReadCard.Text = "Read Card";
            this.btnReadCard.UseVisualStyleBackColor = true;
            this.btnReadCard.Click += new System.EventHandler(this.ReadCardData);
            // 
            // Log
            // 
            this.Log.Location = new System.Drawing.Point(12, 437);
            this.Log.Multiline = true;
            this.Log.Name = "Log";
            this.Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Log.Size = new System.Drawing.Size(726, 80);
            this.Log.TabIndex = 7;
            // 
            // btnCertificate
            // 
            this.btnCertificate.Enabled = false;
            this.btnCertificate.Location = new System.Drawing.Point(594, 205);
            this.btnCertificate.Name = "btnCertificate";
            this.btnCertificate.Size = new System.Drawing.Size(144, 23);
            this.btnCertificate.TabIndex = 8;
            this.btnCertificate.Text = "Auth Certificate";
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
            this.gbPersonalData.Location = new System.Drawing.Point(12, 41);
            this.gbPersonalData.Name = "gbPersonalData";
            this.gbPersonalData.Size = new System.Drawing.Size(561, 187);
            this.gbPersonalData.TabIndex = 9;
            this.gbPersonalData.TabStop = false;
            this.gbPersonalData.Text = "Personal Information";
            // 
            // edtISO
            // 
            this.edtISO.Location = new System.Drawing.Point(309, 161);
            this.edtISO.Name = "edtISO";
            this.edtISO.ReadOnly = true;
            this.edtISO.Size = new System.Drawing.Size(50, 20);
            this.edtISO.TabIndex = 16;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(285, 164);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(25, 13);
            this.label15.TabIndex = 15;
            this.label15.Text = "ISO";
            // 
            // edtMunicipality
            // 
            this.edtMunicipality.Location = new System.Drawing.Point(288, 137);
            this.edtMunicipality.Name = "edtMunicipality";
            this.edtMunicipality.ReadOnly = true;
            this.edtMunicipality.Size = new System.Drawing.Size(242, 20);
            this.edtMunicipality.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(167, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Municipality";
            // 
            // edtSex
            // 
            this.edtSex.Location = new System.Drawing.Point(113, 137);
            this.edtSex.Name = "edtSex";
            this.edtSex.ReadOnly = true;
            this.edtSex.Size = new System.Drawing.Size(27, 20);
            this.edtSex.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Sex";
            // 
            // edtNationality
            // 
            this.edtNationality.Location = new System.Drawing.Point(365, 109);
            this.edtNationality.Name = "edtNationality";
            this.edtNationality.ReadOnly = true;
            this.edtNationality.Size = new System.Drawing.Size(165, 20);
            this.edtNationality.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(303, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Nationality";
            // 
            // edtNationalNumber
            // 
            this.edtNationalNumber.Location = new System.Drawing.Point(113, 109);
            this.edtNationalNumber.Name = "edtNationalNumber";
            this.edtNationalNumber.ReadOnly = true;
            this.edtNationalNumber.Size = new System.Drawing.Size(176, 20);
            this.edtNationalNumber.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "National Number";
            // 
            // edtBirthPlace
            // 
            this.edtBirthPlace.Location = new System.Drawing.Point(113, 81);
            this.edtBirthPlace.Name = "edtBirthPlace";
            this.edtBirthPlace.ReadOnly = true;
            this.edtBirthPlace.Size = new System.Drawing.Size(417, 20);
            this.edtBirthPlace.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Birth Place";
            // 
            // edtBirthDate
            // 
            this.edtBirthDate.Location = new System.Drawing.Point(113, 53);
            this.edtBirthDate.Name = "edtBirthDate";
            this.edtBirthDate.ReadOnly = true;
            this.edtBirthDate.Size = new System.Drawing.Size(100, 20);
            this.edtBirthDate.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Birth Date";
            // 
            // edtFirstName
            // 
            this.edtFirstName.Location = new System.Drawing.Point(306, 25);
            this.edtFirstName.Name = "edtFirstName";
            this.edtFirstName.ReadOnly = true;
            this.edtFirstName.Size = new System.Drawing.Size(224, 20);
            this.edtFirstName.TabIndex = 2;
            // 
            // edtLastName
            // 
            this.edtLastName.Location = new System.Drawing.Point(113, 25);
            this.edtLastName.Name = "edtLastName";
            this.edtLastName.ReadOnly = true;
            this.edtLastName.Size = new System.Drawing.Size(176, 20);
            this.edtLastName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
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
            this.groupBox1.Location = new System.Drawing.Point(12, 234);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(561, 80);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Address";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "City";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Street";
            // 
            // edtCity
            // 
            this.edtCity.Location = new System.Drawing.Point(170, 48);
            this.edtCity.Name = "edtCity";
            this.edtCity.ReadOnly = true;
            this.edtCity.Size = new System.Drawing.Size(360, 20);
            this.edtCity.TabIndex = 9;
            // 
            // edtZipCode
            // 
            this.edtZipCode.Location = new System.Drawing.Point(113, 48);
            this.edtZipCode.Name = "edtZipCode";
            this.edtZipCode.ReadOnly = true;
            this.edtZipCode.Size = new System.Drawing.Size(51, 20);
            this.edtZipCode.TabIndex = 8;
            this.edtZipCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtHouse
            // 
            this.edtHouse.Location = new System.Drawing.Point(462, 18);
            this.edtHouse.Name = "edtHouse";
            this.edtHouse.ReadOnly = true;
            this.edtHouse.Size = new System.Drawing.Size(68, 20);
            this.edtHouse.TabIndex = 7;
            this.edtHouse.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtStreet
            // 
            this.edtStreet.Location = new System.Drawing.Point(113, 18);
            this.edtStreet.Name = "edtStreet";
            this.edtStreet.ReadOnly = true;
            this.edtStreet.Size = new System.Drawing.Size(343, 20);
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
            this.groupBox2.Location = new System.Drawing.Point(12, 321);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(561, 109);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Card Information";
            // 
            // edtValidUntil
            // 
            this.edtValidUntil.Location = new System.Drawing.Point(353, 45);
            this.edtValidUntil.Name = "edtValidUntil";
            this.edtValidUntil.ReadOnly = true;
            this.edtValidUntil.Size = new System.Drawing.Size(100, 20);
            this.edtValidUntil.TabIndex = 9;
            // 
            // edtCardType
            // 
            this.edtCardType.Location = new System.Drawing.Point(353, 16);
            this.edtCardType.Name = "edtCardType";
            this.edtCardType.ReadOnly = true;
            this.edtCardType.Size = new System.Drawing.Size(177, 20);
            this.edtCardType.TabIndex = 8;
            // 
            // edtChipNumber
            // 
            this.edtChipNumber.Location = new System.Drawing.Point(113, 74);
            this.edtChipNumber.Name = "edtChipNumber";
            this.edtChipNumber.ReadOnly = true;
            this.edtChipNumber.Size = new System.Drawing.Size(417, 20);
            this.edtChipNumber.TabIndex = 7;
            // 
            // edtValidFrom
            // 
            this.edtValidFrom.Location = new System.Drawing.Point(113, 45);
            this.edtValidFrom.Name = "edtValidFrom";
            this.edtValidFrom.ReadOnly = true;
            this.edtValidFrom.Size = new System.Drawing.Size(100, 20);
            this.edtValidFrom.TabIndex = 6;
            // 
            // edtCardNumber
            // 
            this.edtCardNumber.Location = new System.Drawing.Point(113, 16);
            this.edtCardNumber.Name = "edtCardNumber";
            this.edtCardNumber.ReadOnly = true;
            this.edtCardNumber.Size = new System.Drawing.Size(167, 20);
            this.edtCardNumber.TabIndex = 5;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(306, 48);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(28, 13);
            this.label14.TabIndex = 4;
            this.label14.Text = "Until";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(303, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 13);
            this.label13.TabIndex = 3;
            this.label13.Text = "Type";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 77);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Chip Number";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Valid From";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Card Number";
            // 
            // readerSelector
            // 
            this.readerSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.readerSelector.FormattingEnabled = true;
            this.readerSelector.Location = new System.Drawing.Point(12, 14);
            this.readerSelector.Name = "readerSelector";
            this.readerSelector.Size = new System.Drawing.Size(561, 21);
            this.readerSelector.TabIndex = 12;
            this.readerSelector.SelectedIndexChanged += new System.EventHandler(this.readerSelector_SelectedIndexChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 529);
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
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EID";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
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

