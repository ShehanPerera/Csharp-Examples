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
    public partial class Customer_Create : Form
    {


        SqlConnection con1 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\maxcity\data.mdf;Integrated Security=True;User Instance=True");
        public Customer_Create()
        {
            InitializeComponent();
            fillList();
            textBox2.Focus();
            textBox10.Enabled = false;
            dateTimePicker1.Enabled = false;
           
        }
        void fillList()
        {
            
            try
            {
                this.ActiveControl = textBox2;
                con1.Open();
                SqlCommand cmd = new SqlCommand("SELECT CID,FristName as FirstName,LastName,Mobile,NIC FROM Customer", con1);
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

            com1.CommandText = "Select * from Customer where CID =' "+textBox10.Text.Trim()+"' " ;
           
            int ids = 0;
           
            SqlDataReader dr = com1.ExecuteReader();
           if (dr.Read())
            {
               
                ids = dr.GetInt32(0);

                dr.Close();
               
                if (Convert.ToInt32(textBox10.Text.Trim())==ids)
                {

                    MessageBox.Show("ID available", "Error");
                   

                    int id = 0;
                    try
                    {
                        SqlCommand cmd = new SqlCommand("SELECT TOP 1 CID FROM Customer ORDER BY CID DESC  ", con1);
                        SqlDataReader dy;

                        dy = cmd.ExecuteReader();
                        while (dy.Read())
                        {
                            id = dy.GetInt32(0);
                        }
                        dy.Close();
                        con1.Close();
                        id++;
                        textBox10.Text = (id.ToString().Trim());
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
                MessageBox.Show("Customer Name required", "Error");
                textBox2.Focus();
                return false;
            }
           
            if (textBox10.Text.Trim() == string.Empty)
            {
                con1.Close();
                MessageBox.Show("ID required", "Error");
                textBox10.Focus();
                return false;
            }
            if (textBox5.Text.Trim() != string.Empty)
            {
             
            con1.Open();
            SqlCommand com2 = new SqlCommand();
            com2.Connection = con1;

            com2.CommandText = "Select * from Customer where NIC =' " + textBox5.Text.Trim() + "' ";
            SqlDataReader dr2 = com2.ExecuteReader();
            if (dr2.Read())
            {
                con1.Close();
                MessageBox.Show("NIC available", "Error");
                textBox5.Clear();
                return false;
            }
            else
            {
                con1.Close();
            }
        }
            if (textBox5.Text.Trim() == string.Empty)
            {
                con1.Close();
                MessageBox.Show("NIC required", "Error");
                textBox5.Focus();
                return false;
            }
                
             else 
            {
                int teq1;
                
                bool isNumeric1 = int.TryParse(textBox8.Text.Trim(), out teq1);


                if (!isNumeric1 && textBox6.Text.Trim() == String.Empty)
                {
                    con1.Close();
                    MessageBox.Show("Mobile should be numbers", "Error");
                    textBox8.Focus();
                    return false;
                }
                if (textBox6.Text.Trim() != String.Empty)
                {
                    int teq2;
                    bool isNumeric2 = int.TryParse(textBox6.Text.Trim(), out teq2);
                    if (!isNumeric2)
                    {
                        con1.Close();
                        MessageBox.Show("Telephone should be numbers", "Error");
                        textBox6.Focus();
                        return false;
                    }
                }

                return true;
            }
          
           
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();

        }



        private void Customer_Create_Load(object sender, EventArgs e)
        {
           
           
            textBox2.Focus();
            int id = 0;
           
            try
            {
                con1.Open();
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 CID FROM Customer ORDER BY CID DESC  ", con1);
                SqlDataReader dy;

                dy = cmd.ExecuteReader();
                while (dy.Read())
                {
                    id = dy.GetInt32(0);
                }
                dy.Close();
                con1.Close();
                id++;
                textBox10.Text =  (id.ToString().Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
            textBox2.Focus();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
           

        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (isvalid())
            {

             con1.Open();
                SqlCommand com1 = new SqlCommand();
                com1.Connection = con1;
                com1.CommandText = "Insert into Customer values ('" + textBox10.Text.Trim() + "','" + textBox2.Text.Trim() + "','" + textBox3.Text.Trim() + "','" + textBox5.Text.Trim() + "','" + textBox4.Text.Trim() + "','" + textBox6.Text.Trim() + "','" + textBox8.Text.Trim() + "','" + textBox7.Text.Trim() + "','" + textBox9.Text.Trim() + "','" + dateTimePicker1.Value + "','"+ 0+"')";
                SqlDataAdapter da = new SqlDataAdapter(com1.CommandText.Trim(), con1.ConnectionString);
                DataTable dt = new DataTable();
                da.Fill(dt);
                MessageBox.Show("Successfully Saved");
                con1.Close();

               
                Customer_Create cc = new Customer_Create();
                this.Hide();
                cc.Show();
            }
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            Customer_Create cc = new Customer_Create();
            cc.Show();
            this.Hide();
        
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            this.Hide();

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

        private void comboBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
         
            
        }

        private void textBox2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (textBox2.Text.Trim() == string.Empty)
                {
                  
                    MessageBox.Show("Customer Name required", "Error");
                    textBox2.Focus();
                    
                }
                else
                {
                    textBox3.Focus();
                }
            }
        }

        private void textBox3_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                textBox9.Focus();
            }
        }

        private void textBox9_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
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
                if (textBox5.Text.Trim() == string.Empty)
                {
                  
                    MessageBox.Show("NIC required", "Error");
                    textBox5.Focus();
                   
                }
                else
                {
                    con1.Open();
                    SqlCommand com2 = new SqlCommand();
                    com2.Connection = con1;
                    com2.CommandText = "Select * from Customer where NIC =' " + textBox5.Text.Trim() + "' ";
                    SqlDataReader dr2 = com2.ExecuteReader();
                    if (dr2.Read())
                    {
                        con1.Close();
                        MessageBox.Show("NIC available", "Error");
                        textBox5.Clear();
                        textBox5.Focus();
                    }
                    else
                    {
                        con1.Close();
                        textBox4.Focus();
                    }
                }
               
            }
        }

        private void textBox4_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
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
                if (textBox6.Text.Trim() != String.Empty)
                {
                    int teq2;
                    bool isNumeric2 = int.TryParse(textBox6.Text.Trim(), out teq2);
                    if (!isNumeric2)
                    {

                        MessageBox.Show("Telephone should be numbers", "Error");
                        textBox6.Focus();

                    }
                    else
                    {
                        textBox8.Focus();
                    }
                }
                else
                {
                    textBox8.Focus();
                }
            }
        }

        private void textBox8_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                int teq1;

                bool isNumeric1 = int.TryParse(textBox8.Text.Trim(), out teq1);


                if (!isNumeric1 && textBox6.Text.Trim() == String.Empty)
                {

                    MessageBox.Show("Mobile should be numbers", "Error");
                    textBox8.Focus();

                }
                else
                {
                    textBox7.Focus();
                }
            }
        }

        private void textBox7_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {

                if (isvalid())
                {

                    con1.Open();
                    SqlCommand com1 = new SqlCommand();
                    com1.Connection = con1;
                    com1.CommandText = "Insert into Customer values ('" + textBox10.Text.Trim() + "','" + textBox2.Text.Trim() + "','" + textBox3.Text.Trim() + "','" + textBox5.Text.Trim() + "','" + textBox4.Text.Trim() + "','" + textBox6.Text.Trim() + "','" + textBox8.Text.Trim() + "','" + textBox7.Text.Trim() + "','" + textBox9.Text.Trim() + "','" + dateTimePicker1.Value + "','" + 0 + "')";
                    SqlDataAdapter da = new SqlDataAdapter(com1.CommandText.Trim(), con1.ConnectionString);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    MessageBox.Show("Successfully Saved");
                    con1.Close();


                    Customer_Create cc = new Customer_Create();
                    this.Hide();
                    cc.Show();
                }
                }
               
            
        }

        private void textBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (isvalid())
                {
                    con1.Open();
                    SqlCommand com1 = new SqlCommand();
                    com1.Connection = con1;
                    com1.CommandText = "Insert into Customer values ('" + textBox10.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox5.Text + "','" + textBox4.Text + "','" + textBox6.Text + "','" + textBox8.Text + "','" + textBox7.Text + "','" + textBox9.Text + "','" + dateTimePicker1.Value + "','" + 0 + "')";
                    SqlDataAdapter da = new SqlDataAdapter(com1.CommandText, con1.ConnectionString);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    MessageBox.Show("Successfully Saved");
                    con1.Close();

                    Customer_Create cc = new Customer_Create();
                    this.Hide();
                    cc.Show();
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
                textBox2.Focus();
            }


           

        }
       
    }
}
