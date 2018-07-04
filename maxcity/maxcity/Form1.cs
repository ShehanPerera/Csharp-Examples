using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace maxcity
{
    public partial class Form1 : Form
    {
        SqlConnection con1 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\maxcity\data.mdf;Integrated Security=True;User Instance=True;");
       
        string uname;
        string hash = "S#e|-|@N";
        string pass = "";

        public Form1()
        {
            InitializeComponent();
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(textBox2.Text);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tps = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform trans = tps.CreateEncryptor();
                    byte[] result = trans.TransformFinalBlock(data, 0, data.Length);
                    pass = Convert.ToBase64String(result, 0, result.Length);

                }
            }
            con1.Open();
            SqlCommand com1 = new SqlCommand();
            com1.Connection = con1;
            string cons0 = "";
            com1.CommandText = "select ID from Account where UserName='" + textBox1.Text.Trim() + "'and Password='" + pass.Trim() + "'";
            SqlDataReader dr = com1.ExecuteReader();

            if (dr.Read())
            {
                cons0 = dr.GetString(0).Trim();
            }

            if (cons0 == "001")
            {

                uname = textBox1.Text;
                MAX_CITY ss = new MAX_CITY(uname);
                this.Hide();
                ss.Show();

            }

            else if (cons0 == "002" || cons0 == "003")
            {
                uname = textBox1.Text;
                Invoice ic = new Invoice(uname);
                ic.Show();
                this.Hide();
            }



            else
            {
                MessageBox.Show("Invalid User Name or Password", "Error");
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Focus();
            }
            dr.Close();
            con1.Close();









        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.Focus();

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

      

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
            
        }

        public string getuname()
        {
            return uname;
        }

      
       

    }
}
