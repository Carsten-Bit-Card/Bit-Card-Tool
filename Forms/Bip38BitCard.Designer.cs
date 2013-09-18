namespace BtcAddress.Forms
{
    partial class Bip38BitCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bip38BitCard));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tbxGicPassphrase = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxGicIntermediateCode = new System.Windows.Forms.TextBox();
            this.btnGicGenerateIntermediateCode = new System.Windows.Forms.Button();
            this.btnVccVerifyConfirmationCode = new System.Windows.Forms.Button();
            this.tbxVccConfirmationCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxVccPassphrase = new System.Windows.Forms.TextBox();
            this.btnDpkDecryptPrivateKey = new System.Windows.Forms.Button();
            this.tbxDpkEncryptedPrivateKey = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxDpkPassphrase = new System.Windows.Forms.TextBox();
            this.tbxDpkPrivateKey = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxDpkAddress = new System.Windows.Forms.TextBox();
            this.tbxVccAddress = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(846, 175);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.btnGicGenerateIntermediateCode);
            this.tabPage1.Controls.Add(this.tbxGicIntermediateCode);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.tbxGicPassphrase);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(838, 149);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Generate Intermediate Code";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.lblResult);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.tbxVccAddress);
            this.tabPage2.Controls.Add(this.btnVccVerifyConfirmationCode);
            this.tabPage2.Controls.Add(this.tbxVccConfirmationCode);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.tbxVccPassphrase);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(838, 149);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Verify Confirmation Code";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.tbxDpkPrivateKey);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.tbxDpkAddress);
            this.tabPage3.Controls.Add(this.btnDpkDecryptPrivateKey);
            this.tabPage3.Controls.Add(this.tbxDpkEncryptedPrivateKey);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.tbxDpkPassphrase);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(838, 149);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Decrypt Private Key";
            // 
            // tbxGicPassphrase
            // 
            this.tbxGicPassphrase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxGicPassphrase.Location = new System.Drawing.Point(109, 6);
            this.tbxGicPassphrase.Name = "tbxGicPassphrase";
            this.tbxGicPassphrase.Size = new System.Drawing.Size(723, 20);
            this.tbxGicPassphrase.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Passphrase:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Intermediate Code:";
            // 
            // tbxGicIntermediateCode
            // 
            this.tbxGicIntermediateCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxGicIntermediateCode.Location = new System.Drawing.Point(109, 61);
            this.tbxGicIntermediateCode.Name = "tbxGicIntermediateCode";
            this.tbxGicIntermediateCode.Size = new System.Drawing.Size(723, 20);
            this.tbxGicIntermediateCode.TabIndex = 3;
            // 
            // btnGicGenerateIntermediateCode
            // 
            this.btnGicGenerateIntermediateCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGicGenerateIntermediateCode.Location = new System.Drawing.Point(109, 32);
            this.btnGicGenerateIntermediateCode.Name = "btnGicGenerateIntermediateCode";
            this.btnGicGenerateIntermediateCode.Size = new System.Drawing.Size(723, 23);
            this.btnGicGenerateIntermediateCode.TabIndex = 4;
            this.btnGicGenerateIntermediateCode.Text = "Generate Intermediate Code";
            this.btnGicGenerateIntermediateCode.UseVisualStyleBackColor = true;
            this.btnGicGenerateIntermediateCode.Click += new System.EventHandler(this.btnGicGenerateIntermediateCode_Click);
            // 
            // btnVccVerifyConfirmationCode
            // 
            this.btnVccVerifyConfirmationCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVccVerifyConfirmationCode.Location = new System.Drawing.Point(108, 59);
            this.btnVccVerifyConfirmationCode.Name = "btnVccVerifyConfirmationCode";
            this.btnVccVerifyConfirmationCode.Size = new System.Drawing.Size(723, 23);
            this.btnVccVerifyConfirmationCode.TabIndex = 9;
            this.btnVccVerifyConfirmationCode.Text = "Verify Confirmation Code";
            this.btnVccVerifyConfirmationCode.UseVisualStyleBackColor = true;
            this.btnVccVerifyConfirmationCode.Click += new System.EventHandler(this.btnVccVerifyConfirmationCode_Click);
            // 
            // tbxVccConfirmationCode
            // 
            this.tbxVccConfirmationCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxVccConfirmationCode.Location = new System.Drawing.Point(109, 33);
            this.tbxVccConfirmationCode.Name = "tbxVccConfirmationCode";
            this.tbxVccConfirmationCode.Size = new System.Drawing.Size(723, 20);
            this.tbxVccConfirmationCode.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Confirmation Code:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Passphrase:";
            // 
            // tbxVccPassphrase
            // 
            this.tbxVccPassphrase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxVccPassphrase.Location = new System.Drawing.Point(108, 7);
            this.tbxVccPassphrase.Name = "tbxVccPassphrase";
            this.tbxVccPassphrase.Size = new System.Drawing.Size(723, 20);
            this.tbxVccPassphrase.TabIndex = 5;
            // 
            // btnDpkDecryptPrivateKey
            // 
            this.btnDpkDecryptPrivateKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDpkDecryptPrivateKey.Location = new System.Drawing.Point(148, 62);
            this.btnDpkDecryptPrivateKey.Name = "btnDpkDecryptPrivateKey";
            this.btnDpkDecryptPrivateKey.Size = new System.Drawing.Size(683, 23);
            this.btnDpkDecryptPrivateKey.TabIndex = 14;
            this.btnDpkDecryptPrivateKey.Text = "Decrypt Private Key";
            this.btnDpkDecryptPrivateKey.UseVisualStyleBackColor = true;
            this.btnDpkDecryptPrivateKey.Click += new System.EventHandler(this.btnDpkDecryptPrivateKey_Click);
            // 
            // tbxDpkEncryptedPrivateKey
            // 
            this.tbxDpkEncryptedPrivateKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxDpkEncryptedPrivateKey.Location = new System.Drawing.Point(149, 36);
            this.tbxDpkEncryptedPrivateKey.Name = "tbxDpkEncryptedPrivateKey";
            this.tbxDpkEncryptedPrivateKey.Size = new System.Drawing.Size(682, 20);
            this.tbxDpkEncryptedPrivateKey.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Encrypted Private Key:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(77, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Passphrase:";
            // 
            // tbxDpkPassphrase
            // 
            this.tbxDpkPassphrase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxDpkPassphrase.Location = new System.Drawing.Point(148, 10);
            this.tbxDpkPassphrase.Name = "tbxDpkPassphrase";
            this.tbxDpkPassphrase.Size = new System.Drawing.Size(683, 20);
            this.tbxDpkPassphrase.TabIndex = 10;
            // 
            // tbxDpkPrivateKey
            // 
            this.tbxDpkPrivateKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxDpkPrivateKey.Location = new System.Drawing.Point(148, 120);
            this.tbxDpkPrivateKey.Name = "tbxDpkPrivateKey";
            this.tbxDpkPrivateKey.Size = new System.Drawing.Size(682, 20);
            this.tbxDpkPrivateKey.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(48, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Private Key (WIF):";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(93, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Address:";
            // 
            // tbxDpkAddress
            // 
            this.tbxDpkAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxDpkAddress.Location = new System.Drawing.Point(147, 94);
            this.tbxDpkAddress.Name = "tbxDpkAddress";
            this.tbxDpkAddress.Size = new System.Drawing.Size(683, 20);
            this.tbxDpkAddress.TabIndex = 15;
            // 
            // tbxVccAddress
            // 
            this.tbxVccAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxVccAddress.Location = new System.Drawing.Point(108, 88);
            this.tbxVccAddress.Name = "tbxVccAddress";
            this.tbxVccAddress.Size = new System.Drawing.Size(723, 20);
            this.tbxVccAddress.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(54, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Address:";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.ForeColor = System.Drawing.Color.Green;
            this.lblResult.Location = new System.Drawing.Point(106, 111);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(394, 13);
            this.lblResult.TabIndex = 18;
            this.lblResult.Text = "It is confirmed that this Bitcoin address depends on this passphrase.";
            this.lblResult.Visible = false;
            // 
            // Bip38BitCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 199);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Bip38BitCard";
            this.Text = "Bit-Card-Tool";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox tbxGicPassphrase;
        private System.Windows.Forms.Button btnGicGenerateIntermediateCode;
        private System.Windows.Forms.TextBox tbxGicIntermediateCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnVccVerifyConfirmationCode;
        private System.Windows.Forms.TextBox tbxVccConfirmationCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxVccPassphrase;
        private System.Windows.Forms.TextBox tbxDpkPrivateKey;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbxDpkAddress;
        private System.Windows.Forms.Button btnDpkDecryptPrivateKey;
        private System.Windows.Forms.TextBox tbxDpkEncryptedPrivateKey;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxDpkPassphrase;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbxVccAddress;
        private System.Windows.Forms.Label lblResult;
    }
}