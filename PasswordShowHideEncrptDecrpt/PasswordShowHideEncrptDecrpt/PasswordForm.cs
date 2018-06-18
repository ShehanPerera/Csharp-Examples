using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace PasswordShowHideEncrptDecrpt
{
    public partial class PasswordForm : Form
    {
        string hash = "Sh#H@n";
        public PasswordForm()
        {
            InitializeComponent();
        }

        private void Encrpt_Click(object sender, EventArgs e)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(passwordBox.Text);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] result = transform.TransformFinalBlock(data, 0, data.Length);
                    encryptBox.Text = Convert.ToBase64String(result, 0, result.Length);
                }
            }
        }

        private void Decrpt_Click(object sender, EventArgs e)
        {
            byte[] data = Convert.FromBase64String(encryptBox.Text);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateDecryptor();
                    byte[] result = transform.TransformFinalBlock(data, 0, data.Length);
                    decryptBox.Text = UTF8Encoding.UTF8.GetString(result); 
                }
            }
        }

        private void show_CheckedChanged(object sender, EventArgs e)
        {
            if (show.Checked)
            {
                passwordBox.UseSystemPasswordChar = false;
            }
            else
            {
                passwordBox.UseSystemPasswordChar = true;
            }

        }

        private void about_Click(object sender, EventArgs e)
        {
            About aboutForm = new About();
            aboutForm.Show();
        }
    }
}
