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
    public partial class Item_Create : Form
    {
        SqlConnection con1 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\maxcity\data.mdf;Integrated Security=True;User Instance=True");
       
        public Item_Create()
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
            if (textBox2.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Item Name required", "Error");
                textBox2.Focus();
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
                    MessageBox.Show("Qunatity should be nmbers", "Error");
                    textBox13.Focus();
                    return false;
                }
               



                return true;
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {

            Item_Create ic = new Item_Create();
            ic.Show();
            ic.Hide();
          
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (isvalid())
            {

                con1.Open();
                SqlCommand com1 = new SqlCommand();
                com1.Connection = con1;
                com1.CommandText = "Insert into Item values ('" + comboBox1.Text.Trim() + "','" + textBox2.Text.Trim() + "','" + textBox3.Text.Trim() + "','" + comboBox2.Text.Trim() + "','" + textBox5.Text.Trim() + "','" + textBox6.Text.Trim() + "','" + textBox7.Text.Trim() + "','" + textBox8.Text.Trim() + "','" + 0 + "','" + 0 + "','" + textBox11.Text.Trim() + "','" + textBox12.Text.Trim() + "','" + dateTimePicker1.Value + "','" + textBox13.Text.Trim() + "')";
                SqlDataAdapter da = new SqlDataAdapter(com1.CommandText, con1.ConnectionString);
                DataTable dt = new DataTable();
                da.Fill(dt);
                MessageBox.Show("Successfully Saved");
                con1.Close();
                Item_Create ic = new Item_Create();
                this.Hide();
                ic.Show();
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

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Item_Create_Load(object sender, EventArgs e)
        {
            this.ActiveControl = comboBox1;
            try
            {
                con1.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Item", con1);
                SqlDataReader dy;
                dy = cmd.ExecuteReader();
                while (dy.Read())
                {
                    comboBox1.Items.Add(dy["ItemCode"].ToString());
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

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void comboBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                con1.Open();
                SqlCommand com1 = new SqlCommand();
                com1.Connection = con1;

                com1.CommandText = "Select * from Item where ItemCode= '" + comboBox1.Text + "' ";

                SqlDataReader dr = com1.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("ID avilable", "Error");
                    comboBox1.Focus();

                }
                else
                {
                    textBox2.Focus();
                }
                con1.Close();


            }
        }

        private void textBox2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
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

        private void textBox8_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                textBox12.Focus();
            }
        }

        private void textBox9_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
        }

        private void textBox10_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
        }

        private void textBox11_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                textBox8.Focus();
            }
        }

        private void textBox12_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                textBox13.Focus();
            }
        }

        private void textBox13_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (isvalid())
                {
                    con1.Open();
                    SqlCommand com1 = new SqlCommand();
                    com1.Connection = con1;
                    com1.CommandText = "Insert into Item values ('" + comboBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox2.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + 0 + "','" + 0 + "','" + textBox11.Text + "','" + textBox12.Text + "','" + dateTimePicker1.Value + "','" + textBox13.Text + "')";
                    SqlDataAdapter da = new SqlDataAdapter(com1.CommandText, con1.ConnectionString);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    MessageBox.Show("Successfully Saved");
                    con1.Close();
                    Item_Create ic = new Item_Create();
                    this.Hide();
                    ic.Show();

                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            Help h1 = new Help();
            h1.Show();
            h1.Hide();
        }

        private void textBox5_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                textBox6.Focus();
            }
        }

      

       
    }
}
