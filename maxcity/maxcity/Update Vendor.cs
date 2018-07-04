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
    public partial class Update_Vendor : Form
    {
        SqlConnection con1 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\maxcity\data.mdf;Integrated Security=True;User Instance=True");
        public Update_Vendor()
        {
            InitializeComponent();
            fillList();
            textBox2.Text = "0";
            textBox2.Enabled = false;
        }

        void fillList()
        {
            this.ActiveControl = comboBox1;
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
             if (comboBox2.Text.Trim() == string.Empty)
             {
                 MessageBox.Show("Company Name requred", "Error");
                 comboBox2.Focus();
                 return false;
             }
             
              if (comboBox1.Text.Trim() == string.Empty)
             {
                 MessageBox.Show("ID required", "Error");
                 comboBox1.Focus();
                 return false;
             }
             if (textBox3.Text.Trim() == string.Empty)
             {
                 MessageBox.Show("Address required", "Error");
                 textBox3.Focus();
                 return false;
             }
             else
             {
                 int teq;
                 bool isNumeric = int.TryParse(textBox4.Text.Trim(), out teq);
                 if (!isNumeric)
                 {
                     MessageBox.Show("Telephone should be Number", "Error");
                     textBox4.Focus();
                     return false;
                 }
                 if (textBox1.Text.Trim() != String.Empty)
                 {
                     int teq2;
                     bool isNumeric2 = int.TryParse(textBox1.Text.Trim(), out teq2);
                     if (!isNumeric2)
                     {
                         MessageBox.Show("Telephone should be Number", "Error");
                         textBox1.Focus();
                         return false;
                     }
                 }

                 return true;
             }
         }

      
        private void newToolStripButton_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {

            this.Hide();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

           

        }

        private void Update_Vendor_Load(object sender, EventArgs e)
        {
            try
            {
                con1.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Venodor", con1);
                SqlDataReader dy;
                dy = cmd.ExecuteReader();
                while (dy.Read())
                {
                    comboBox1.Items.Add(dy["VID"].ToString());
                    comboBox2.Items.Add(dy["CompanyName"].ToString());


                }
                dy.Close();
                con1.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
            {
                textBox4.Focus();
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
            {
                textBox5.Focus();
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
            {
                textBox7.Focus();
            }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
            {
                textBox6.Focus();
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
            {
                textBox8.Focus();
            }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
            {
                comboBox1.Focus();
            }
        }

        private void comboBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
           
        }

        private void textBox8_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (isvalid())
                {
                    con1.Open();
                    SqlCommand com2 = new SqlCommand();
                    com2.Connection = con1;
                    com2.CommandText = "SELECT * FROM Venodor WHERE VID='" + comboBox1.Text.Trim() + "'";
                    SqlDataReader dr = com2.ExecuteReader();
                    if (dr.Read())
                    {
                        com2.CommandText = "UPDATE Venodor SET CompanyName='" + comboBox2.Text.Trim() + "',Address='" + textBox3.Text.Trim() + "',Tel1='" + textBox4.Text.Trim() + "',Tel2='" + textBox1.Text.Trim() + "',Fax='" + textBox5.Text.Trim() + "',Mail='" + textBox6.Text.Trim() + "',Acc='" + textBox7.Text.Trim() + "',Extra='" + textBox8.Text.Trim() + "',Type= '" + textBox9.Text.Trim() + "' WHERE VID='" + comboBox1.Text.Trim() + "' ";
                        dr.Close();
                        com2.ExecuteNonQuery();
                        MessageBox.Show("Updated");

                    }
                    else { MessageBox.Show("Invalid Vendor", "Error"); }
                    con1.Close();

                    Update_Vendor uv = new Update_Vendor();
                    this.Hide();
                    uv.Show();
                }
            }
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            Help h1 = new Help();
            h1.Show();
            h1.Hide();
        }

        private void comboBox2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                con1.Open();
                SqlCommand com1 = new SqlCommand();
                com1.Connection = con1;

                com1.CommandText = "Select * from Venodor where CompanyName = '" + comboBox2.Text.Trim() + "' ";

                SqlDataReader dr = com1.ExecuteReader();
                if (dr.Read())
                {
                    string cons0 = Convert.ToString(dr.GetInt32(0)).Trim();
                    string cons1 = dr.GetString(1).Trim();
                    string cons2 = dr.GetString(2).Trim();
                    string cons3 = dr.GetString(3).Trim();
                    string cons4 = dr.GetString(4).Trim();
                    string cons5 = dr.GetString(5).Trim();
                    string cons6 = dr.GetString(6).Trim();
                    string cons7 = dr.GetString(7).Trim();
                    string cons8 = dr.GetString(8).Trim();
                    string cons9 = dr.GetString(9).Trim();

                    comboBox1.Text = cons0;
                    comboBox2.Text = cons1;
                    textBox3.Text = cons2;
                    textBox4.Text = cons3;
                    textBox1.Text = cons4;
                    textBox5.Text = cons5;
                    textBox7.Text = cons6;
                    textBox6.Text = cons7;
                    textBox8.Text = cons8;
                    textBox9.Text = cons9;

                    textBox9.Focus();

                }
                else
                {
                    MessageBox.Show("Invalid Data", "Error");
                    comboBox2.Focus();
                }


                dr.Close();

                con1.Close();

              
            }
        }

        private void toolStripLabel1_Click_1(object sender, EventArgs e)
        {
            
            {
                con1.Open();
                SqlCommand com1 = new SqlCommand();
                com1.Connection = con1;

                com1.CommandText = "Select * from Venodor where VID= '" + comboBox1.Text + "' or CompanyName='"+comboBox2.Text.Trim()+"' ";

                SqlDataReader dr = com1.ExecuteReader();
                if (dr.Read())
                {
                    string cons0 = Convert.ToString(dr.GetInt32(0)).Trim();
                    string cons1 = dr.GetString(1).Trim();
                    string cons2 = dr.GetString(2).Trim();
                    string cons3 = dr.GetString(3).Trim();
                    string cons4 = dr.GetString(4).Trim();
                    string cons5 = dr.GetString(5).Trim();
                    string cons6 = dr.GetString(6).Trim();
                    string cons7 = dr.GetString(7).Trim();
                    string cons8 = dr.GetString(8).Trim();
                    string cons9 = dr.GetString(9).Trim();


                    comboBox1.Text = cons0;
                    comboBox2.Text = cons1;
                    textBox3.Text = cons2;
                    textBox4.Text = cons3;
                    textBox1.Text = cons4;
                    textBox5.Text = cons5;
                    textBox7.Text = cons6;
                    textBox6.Text = cons7;
                    textBox8.Text = cons8;
                    textBox9.Text = cons9;


                }
                else
                {
                    MessageBox.Show("Invalid Data", "Error");
                }


                dr.Close();

                con1.Close();

                comboBox1.Focus();
            }
        }

        private void newToolStripButton_Click_1(object sender, EventArgs e)
        {
            Update_Vendor v = new Update_Vendor();
            v.Show();
            this.Hide();
        }

        private void toolStripLabel1_Click_2(object sender, EventArgs e)
        {
            {
                 con1.Open();
                SqlCommand com1 = new SqlCommand();
                com1.Connection = con1;

                com1.CommandText = "Select * from Venodor where VID= '" + comboBox1.Text + "' or CompanyName='"+comboBox2.Text.Trim()+"' ";

                SqlDataReader dr = com1.ExecuteReader();
                if (dr.Read())
                {
                    string cons0 = Convert.ToString(dr.GetInt32(0)).Trim();
                    string cons1 = dr.GetString(1).Trim();
                    string cons2 = dr.GetString(2).Trim();
                    string cons3 = dr.GetString(3).Trim();
                    string cons4 = dr.GetString(4).Trim();
                    string cons5 = dr.GetString(5).Trim();
                    string cons6 = dr.GetString(6).Trim();
                    string cons7 = dr.GetString(7).Trim();
                    string cons8 = dr.GetString(8).Trim();
                    string cons9 = dr.GetString(9).Trim();
                    int cons10 = dr.GetInt32(10);


                    comboBox1.Text = cons0;
                    comboBox2.Text = cons1;
                    textBox3.Text = cons2;
                    textBox4.Text = cons3;
                    textBox1.Text = cons4;
                    textBox5.Text = cons5;
                    textBox7.Text = cons6;
                    textBox6.Text = cons7;
                    textBox8.Text = cons8;
                    textBox9.Text = cons9;
                    textBox2.Text = Convert.ToString(cons10);
                    comboBox2.Focus();
                    if (textBox9.Text.Trim() == "Loan")
                    {
                        textBox2.Enabled = true;
                    }

                }
                else
                {
                    MessageBox.Show("Invalid Data", "Error");
                    comboBox1.Focus();
                }


                dr.Close();

                con1.Close();

                comboBox1.Focus();
            }
        }

        private void comboBox1_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                con1.Open();
                SqlCommand com1 = new SqlCommand();
                com1.Connection = con1;

                com1.CommandText = "Select * from Venodor where VID= '" + comboBox1.Text + "' ";

                SqlDataReader dr = com1.ExecuteReader();
                if (dr.Read())
                {
                    string cons0 = Convert.ToString(dr.GetInt32(0)).Trim();
                    string cons1 = dr.GetString(1).Trim();
                    string cons2 = dr.GetString(2).Trim();
                    string cons3 = dr.GetString(3).Trim();
                    string cons4 = dr.GetString(4).Trim();
                    string cons5 = dr.GetString(5).Trim();
                    string cons6 = dr.GetString(6).Trim();
                    string cons7 = dr.GetString(7).Trim();
                    string cons8 = dr.GetString(8).Trim();
                    string cons9 = dr.GetString(9).Trim();
                    int cons10 = dr.GetInt32(10);



                    comboBox1.Text = cons0;
                    comboBox2.Text = cons1;
                    textBox3.Text = cons2;
                    textBox4.Text = cons3;
                    textBox1.Text = cons4;
                    textBox5.Text = cons5;
                    textBox7.Text = cons6;
                    textBox6.Text = cons7;
                    textBox8.Text = cons8;
                    textBox9.Text = cons9;
                    textBox2.Text=Convert.ToString(cons10);
                    comboBox2.Focus();
                    if (textBox9.Text.Trim() == "Loan")
                    {
                        textBox2.Enabled = true;
                    }



                }
                else
                {
                    MessageBox.Show("Invalid Data", "Error");
                    comboBox1.Focus();
                }


                dr.Close();

                con1.Close();

                comboBox2.Focus();
            }

        }

        private void saveToolStripButton_Click_1(object sender, EventArgs e)
        {
            if (isvalid())
            {
                con1.Open();
                SqlCommand com2 = new SqlCommand();
                com2.Connection = con1;
                com2.CommandText = "SELECT * FROM Venodor WHERE VID='" + comboBox1.Text.Trim() + "'";
                SqlDataReader dr = com2.ExecuteReader();
                if (dr.Read())
                {
                    com2.CommandText = "UPDATE Venodor SET CompanyName='" + comboBox2.Text.Trim() + "',Address='" + textBox3.Text.Trim() + "',Tel1='" + textBox4.Text.Trim() + "',Tel2='" + textBox1.Text.Trim() + "',Fax='" + textBox5.Text.Trim() + "',Mail='" + textBox6.Text.Trim() + "',Acc='" + textBox7.Text.Trim() + "',Extra='" + textBox8.Text.Trim() + "',Type= '" + textBox9.Text.Trim() + "',Loan='"+textBox2.Text.Trim()+"' WHERE VID='" + comboBox1.Text.Trim() + "' ";
                    dr.Close();
                    com2.ExecuteNonQuery();
                    MessageBox.Show("Updated");

                }
                else { MessageBox.Show("Invalid Vendor", "Error"); }
                con1.Close();

                Update_Vendor uv = new Update_Vendor();
                this.Hide();
                uv.Show();
            }
        
        }

        private void openToolStripButton_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void toolStripLabel2_Click_1(object sender, EventArgs e)
        {
            Update_Vendor uv = new Update_Vendor();
            uv.Show();
            this.Hide();

        }

        private void textBox9_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
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
                textBox4.Focus();
            }
        }

        private void textBox4_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                textBox1.Focus();
            }
        }

        private void textBox5_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                textBox7.Focus();
            }
        }

        private void textBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                textBox5.Focus();
            }
        }

        private void textBox7_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                textBox8.Focus();
            }
        }

        private void textBox8_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                textBox2.Focus();
            }
        

        }

        private void textBox2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (isvalid())
                {
                    con1.Open();
                    SqlCommand com2 = new SqlCommand();
                    com2.Connection = con1;
                    com2.CommandText = "SELECT * FROM Venodor WHERE VID='" + comboBox1.Text.Trim() + "'";
                    SqlDataReader dr = com2.ExecuteReader();
                    if (dr.Read())
                    {
                        com2.CommandText = "UPDATE Venodor SET CompanyName='" + comboBox2.Text.Trim() + "',Address='" + textBox3.Text.Trim() + "',Tel1='" + textBox4.Text.Trim() + "',Tel2='" + textBox1.Text.Trim() + "',Fax='" + textBox5.Text.Trim() + "',Mail='" + textBox6.Text.Trim() + "',Acc='" + textBox7.Text.Trim() + "',Extra='" + textBox8.Text.Trim() + "',Type= '" + textBox9.Text.Trim() + "' ,Loan='" + textBox2.Text.Trim() + "' WHERE VID='" + comboBox1.Text.Trim() + "' ";
                        dr.Close();
                        com2.ExecuteNonQuery();
                        MessageBox.Show("Updated");

                    }
                    else { MessageBox.Show("Invalid Vendor", "Error"); }
                    con1.Close();

                    Update_Vendor uv = new Update_Vendor();
                    this.Hide();
                    uv.Show();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                comboBox1.Text = row.Cells["VID"].Value.ToString();
                comboBox2.Text = row.Cells["CompanyName"].Value.ToString();
            }
        }

         

       
    }
}
