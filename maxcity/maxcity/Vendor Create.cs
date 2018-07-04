using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace maxcity
{
    public partial class Vendor_Create : Form
    {
        SqlConnection con1 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\maxcity\data.mdf;Integrated Security=True;User Instance=True");
          
        public Vendor_Create()
        {
            InitializeComponent();
            fillList();
            textBox1.Enabled = false;
        }

        void fillList()
        {
            this.ActiveControl = textBox2;
            try
            {
                con1.Open();
                SqlCommand cmd = new SqlCommand("SELECT VID,CompanyName,Tel1 FROM Venodor", con1);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con1.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }
        private bool isvalid()
        {
             con1.Open();
            SqlCommand com1 = new SqlCommand();
            com1.Connection = con1;

            com1.CommandText = "Select * from Venodor where VID =' "+textBox1.Text.Trim()+"' " ;
           
            int ids = 0;
           
            SqlDataReader dr = com1.ExecuteReader();
           if (dr.Read())
            {
               
                ids = dr.GetInt32(0);

                dr.Close();
               
                if (Convert.ToInt32(textBox1.Text.Trim())==ids)
                {

                    MessageBox.Show("ID available", "Error");
                   

                    int id = 0;
                    try
                    {
                        SqlCommand cmd = new SqlCommand("SELECT TOP 1 VID FROM Venodor ORDER BY VID DESC  ", con1);
                        SqlDataReader dy;

                        dy = cmd.ExecuteReader();
                        while (dy.Read())
                        {
                            id = dy.GetInt32(0);
                        }
                        dy.Close();
                        con1.Close();
                        id++;
                        textBox1.Text = (id.ToString().Trim());
                        return false;
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
            
         else
            {
                con1.Close();
                textBox2.Focus();
            }
        
            if (textBox2.Text.Trim() == string.Empty)
            {
                con1.Close();
                MessageBox.Show("Company Name required", "Error");
                textBox2.Focus();
                return false;
            }
           
            if (textBox1.Text.Trim() == string.Empty)
            {
                con1.Close();
                MessageBox.Show("ID required", "Error");
                textBox1.Focus();
                return false;
            }
           
            if (textBox3.Text.Trim() == string.Empty)
            {
                con1.Close();
                MessageBox.Show("Address required", "Error");
                textBox3.Focus();
                return false;
            }
                
             else 
            {
                int teq1;
                
                bool isNumeric1 = int.TryParse(textBox4.Text.Trim(), out teq1);
               
               
                if (!isNumeric1)
                {
                    con1.Close();
                    MessageBox.Show("Telephone should be numbers", "Error");
                    textBox4.Focus();
                    return false;
                }
                if (textBox10.Text.Trim() != String.Empty)
                {
                    int teq2;
                    bool isNumeric2 = int.TryParse(textBox10.Text.Trim(), out teq2);
                    if (!isNumeric2)
                    {
                        con1.Close();
                        MessageBox.Show("Telephone should be numbers", "Error");
                        textBox10.Focus();
                        return false;
                    }
                }

                return true;
            }
          
           
        }
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
           

        }

       
           

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            Vendor_Create vc = new Vendor_Create();
            vc.Show();
            this.Hide();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (isvalid())
            {
                con1.Open();
                SqlCommand com1 = new SqlCommand();
                com1.Connection = con1;
                com1.CommandText = "Insert into Venodor values ('" + textBox1.Text.Trim() + "','" + textBox2.Text.Trim() + "','" + textBox3.Text.Trim() + "','" + textBox4.Text.Trim() + "','" + textBox10.Text.Trim() + "','" + textBox5.Text.Trim() + "','" + textBox7.Text.Trim() + "','" + textBox6.Text.Trim() + "','" + textBox8.Text.Trim() + "','" + textBox9.Text.Trim() + "','"+0+"')";
                SqlDataAdapter da = new SqlDataAdapter(com1.CommandText, con1.ConnectionString);
                DataTable dt = new DataTable();
                da.Fill(dt);
                MessageBox.Show("Successfully Saved");
                con1.Close();
                Vendor_Create vc = new Vendor_Create();
                this.Hide();
                vc.Show();
            }

          
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void Vendor_Create_Load(object sender, EventArgs e)
        {
            this.ActiveControl = textBox2;
            int id = 0;
            try
            {
                con1.Open();
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 VID FROM Venodor ORDER BY VID DESC", con1);
                SqlDataReader dy;
                dy = cmd.ExecuteReader();
                while (dy.Read())
                {
                    id = dy.GetInt32(0);
                }
                dy.Close();
                con1.Close();
                id++;
                textBox1.Text = Convert.ToString(id);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void comboBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
        }

        private void textBox9_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                textBox3.Focus();
            }
        }

        private void textBox2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (textBox2.Text.Trim() == string.Empty)
                {
                    
                    MessageBox.Show("Company Name required", "Error");
                    textBox2.Focus();
                    
                }
                else
                {
                    textBox9.Focus();
                }
            }
        }

        private void textBox3_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (textBox3.Text.Trim() == string.Empty)
                {
                   
                    MessageBox.Show("Address required", "Error");
                    textBox3.Focus();
                    
                }
                else
                {
                    textBox4.Focus();
                }
            }
        }

        private void textBox4_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                int teq1;

                bool isNumeric1 = int.TryParse(textBox4.Text.Trim(), out teq1);


                if (!isNumeric1)
                {
                   
                    MessageBox.Show("Telephone should be numbers", "Error");
                    textBox4.Focus();
                   
                }
                else
                {
                    textBox10.Focus();
                }
            }
        }

        private void textBox5_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                textBox7.Focus();
            }
        }

        private void textBox7_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                textBox6.Focus();
            }
        }

        private void textBox6_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                textBox8.Focus();
            }
        }

        private void textBox8_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if(isvalid())
                {
                con1.Open();
                SqlCommand com1 = new SqlCommand();
                com1.Connection = con1;
               com1.CommandText = "Insert into Venodor values ('" + textBox1.Text.Trim() + "','" + textBox2.Text.Trim() + "','" + textBox3.Text.Trim() + "','" + textBox4.Text.Trim() + "','"+textBox10.Text.Trim()+"','" + textBox5.Text.Trim() + "','" + textBox7.Text.Trim() + "','" + textBox6.Text.Trim() + "','" + textBox8.Text.Trim() + "','" + textBox9.Text.Trim() + "','"+0+"')";
                  SqlDataAdapter da = new SqlDataAdapter(com1.CommandText, con1.ConnectionString);
                DataTable dt = new DataTable();
                da.Fill(dt);
                MessageBox.Show("Successfully Saved");
                con1.Close();
                Vendor_Create vc = new Vendor_Create();
                this.Hide();
                vc.Show();
                }

            }
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            Help h1 = new Help();
            h1.Show();
            h1.Hide();
        }

        private void textBox10_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (textBox10.Text.Trim() != String.Empty)
                {
                    int teq2;
                    bool isNumeric2 = int.TryParse(textBox10.Text.Trim(), out teq2);
                    if (!isNumeric2)
                    {
                       
                        MessageBox.Show("Telephone should be numbers", "Error");
                        textBox10.Focus();
                        
                    }
                }
                else
                {
                    textBox5.Focus();
                }
            }
        }
    }
}
