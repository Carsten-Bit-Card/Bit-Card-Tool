using Casascius.Bitcoin;
using CryptSharp.Utility;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace BtcAddress.Forms
{
    public partial class Bip38BitCard : Form
    {
        public Bip38BitCard()
        {
            InitializeComponent();
        }

        private void btnDpkDecryptPrivateKey_Click(object sender, EventArgs e)
        {
            // Remove any spaces or dashes from the encrypted key (in case they were typed)
            tbxDpkEncryptedPrivateKey.Text = tbxDpkEncryptedPrivateKey.Text.Replace("-", "").Replace(" ", "");

            if (tbxDpkEncryptedPrivateKey.Text == "" || tbxDpkPassphrase.Text == "")
            {
                MessageBox.Show("Enter an encrypted key and its passphrase.", "Entries Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // What were we given as encrypted text?

            object encrypted = StringInterpreter.Interpret(tbxDpkEncryptedPrivateKey.Text);

            if (encrypted == null) {
                if (tbxDpkEncryptedPrivateKey.Text.StartsWith("cfrm38"))
                {
                    var r = MessageBox.Show("This is not a private key.  This looks like a confirmation code.  " +
                        "Do you want to open the Confirmation Code Validator?", "Invalid private key", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (r == DialogResult.Yes) {
                        Program.ShowConfValidator();
                    }
                    return;
                }


                string containsL = "";
                if (tbxDpkEncryptedPrivateKey.Text.Contains("l"))
                {
                    containsL = " Your entry contains the lowercase letter l.  Private keys are far " +
                        "more likely to contain the digit 1, and not the lowercase letter l.";
                }

                MessageBox.Show("The private key entry (top box) was invalid.  " +
                    "Please verify the private key was properly typed." + containsL, "Invalid private key", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            } if (encrypted is PassphraseKeyPair) {
                PassphraseKeyPair pkp = encrypted as PassphraseKeyPair;
                if (pkp.DecryptWithPassphrase(tbxDpkPassphrase.Text) == false)
                {
                    MessageBox.Show("The passphrase is incorrect.", "Could not decrypt", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                MessageBox.Show("Decryption successful.", "Decryption", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tbxDpkAddress.Text = pkp.GetAddress().AddressBase58;
                tbxDpkPrivateKey.Text = pkp.GetUnencryptedPrivateKey().PrivateKeyBase58;

                //Program.ShowAddressUtility();
                //Program.AddressUtility.DisplayKeyCollectionItem(new KeyCollectionItem(pkp.GetUnencryptedPrivateKey()));
                return;                        
            } else if (encrypted is KeyPair) {
                // it's unencrypted - perhaps we're doing an EC multiply and the passphrase is a private key.

                object encrypted2 = StringInterpreter.Interpret(tbxDpkPassphrase.Text);
                if (encrypted2 == null) {
                    var r = MessageBox.Show("Does the key you entered belong to the following address?: " + (encrypted as KeyPair).AddressBase58,
                        "Key appears unencrypted",
                        MessageBoxButtons.YesNo);

                    if (r == DialogResult.Yes) {
                        r = MessageBox.Show("Then this key is already unencrypted and you don't need to decrypt it.  " +
                            "Would you like to open it in the Address Utility screen to see its various forms?", "Key is not encrypted", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (r == DialogResult.Yes) {
                            Program.ShowAddressUtility();
                            Program.AddressUtility.DisplayKeyCollectionItem(new KeyCollectionItem(encrypted as KeyPair));
                        }
                    } else {
                        MessageBox.Show("The passphrase or secondary key is incorrect.  Please verify it was properly typed.", "Second entry is not a valid private key", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    return;
                }


                BigInteger n1 = new BigInteger(1, (encrypted as KeyPair).PrivateKeyBytes);
                BigInteger n2 = new BigInteger(1, (encrypted2 as KeyPair).PrivateKeyBytes);
                var ps = Org.BouncyCastle.Asn1.Sec.SecNamedCurves.GetByName("secp256k1");
                BigInteger privatekey = n1.Multiply(n2).Mod(ps.N);
                MessageBox.Show("Keys successfully combined using EC multiplication.", "EC multiplication successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (n1.Equals(n2)) {
                    MessageBox.Show("The two key entries have the same public hash.  The results you see might be wrong.", "Duplicate key hash", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // use private key
                KeyPair kp = new KeyPair(privatekey);
                tbxDpkAddress.Text = kp.AddressBase58;
                tbxDpkPrivateKey.Text = kp.PrivateKeyBase58;
                //Program.ShowAddressUtility();
                //Program.AddressUtility.DisplayKeyCollectionItem(new KeyCollectionItem(kp));



            } else if (encrypted is AddressBase) {
                MessageBox.Show("This is not a private key.  It looks like an address or a public key.  Private keys usually start with 5, 6, or S.", "Not a private key", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            } else {
                MessageBox.Show("This is not a private key that this program can decrypt.", "Not a recognized private key", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void btnGicGenerateIntermediateCode_Click(object sender, EventArgs e)
        {
            if ((tbxGicPassphrase.Text ?? "") == "")
            {
                MessageBox.Show("Enter a passphrase first.");
                return;
            }
            try
            {
                Bip38Intermediate intermediate = new Bip38Intermediate(tbxGicPassphrase.Text, Bip38Intermediate.Interpretation.Passphrase);
                tbxGicIntermediateCode.Text = intermediate.Code;
            }
            catch (Exception ae)
            {
                MessageBox.Show(ae.Message);
            }
        }

        private void btnVccVerifyConfirmationCode_Click(object sender, EventArgs e)
        {
             lblResult.Visible = false;
            

            // check for null entry
            if (tbxVccPassphrase.Text == "") {
                MessageBox.Show("Passphrase is required.", "Passphrase required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (tbxVccConfirmationCode.Text == "") {
                MessageBox.Show("Confirmation code is required.", "Confirmation code required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Parse confirmation code.
            byte[] confbytes = Util.Base58CheckToByteArray(tbxVccConfirmationCode.Text.Trim());
            if (confbytes == null) {
                // is it even close?
                if (tbxVccConfirmationCode.Text.StartsWith("cfrm38")) {
                    MessageBox.Show("This is not a valid confirmation code.  It has the right prefix, but " +
                        "doesn't contain valid confirmation data.  Possible typo or incomplete?", 
                        "Invalid confirmation code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                MessageBox.Show("This is not a valid confirmation code.", "Invalid confirmation code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (confbytes.Length != 51 || confbytes[0] != 0x64 || confbytes[1] != 0x3B || confbytes[2] != 0xF6 ||
                confbytes[3] != 0xA8 || confbytes[4] != 0x9A || confbytes[18] < 0x02 || confbytes[18] > 0x03) {

                // Unrecognized Base58 object.  Do we know what this is?  Tell the user.
                object result = StringInterpreter.Interpret(tbxVccConfirmationCode.Text.Trim());
                if (result != null) {

                    // did we actually get an encrypted private key?  if so, just try to decrypt it.
                    if (result is PassphraseKeyPair) {
                        PassphraseKeyPair ppkp = result as PassphraseKeyPair;
                        if (ppkp.DecryptWithPassphrase(tbxVccPassphrase.Text)) {
                            confirmIsValid(ppkp.GetAddress().AddressBase58);
                            MessageBox.Show("What you provided contains a private key, not just a confirmation. " +
                                "Confirmation is successful, and with this correct passphrase, " +
                                "you are also able to spend the funds from the address.", "This is actually a private key",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        } else {
                            MessageBox.Show("This is not a valid confirmation code.  It looks like an " +
                                "encrypted private key.  Decryption was attempted but the passphrase couldn't decrypt it", "Invalid confirmation code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }

                    string objectKind = result.GetType().Name;
                    if (objectKind == "AddressBase") {
                        objectKind = "an Address";
                    } else {
                        objectKind = "a " + objectKind;
                    }

                    MessageBox.Show("This is not a valid confirmation code.  Instead, it looks like " + objectKind +
                      ".  Perhaps you entered the wrong thing?  Confirmation codes " +
                    "start with \"cfrm\".", "Invalid confirmation code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                MessageBox.Show("This is not a valid confirmation code.", "Invalid confirmation code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
                
            }

            // extract ownersalt and get an intermediate
            byte[] ownersalt = new byte[8];
            Array.Copy(confbytes, 10, ownersalt, 0, 8);

            bool includeHashStep = (confbytes[5] & 0x04) == 0x04;
            Bip38Intermediate intermediate = new Bip38Intermediate(tbxVccPassphrase.Text, ownersalt, includeHashStep);

            // derive the 64 bytes we need
            // get ECPoint from passpoint            
            PublicKey pk = new PublicKey(intermediate.passpoint);

            byte[] addresshashplusownersalt = new byte[12];
            Array.Copy(confbytes, 6, addresshashplusownersalt, 0, 4);
            Array.Copy(intermediate.ownerentropy, 0, addresshashplusownersalt, 4, 8);

            // derive encryption key material
            byte[] derived = new byte[64];
            SCrypt.ComputeKey(intermediate.passpoint, addresshashplusownersalt, 1024, 1, 1, 1, derived);

            byte[] derivedhalf2 = new byte[32];
            Array.Copy(derived, 32, derivedhalf2, 0, 32);

            byte[] unencryptedpubkey = new byte[33];
            // recover the 0x02 or 0x03 prefix
            unencryptedpubkey[0] = (byte)(confbytes[18] ^ (derived[63] & 0x01));

            // decrypt
            var aes = Aes.Create();
            aes.KeySize = 256;
            aes.Mode = CipherMode.ECB;
            aes.Key = derivedhalf2;
            ICryptoTransform decryptor = aes.CreateDecryptor();

            decryptor.TransformBlock(confbytes, 19, 16, unencryptedpubkey, 1);
            decryptor.TransformBlock(confbytes, 19, 16, unencryptedpubkey, 1);
            decryptor.TransformBlock(confbytes, 19 + 16, 16, unencryptedpubkey, 17);
            decryptor.TransformBlock(confbytes, 19 + 16, 16, unencryptedpubkey, 17);

            // xor out the padding
            for (int i = 0; i < 32; i++) unencryptedpubkey[i + 1] ^= derived[i];

            // reconstitute the ECPoint
            var ps = Org.BouncyCastle.Asn1.Sec.SecNamedCurves.GetByName("secp256k1");
            ECPoint point;
            try {
                point = ps.Curve.DecodePoint(unencryptedpubkey);

                // multiply passfactor.  Result is going to be compressed.
                ECPoint pubpoint = point.Multiply(new BigInteger(1, intermediate.passfactor));

                // Do we want it uncompressed?  then we will have to uncompress it.
                byte flagbyte = confbytes[5];
                if ((flagbyte & 0x20) == 0x00) {
                    pubpoint = ps.Curve.CreatePoint(pubpoint.X.ToBigInteger(), pubpoint.Y.ToBigInteger(), false);
                }

                // Convert to bitcoin address and check address hash.
                PublicKey generatedaddress = new PublicKey(pubpoint);

                // get addresshash
                UTF8Encoding utf8 = new UTF8Encoding(false);
                Sha256Digest sha256 = new Sha256Digest();
                byte[] generatedaddressbytes = utf8.GetBytes(generatedaddress.AddressBase58);
                sha256.BlockUpdate(generatedaddressbytes, 0, generatedaddressbytes.Length);
                byte[] addresshashfull = new byte[32];
                sha256.DoFinal(addresshashfull, 0);
                sha256.BlockUpdate(addresshashfull, 0, 32);
                sha256.DoFinal(addresshashfull, 0);

                for (int i = 0; i < 4; i++) {
                    if (addresshashfull[i] != confbytes[i + 6]) {
                        MessageBox.Show("This passphrase is wrong or does not belong to this confirmation code.", "Invalid passphrase", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                confirmIsValid(generatedaddress.AddressBase58);
            } catch {
                // Might throw an exception - not every 256-bit integer is a valid X coordinate
                MessageBox.Show("This passphrase is wrong or does not belong to this confirmation code.", "Invalid passphrase", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

        }

        private void confirmIsValid(string address) {
            tbxVccAddress.Text = address;
            lblResult.Visible = true;

        }






        }




    }

