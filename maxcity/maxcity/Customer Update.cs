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

    public partial class Customer_Update : Form
    {

        SqlConnection con1 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\maxcity\data.mdf;Integrated Security=True;User Instance=True");
        public Customer_Update()
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
                SqlCommand cmd = new SqlCommand("SELECT CID,FristName as FirstName,LastName,Mobile,NIC,Balance FROM Customer", con1);
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
                MessageBox.Show("Customer Name requred", "Error");
                comboBox2.Focus();
                return false;
            }


            if (comboBox1.Text.Trim() == string.Empty)
            {
                MessageBox.Show("ID requred", "Error");
                comboBox1.Focus();
                return false;
            }
            if (textBox4.Text.Trim() == string.Empty)
            {
                MessageBox.Show("NIC requred", "Error");
                textBox4.Focus();
                return false;
            }
            else
            {
                int teq;
                bool isNumeric = int.TryParse(textBox7.Text.Trim(), out teq);
                if (!isNumeric  && textBox6.Text==string.Empty)
                {
                    MessageBox.Show("Mobile should be Number", "Error");
                    textBox7.Focus();
                    return false;
                }
                if (textBox6.Text.Trim() != String.Empty)
                {
                    int teq2;
                    bool isNumeric2 = int.TryParse(textBox6.Text.Trim(), out teq2);
                    if (!isNumeric2)
                    {
                        MessageBox.Show("Telephone should be Number", "Error");
                        textBox6.Focus();
                        return false;
                    }
                }

                return true;
            }
        }





        private void button1_Click(object sender, EventArgs e)
        {

        }



        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (isvalid())
            {
                con1.Open();
                SqlCommand com2 = new SqlCommand();
                com2.Connection = con1;
                com2.CommandText = "SELECT * FROM Customer WHERE CID='" + comboBox1.Text.Trim() + "'";
                SqlDataReader dr = com2.ExecuteReader();
                if (dr.Read())
                {
                    com2.CommandText = "UPDATE Customer SET FristName='" + comboBox2.Text.Trim() + "',LastName='" + textBox3.Text.Trim() + "',NIC='" + textBox4.Text.Trim() + "',Address='" + textBox5.Text.Trim() + "',Tel='" + textBox6.Text.Trim() + "',Mobile='" + textBox7.Text.Trim() + "',Mail='" + textBox8.Text.Trim() + "',Date='" + dateTimePicker1.Value + "',Type= '" + textBox9.Text.Trim() + "', balance='" + textBox1.Text.Trim() + "' WHERE CID='" + comboBox1.Text.Trim() + "' ";
                    dr.Close();
                    com2.ExecuteNonQuery();
                    MessageBox.Show("Updated");
                    con1.Close();

                }
                Customer_Update cu = new Customer_Update();
                this.Hide();
                cu.Show();

            }

        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            Customer_Update cu = new Customer_Update();
            cu.Show();
            this.Hide();

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            con1.Open();
            SqlCommand com1 = new SqlCommand();
            com1.Connection = con1;


            com1.CommandText = "Select * from Customer where [CID]='" + comboBox1.Text.Trim() + "' or FristName='" + comboBox2.Text + "'";


            SqlDataReader dr = com1.ExecuteReader();

            if (dr.Read())
            {
                int cons0 = dr.GetInt32(0);
                string cons1 = dr.GetString(1).Trim();
                string cons2 = dr.GetString(2).Trim();
                string cons3 = dr.GetString(3).Trim();
                string cons4 = dr.GetString(4).Trim();
                string cons5 = dr.GetString(5).Trim();
                string cons6 = dr.GetString(6).Trim();
                string cons7 = dr.GetString(7).Trim();
                string cons8 = dr.GetString(8).Trim();
                int cons9 = dr.GetInt32(10);

                comboBox1.Text = Convert.ToString(cons0);
                comboBox2.Text = cons1;
                textBox3.Text = cons2;
                textBox4.Text = cons3;
                textBox5.Text = cons4;
                textBox6.Text = cons5;
                textBox7.Text = cons6;
                textBox8.Text = cons7;
                textBox9.Text = cons8;
                textBox1.Text = cons9.ToString();

                dr.Close();



            }


            else
            {
                MessageBox.Show("Invalid Data", "Error");
            }


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

        private void Customer_Update_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            try
            {
                this.ActiveControl = comboBox1;
                con1.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Customer", con1);
                SqlDataReader dy;
                dy = cmd.ExecuteReader();
                while (dy.Read())
                {
                    comboBox1.Items.Add(dy["CID"].ToString().Trim());
                    comboBox2.Items.Add(dy["FristName"].ToString().Trim());
                }
                dy.Close();
                con1.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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
                textBox4.Focus();
            }
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {

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
                textBox8.Focus();
            }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
            {
                if (textBox1.Enabled == false)
                {
                    if (isvalid())
                    {
                        con1.Open();
                        SqlCommand com2 = new SqlCommand();
                        com2.Connection = con1;
                        com2.CommandText = "SELECT * FROM Customer WHERE CID='" + comboBox1.Text.Trim() + "'";
                        SqlDataReader dr = com2.ExecuteReader();
                        if (dr.Read())
                        {
                            com2.CommandText = "UPDATE Customer SET FristName='" + comboBox2.Text.Trim() + "',LastName='" + textBox3.Text.Trim() + "',NIC='" + textBox4.Text.Trim() + "',Address='" + textBox5.Text.Trim() + "',Tel='" + textBox6.Text.Trim() + "',Mobile='" + textBox7.Text.Trim() + "',Mail='" + textBox8.Text.Trim() + "',Date='" + dateTimePicker1.Value + "',Type= '" + textBox9.Text.Trim() + "', balance='" + textBox1.Text.Trim() + "' WHERE CID='" + comboBox1.Text.Trim() + "' ";
                            dr.Close();
                            com2.ExecuteNonQuery();
                            MessageBox.Show("Updated");

                        }
                        else { MessageBox.Show("Invaid CustomerID", "Error"); }
                        con1.Close();
                        Customer_Update cu = new Customer_Update();
                        this.Hide();
                        cu.Show();
                    }

                }
            }
            else
            {
                textBox1.Focus();
            }

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
            {


                if (isvalid())
                {
                    con1.Open();
                    SqlCommand com2 = new SqlCommand();
                    com2.Connection = con1;
                    com2.CommandText = "SELECT * FROM Customer WHERE CID='" + comboBox1.Text.Trim() + "'";
                    SqlDataReader dr = com2.ExecuteReader();
                    if (dr.Read())
                    {
                        com2.CommandText = "UPDATE Customer SET FristName='" + comboBox2.Text.Trim() + "',LastName='" + textBox3.Text.Trim() + "',NIC='" + textBox4.Text.Trim() + "',Address='" + textBox5.Text.Trim() + "',Tel='" + textBox6.Text.Trim() + "',Mobile='" + textBox7.Text.Trim() + "',Mail='" + textBox8.Text.Trim() + "',Date='" + dateTimePicker1.Value + "',Type= '" + textBox9.Text.Trim() + "', balance='" + textBox1.Text.Trim() + "' WHERE CID='" + comboBox1.Text.Trim() + "' ";
                        dr.Close();
                        com2.ExecuteNonQuery();
                        MessageBox.Show("Updated");

                    }
                    else { MessageBox.Show("Invaid CustomerID", "Error"); }
                    con1.Close();
                    Customer_Update cu = new Customer_Update();
                    this.Hide();
                    cu.Show();
                }

            }
        }

        private void comboBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                con1.Open();
                SqlCommand com1 = new SqlCommand();
                com1.Connection = con1;

                com1.CommandText = "Select * from Customer where [CID]='" + comboBox1.Text + "'";

                SqlDataReader dr = com1.ExecuteReader();
                if (dr.Read())
                {
                    int cons0 = dr.GetInt32(0);
                    string cons1 = dr.GetString(1).Trim();
                    string cons2 = dr.GetString(2).Trim();
                    string cons3 = dr.GetString(3).Trim();
                    string cons4 = dr.GetString(4).Trim();
                    string cons5 = dr.GetString(5).Trim();
                    string cons6 = dr.GetString(6).Trim();
                    string cons7 = dr.GetString(7).Trim();
                    string cons8 = dr.GetString(8).Trim();
                    int cons9 = dr.GetInt32(10);

                    comboBox1.Text = Convert.ToString(cons0);
                    comboBox2.Text = cons1;
                    textBox3.Text = cons2;
                    textBox4.Text = cons3;
                    textBox5.Text = cons4;
                    textBox6.Text = cons5;
                    textBox7.Text = cons6;
                    textBox8.Text = cons7;
                    textBox9.Text = cons8;
                    textBox1.Text = cons9.ToString();

                    if (textBox9.Text.Trim() == "Credit")
                    {
                        textBox1.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Data", "Error");
                }

                dr.Close();

                con1.Close();

                comboBox2.Focus();
            }
        }

        private void textBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                con1.Open();
                SqlCommand com2 = new SqlCommand();
                com2.Connection = con1;
                com2.CommandText = "SELECT * FROM Customer WHERE CID='" + comboBox1.Text + "'";
                SqlDataReader dr = com2.ExecuteReader();
                if (dr.Read())
                {
                    com2.CommandText = "UPDATE Customer SET FristName='" + comboBox2.Text + "',LastName='" + textBox3.Text + "',NIC='" + textBox4.Text + "',Address='" + textBox5.Text + "',Tel='" + textBox6.Text + "',Mobile='" + textBox7.Text + "',Mail='" + textBox8.Text + "',Type= '" + textBox9.Text + "', balance='" + textBox1.Text + "' WHERE CID='" + comboBox1.Text + "' ";
                    dr.Close();
                    com2.ExecuteNonQuery();
                    MessageBox.Show("Updated");

                }

                con1.Close();
                Customer_Update cu = new Customer_Update();
                this.Hide();
                cu.Show();

                comboBox1.Focus();
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBox9_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox4.Focus();
            }
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            Help h1 = new Help();
            h1.Show();
            h1.Hide();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                con1.Open();
                SqlCommand com1 = new SqlCommand();
                com1.Connection = con1;

                com1.CommandText = "Select * from Customer where FristName='" + comboBox2.Text + "'";

                SqlDataReader dr = com1.ExecuteReader();
                if (dr.Read())
                {
                    int cons0 = dr.GetInt32(0);
                    string cons1 = dr.GetString(1).Trim();
                    string cons2 = dr.GetString(2).Trim();
                    string cons3 = dr.GetString(3).Trim();
                    string cons4 = dr.GetString(4).Trim();
                    string cons5 = dr.GetString(5).Trim();
                    string cons6 = dr.GetString(6).Trim();
                    string cons7 = dr.GetString(7).Trim();
                    string cons8 = dr.GetString(8).Trim();
                    int cons9 = dr.GetInt32(10);

                    comboBox1.Text = Convert.ToString(cons0);
                    comboBox2.Text = cons1;
                    textBox3.Text = cons2;
                    textBox4.Text = cons3;
                    textBox5.Text = cons4;
                    textBox6.Text = cons5;
                    textBox7.Text = cons6;
                    textBox8.Text = cons7;
                    textBox9.Text = cons8;
                    textBox1.Text = cons9.ToString();
                    if (textBox9.Text.Trim() == "Credit")
                    {
                        textBox1.Enabled = true;
                    }


                }
                else
                {
                    MessageBox.Show("Invalid Data", "Error");
                }

                dr.Close();

                con1.Close();
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                comboBox1.Text = row.Cells["CID"].Value.ToString();
                comboBox2.Text = row.Cells["FirstName"].Value.ToString();
            }
        }
    }
}
