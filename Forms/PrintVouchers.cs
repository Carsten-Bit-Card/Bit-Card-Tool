﻿// Copyright 2012 Mike Caldwell (Casascius)
// This file is part of Bitcoin Address Utility.

// Bitcoin Address Utility is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.

// Bitcoin Address Utility is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.

// You should have received a copy of the GNU General Public License
// along with Bitcoin Address Utility.  If not, see http://www.gnu.org/licenses/.


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using Casascius.Bitcoin;


namespace BtcAddress.Forms {

    /// <summary>
    /// This is a form for printing vouchers from a selection of KeyCollectionItems which should be prepopulated
    /// before the form is shown.
    /// </summary>
    public partial class PrintVouchers : Form {


        public List<KeyCollectionItem> Items = new List<KeyCollectionItem>();

        public bool PrintAttempted = false;

        public PrintVouchers() {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            txtDenomination.Text += ((LinkLabel)sender).Text;
        }

        private void button1_Click(object sender, EventArgs e) {
            PrintDialog pd = new PrintDialog();
            PrinterSettings ps = new PrinterSettings();
            pd.PrinterSettings = ps;
            DialogResult dr = pd.ShowDialog();

            if (dr == DialogResult.OK) {
                QRPrint printer = new QRPrint();
                printer.PrintMode = QRPrint.PrintModes.PsyBanknote;
                printer.NotesPerPage = (int)numVouchersPerPage.Value;
                switch (cboArtworkStyle.Text.ToLower()) {
                    case "yellow":
                    case "green":
                    case "blue":
                    case "purple":
                    case "greyscale":
                        printer.ImageFilename = "note-" + cboArtworkStyle.SelectedItem.ToString().ToLowerInvariant() + ".png";
                        break;
                }
                printer.Denomination = txtDenomination.Text;
                printer.keys = new List<KeyCollectionItem>(Items.Count);
                printer.PreferUnencryptedPrivateKeys = chkPrintUnencrypted.Checked;
                foreach (KeyCollectionItem a in Items) printer.keys.Add(a);
                printer.PrinterSettings = pd.PrinterSettings;
                printer.Print();
                PrintAttempted = true;
            }
        }

        private void PrintVouchers_Load(object sender, EventArgs e) {
            this.Text = "Print " + Items.Count + " Vouchers";
            cboArtworkStyle.Text = "Yellow";

            foreach (var i in Items) {
                if (i.EncryptedKeyPair != null && i.EncryptedKeyPair.IsUnencryptedPrivateKeyAvailable()) {
                    chkPrintUnencrypted.Visible = true;
                    break;
                }
            }
        }

    }
}
