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
    public partial class ItemUpdate : Form
    {
        SqlConnection con1 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\maxcity\data.mdf;Integrated Security=True;User Instance=True");
       
        public ItemUpdate()
        {
            InitializeComponent();
            fillList();
            dateTimePicker1.Enabled = false;
        }

        void fillList()
        {
            this.ActiveControl = comboBox1;
            try
            {
                con1.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Item", con1);
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
            if (comboBox3.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Item Name required", "Error");
                comboBox3.Focus();
                return false;
            }
            if (comboBox1.Text.Trim() == string.Empty)
            {
                MessageBox.Show("ID required", "Error");
                comboBox1.Focus();
                return false;
            }
            if (textBox13.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Quantity required", "Error");
                textBox13.Focus();
                return false;
            }
            else
            {
                int teq;
                bool isNumeric = int.TryParse(textBox11.Text.Trim(), out teq);
                if (!isNumeric)
                {
                    MessageBox.Show("Cost should be numbers", "Error");
                    textBox11.Focus();
                    return false;
                }
                isNumeric = int.TryParse(textBox8.Text.Trim(), out teq);
                if (!isNumeric)
                {
                    MessageBox.Show("SalePrice should be numbers", "Error");
                    textBox8.Focus();
                    return false;
                }
                isNumeric = int.TryParse(textBox13.Text.Trim(), out teq);
                if (!isNumeric)
                {
                    MessageBox.Show("Qunatity should be numbers", "Error");
                    textBox13.Focus();
                    return false;
                }




                return true;
            }
        }
        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            ItemUpdate it = new ItemUpdate();
            it.Show();
            this.Hide();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (isvalid())
            {
                con1.Open();
                SqlCommand com2 = new SqlCommand();
                com2.Connection = con1;
                com2.CommandText = "SELECT * FROM Item WHERE ItemCode='" + comboBox1.Text.Trim() + "'";
                SqlDataReader dr = com2.ExecuteReader();
                if (dr.Read())
                {
                    com2.CommandText = "UPDATE Item SET ItemName='" + comboBox3.Text.Trim() + "',Type='" + textBox3.Text.Trim() + "',VID='" + comboBox2.Text.Trim() + "',Catogary='" + textBox5.Text.Trim() + "',UnitType='" + textBox6.Text.Trim() + "',Extra='" + textBox7.Text.Trim() + "',Saleprice='" + textBox8.Text.Trim() + "',LastPrice= '" + 0 + "',Disc= '" + 0 + "',Cost= '" + textBox11.Text.Trim() + "',Warrenty = '" + textBox12.Text.Trim() + "',Qnty = '" + textBox13.Text.Trim() + "' WHERE ItemCode='" + comboBox1.Text.Trim() + "' ";
                    dr.Close();
                    com2.ExecuteNonQuery();
                    MessageBox.Show("Updated");

                }
                con1.Close();
                ItemUpdate iu = new ItemUpdate();
                this.Hide();
                iu.Show();
            }
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            con1.Open();
            SqlCommand com1 = new SqlCommand();
            com1.Connection = con1;

            com1.CommandText = "Select * from Item where ItemCode= '" + comboBox1.Text.Trim() + "'or ItemName='" + comboBox3.Text.Trim() + "' ";

            SqlDataReader dr = com1.ExecuteReader();
            if (dr.Read())
            {
                string cons0 = dr.GetString(0);
                string cons1 = dr.GetString(1);
                string cons2 = dr.GetString(2);
                string cons3 = dr.GetString(3);
                string cons4 = dr.GetString(4);
                string cons5 = dr.GetString(5);
                string cons6 = dr.GetString(6);
                string cons7 = dr.GetString(7);
                string cons10 = dr.GetString(10);
                string cons11 = dr.GetString(11);
                int cons12 = dr.GetInt32(13);


                comboBox1.Text = cons0;
                comboBox3.Text = cons1;
                textBox3.Text = cons2;
                comboBox2.Text = cons3;
                textBox5.Text = cons4;
                textBox7.Text = cons5;
                textBox6.Text = cons6;
                textBox8.Text = cons7;
                textBox11.Text = cons10;
                textBox12.Text = cons11;
                textBox13.Text = cons12.ToString();



            }
            else
            {
                MessageBox.Show("Invalid Data", "Error");
            }


            dr.Close();
            con1.Close();
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

        private void ItemUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                con1.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Item", con1);
                SqlDataReader dy;
                dy = cmd.ExecuteReader();
                while (dy.Read())
                {
                    comboBox1.Items.Add(dy["ItemCode"].ToString());
                    comboBox3.Items.Add(dy["ItemName"].ToString());
                }
                dy.Close();
                con1.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                con1.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Venodor", con1);
                SqlDataReader dy;
                dy = cmd.ExecuteReader();
                while (dy.Read())
                {
                    comboBox2.Items.Add(dy["VID"].ToString());
                }
                dy.Close();
                con1.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
            {
                textBox3.Focus();
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
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
                textBox6.Focus();
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
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
                textBox11.Focus();
            }
        }

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
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
                textBox12.Focus();
            }
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
            {
                textBox12.Focus();
            }
        }

        private void textBox12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
            {
                textBox13.Focus();
            }
        }

        private void textBox13_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
            {
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void comboBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                con1.Open();
                SqlCommand com1 = new SqlCommand();
                com1.Connection = con1;

                com1.CommandText = "Select * from Item where ItemCode= '" + comboBox1.Text.Trim() + "' ";

                SqlDataReader dr = com1.ExecuteReader();
                if (dr.Read())
                {
                    string cons0 = dr.GetString(0).Trim();
                    string cons1 = dr.GetString(1).Trim();
                    string cons2 = dr.GetString(2).Trim();
                    string cons3 = dr.GetString(3).Trim();
                    string cons4 = dr.GetString(4).Trim();
                    string cons5 = dr.GetString(5).Trim();
                    string cons6 = dr.GetString(6).Trim();
                    string cons7 = dr.GetString(7).Trim();
                    string cons10 = dr.GetString(10).Trim();
                    string cons11 = dr.GetString(11).Trim();
                    int cons12 = dr.GetInt32(13);


                    comboBox1.Text = cons0;
                    comboBox3.Text = cons1;
                    textBox3.Text = cons2;
                    comboBox2.Text = cons3;
                    textBox5.Text = cons4;
                    textBox7.Text = cons5;
                    textBox6.Text = cons6;
                    textBox8.Text = cons7;
                    textBox11.Text = cons10;
                    textBox12.Text = cons11;
                    textBox13.Text = cons12.ToString();



                }
                else
                {
                    MessageBox.Show("Invalid Data", "Error");
                }


                dr.Close();
                con1.Close();
                comboBox3.Focus();
            }
        }

        private void textBox13_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (isvalid())
                {
                    con1.Open();
                    SqlCommand com2 = new SqlCommand();
                    com2.Connection = con1;
                    com2.CommandText = "SELECT * FROM Item WHERE ItemCode='" + comboBox1.Text.Trim() + "'";
                    SqlDataReader dr = com2.ExecuteReader();
                    if (dr.Read())
                    {
                        com2.CommandText = "UPDATE Item SET ItemName='" + comboBox3.Text.Trim() + "',Type='" + textBox3.Text.Trim() + "',VID='" + comboBox2.Text.Trim() + "',Catogary='" + textBox5.Text.Trim() + "',UnitType='" + textBox6.Text.Trim() + "',Extra='" + textBox7.Text.Trim() + "',Saleprice='" + textBox8.Text.Trim() + "',LastPrice= '" + 0 + "',Disc= '" + 0 + "',Cost= '" + textBox11.Text.Trim() + "',Warrenty = '" + textBox12.Text.Trim() + "',Qnty = '" + textBox13.Text.Trim() + "' WHERE ItemCode='" + comboBox1.Text.Trim() + "' ";
                        dr.Close();
                        com2.ExecuteNonQuery();
                        MessageBox.Show("Updated");

                    }

                    con1.Close();
                    ItemUpdate iu = new ItemUpdate();
                    this.Hide();
                    iu.Show();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                comboBox1.Text = row.Cells["ItemCode"].Value.ToString();
                comboBox3.Text = row.Cells["ItemName"].Value.ToString();
            }
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            Help h1 = new Help();
            h1.Show();
            h1.Hide();
        }

        private void comboBox3_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                con1.Open();
                SqlCommand com1 = new SqlCommand();
                com1.Connection = con1;

                com1.CommandText = "Select * from Item where ItemName= '" + comboBox3.Text.Trim() + "' ";

                SqlDataReader dr = com1.ExecuteReader();
                if (dr.Read())
                {
                    string cons0 = dr.GetString(0).Trim();
                    string cons1 = dr.GetString(1).Trim();
                    string cons2 = dr.GetString(2).Trim();
                    string cons3 = dr.GetString(3).Trim();
                    string cons4 = dr.GetString(4).Trim();
                    string cons5 = dr.GetString(5).Trim();
                    string cons6 = dr.GetString(6).Trim();
                    string cons7 = dr.GetString(7).Trim();
                    string cons10 = dr.GetString(10).Trim();
                    string cons11 = dr.GetString(11).Trim();
                    int cons12 = dr.GetInt32(13);


                    comboBox1.Text = cons0;
                    comboBox3.Text = cons1;
                    textBox3.Text = cons2;
                    comboBox2.Text = cons3;
                    textBox5.Text = cons4;
                    textBox7.Text = cons5;
                    textBox6.Text = cons6;
                    textBox8.Text = cons7;
                    textBox11.Text = cons10;
                    textBox12.Text = cons11;
                    textBox13.Text = cons12.ToString();



                }
                else
                {
                    MessageBox.Show("Invalid Data", "Error");
                }


                dr.Close();
                con1.Close();
                textBox3.Focus();
            }
        }

        private void textBox3_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                comboBox2.Focus();
            }
        }

        private void comboBox2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
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

        private void textBox6_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
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
               textBox11.Focus();
            }
        }

        private void textBox11_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
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
                textBox12.Focus();
            }
        }

        private void textBox12_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                textBox13.Focus();
            }
        }
    }
}
