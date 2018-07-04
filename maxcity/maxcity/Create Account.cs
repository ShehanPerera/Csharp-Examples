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
    public partial class Create_Account : Form
    {
        SqlConnection con1 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\maxcity\data.mdf;Integrated Security=True;User Instance=True");
        String hash = "S#e|-|@N";
        String pass = "";
        public Create_Account()
        {
            InitializeComponent();
        }

        private bool isvalid()

        {
           
            if (textBox1.Text.Trim() == string.Empty)
            {
                MessageBox.Show(" Name required", "Error");
                textBox1.Focus();
                return false;
            }
            if (textBox2.Text.Trim() == string.Empty)
            {
                MessageBox.Show(" ID required", "Error");
                textBox2.Focus();
                return false;
            }
            if (textBox3.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Mobile required", "Error");
                textBox3.Focus();
                return false;
            }
            if (textBox5.Text.Trim() == string.Empty)
            {
                MessageBox.Show(" UserName required", "Error");
                textBox5.Focus();
                return false;
            }
            if (textBox6.Text.Trim() == string.Empty)
            {
                MessageBox.Show(" Password required", "Error");
                textBox6.Focus();
                return false;
            }
            if (textBox3.Text.Trim() != String.Empty)
            {
                int teq2;
                bool isNumeric2 = int.TryParse(textBox3.Text.Trim(), out teq2);
                if (!isNumeric2)
                {
                    con1.Close();
                    MessageBox.Show("Mobile should be numbers", "Error");
                    textBox3.Focus();
                    return false;
                }
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           byte[] data = UTF8Encoding.UTF8.GetBytes(textBox6.Text);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys=md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tps = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform trans = tps.CreateEncryptor();
                    byte[] result = trans.TransformFinalBlock(data, 0, data.Length);
                    pass = Convert.ToBase64String(result, 0, result.Length);

                }
            }
            if (isvalid())
            {
                con1.Open();
                SqlCommand com2 = new SqlCommand();
                com2.Connection = con1;
                com2.CommandText = "SELECT * FROM Account WHERE ID='" + textBox2.Text.Trim() + "'";
                SqlDataReader dr = com2.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("ID available", "Error");
                    textBox2.Focus();
                    con1.Close();
                }
                else
                {
                    SqlCommand com1 = new SqlCommand();


                    com1.CommandText = "Insert into Account values ('" + textBox1.Text.Trim() + "','" + textBox2.Text.Trim() + "','" + textBox3.Text.Trim() + "','" + textBox4.Text.Trim() + "','" + textBox5.Text.Trim() + "','" + pass.Trim() + "','" + "A" + "')";
                    SqlDataAdapter da = new SqlDataAdapter(com1.CommandText, con1.ConnectionString);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    MessageBox.Show("Successfully Saved");
                    con1.Close();
                    Create_Account cv = new Create_Account();
                    cv.Show();
                    this.Hide();

                  
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Create_Account cv = new Create_Account();
            cv.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
             con1.Open();
            SqlCommand com1 = new SqlCommand();
            com1.Connection = con1;

            com1.CommandText = "Select * from Account where ID= '" + textBox2.Text.Trim() + "' ";
            
            SqlDataReader dr = com1.ExecuteReader();
            if (textBox2.Text.Trim() == "001")
            {
                MessageBox.Show("Admin cannot remove");
                textBox2.Focus();
            }
            else if (dr.Read())
            {
                com1.CommandText = "Delete from Account where ID='" + textBox2.Text.Trim() + "'";
                dr.Close();
                com1.ExecuteNonQuery();
                MessageBox.Show("Deleted");

                Create_Account ca = new Create_Account();
                ca.Show();
                this.Hide();
               


            }
            else
            {
                MessageBox.Show("Invaid ID ");
            }
          
            con1.Close();
          
    
        }

        private void SEARCH_Click(object sender, EventArgs e)
        {
            
          con1.Open();
            SqlCommand com1 = new SqlCommand();
            com1.Connection = con1;
           if (textBox2.Text.Trim() != string.Empty)
            {
                com1.CommandText = "Select * from Account where ID= '" + textBox2.Text.Trim() + "' ";

                SqlDataReader dr = com1.ExecuteReader();
                if (dr.Read())
                {
                    textBox1.Text = dr.GetString(0).Trim();
                    string cons2 = dr.GetString(2).Trim();
                    string cons3 = dr.GetString(3).Trim();
                    string cons4 = dr.GetString(4).Trim();
                    string cons5 = dr.GetString(5).Trim();
                    string cons6 = dr.GetString(6).Trim();


                    textBox3.Text = cons2;
                    textBox4.Text = cons3;
                    textBox5.Text = cons4;
                    textBox6.Text = cons5;
                  

                   
                    dr.Close();

                }
                else
                {
                    dr.Close();
                    MessageBox.Show("Invalid Data");
                    Create_Account ca = new Create_Account();
                    this.Hide();
                    ca.Show();


                    textBox1.Focus();
                }
            }


            else
            {
                MessageBox.Show("Invalid Data");
                Create_Account ca = new Create_Account();
                this.Hide();
                ca.Show();

                textBox1.Focus();
            }

            
           
            con1.Close();

        
        }

        private void button5_Click(object sender, EventArgs e)
        {
             byte[] data = UTF8Encoding.UTF8.GetBytes(textBox6.Text);
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
            if (isvalid())
            {
                con1.Open();
                SqlCommand com2 = new SqlCommand();
                com2.Connection = con1;
                com2.CommandText = "SELECT * FROM Account WHERE ID='" + textBox2.Text.Trim() + "'";
                SqlDataReader dr = com2.ExecuteReader();
                if (dr.Read())
                {
                    com2.CommandText = "UPDATE Account SET Name='" + textBox1.Text.Trim() + "',Mobile='" + textBox3.Text.Trim() + "',Post='" + textBox4.Text.Trim() + "',UserName='" + textBox5.Text.Trim() + "',Password='" + pass.Trim() + "',Type='" + "A" + "' WHERE ID='" + textBox2.Text.Trim() + "' ";
                    dr.Close();
                    com2.ExecuteNonQuery();
                    MessageBox.Show("Updated");
                   
                    this.Hide();
                    Create_Account cv = new Create_Account();
                    cv.Show();

                }
                else { MessageBox.Show("Invaid ID", "Error"); }
                con1.Close();
                

            }
 
        }

        private void Create_Account_Load(object sender, EventArgs e)
        {
            this.ActiveControl = textBox2;
        }

        private void textBox2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                 con1.Open();
            SqlCommand com1 = new SqlCommand();
            com1.Connection = con1;
           if (textBox2.Text.Trim() != string.Empty)
            {
                com1.CommandText = "Select * from Account where ID= '" + textBox2.Text.Trim() + "' ";

                SqlDataReader dr = com1.ExecuteReader();
                if (dr.Read())
                {
                    textBox1.Text = dr.GetString(0).Trim();
                    string cons2 = dr.GetString(2).Trim();
                    string cons3 = dr.GetString(3).Trim();
                    string cons4 = dr.GetString(4).Trim();
                    string cons5 = dr.GetString(5).Trim();
                    string cons6 = dr.GetString(6).Trim();


                    textBox3.Text = cons2;
                    textBox4.Text = cons3;
                    textBox5.Text = cons4;
                    textBox6.Text = cons5;
                  


                 
                    dr.Close();

                }
                else
                {
                    dr.Close();
                    MessageBox.Show("Invalid Data");
                    Create_Account ca = new Create_Account();
                    this.Hide();
                    ca.Show();


                    textBox1.Focus();
                }
            }


            else
            {
                MessageBox.Show("Invalid Data");
                Create_Account ca = new Create_Account();
                this.Hide();
                ca.Show();


                textBox1.Focus();
            }

            
           
            con1.Close();

        
        }
                textBox1.Focus();
            }

        private void textBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                textBox4.Focus();
            }
        }

        private void textBox4_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                textBox3.Focus();
            }
        }

        private void textBox3_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                textBox5.Focus();
            }
        }

        private void textBox5_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                textBox6.Focus();
            }
        }
        }
    }

