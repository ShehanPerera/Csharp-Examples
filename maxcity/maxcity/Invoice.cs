using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using maxcity.Properties;

namespace maxcity
{
    public partial class Invoice : Form
    {
        decimal sum = 0;
        decimal total = 0;
        int qty = 0;
        int balance1 = 0;

        SqlConnection con1 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\maxcity\data.mdf;Integrated Security=True;User Instance=True");


        public Invoice(string uname)
        {
            InitializeComponent();
            textBox2.Text = uname;
            textBox2.Enabled = false;
            textBox11.Text = "0";
            textBox7.Text = "0";
            textBox16.Enabled = false;
            textBox17.Text = "0";
            textBox18.Text = "0";
            textBox13.Enabled = false;
            textBox18.Enabled = false;
            textBox11.Enabled = false;
            textBox15.Enabled = false;
            textBox14.Enabled = false;
            textBox5.Enabled = false;
            textBox1.Enabled = false;
            dateTimePicker1.Enabled = false;
            if (textBox2.Text == "Admin")
            {
                toolStripButton3.Enabled = false;
            }


        }




        public void sugest(TextBox textbox8)
        {
            try
            {
                con1.Open();
                SqlCommand cmd = new SqlCommand("SELECT ItemName FROM Item", con1);
                SqlDataReader dy;
                dy = cmd.ExecuteReader();
                while (dy.Read())
                {
                    textbox8.AutoCompleteCustomSource.Add(dy["ItemName"].ToString());
                }
                dy.Close();
                con1.Close();

            }
            catch
            {

                con1.Close();
            }
        }

        public void sugeste(TextBox textbox3)
        {
            try
            {
                con1.Open();
                SqlCommand cmd = new SqlCommand("SELECT FristName FROM Customer", con1);
                SqlDataReader dy;
                dy = cmd.ExecuteReader();
                while (dy.Read())
                {
                    textbox3.AutoCompleteCustomSource.Add(dy["FristName"].ToString());
                }
                dy.Close();
                con1.Close();

            }
            catch
            {

                con1.Close();
            }
        }





        public Invoice()
        {
            // TODO: Complete member initialization
        }





        private void button1_Click(object sender, EventArgs e)
        {
            if (isvalid())
            {
                total = Convert.ToDecimal(textBox9.Text) * Convert.ToInt32(textBox10.Text);
                sum = total + sum;
                textBox12.Text = total.ToString();
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }


        private void Invoice_Load(object sender, EventArgs e)
        {

            textBox3.Focus();
            comboBox3.Enabled = false;
            textBox8.Enabled = false;
            textBox9.Enabled = false;
            textBox9.Enabled = false;
            textBox12.Enabled = false;
            button1.Enabled = false;
            textBox10.Enabled = false;
            this.ActiveControl = comboBox2;
            try
            {
                con1.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Item", con1);
                SqlDataReader dy;
                dy = cmd.ExecuteReader();
                while (dy.Read())
                {
                    comboBox3.Items.Add(dy["ItemCode"].ToString());
                }
                dy.Close();
                con1.Close();
                sugest(textBox8);
                sugeste(textBox3);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            int id = 0;
            try
            {
                con1.Open();
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 InvoiceNo FROM Invoice ORDER BY InvoiceNo DESC  ", con1);
                SqlDataReader dy;

                dy = cmd.ExecuteReader();
                while (dy.Read())
                {
                    id = dy.GetInt32(0);
                }
                dy.Close();
                con1.Close();
                id++;
                textBox16.Text = (id.ToString().Trim());


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                con1.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Customer", con1);
                SqlDataReader dy;
                dy = cmd.ExecuteReader();
                while (dy.Read())
                {
                    comboBox2.Items.Add(dy["CID"].ToString());
                }
                dy.Close();
                con1.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void textBox10_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (isvalid())
                {
                    if (qty < Convert.ToInt32(textBox10.Text.Trim()))
                    {
                        MessageBox.Show("Request is high", "Error");
                        textBox10.Focus();
                    }
                    else
                    {

                        total = Convert.ToDecimal(textBox9.Text) * Convert.ToDecimal(textBox10.Text);

                        textBox12.Text = total.ToString();

                        textBox12.Focus();

                    }
                }
            }

        }

        private void comboBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void comboBox2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {


                con1.Open();
                SqlCommand com1 = new SqlCommand();
                com1.Connection = con1;

                com1.CommandText = "Select * from Customer where [CID]='" + comboBox2.Text.Trim() + "'";

                SqlDataReader dr = com1.ExecuteReader();
                if (dr.Read())
                {
                    // string cons0 = dr.GetString(0);
                    int cons0 = dr.GetInt32(0);
                    string cons1 = dr.GetString(1).Trim();

                    string cons4 = dr.GetString(4).Trim();

                    string cons6 = dr.GetString(6).Trim();

                    string cons8 = dr.GetString(8).Trim();
                    balance1 = dr.GetInt32(10);


                    comboBox2.Text = Convert.ToString(cons0);
                    //comboBox2.Text = cons0;
                    textBox3.Text = cons1;
                    textBox4.Text = cons4;
                    textBox5.Text = cons8;
                    textBox6.Text = cons6;
                    textBox1.Text = balance1.ToString();

                    textBox3.Focus();

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

        private void textBox3_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                con1.Open();
                SqlCommand com1 = new SqlCommand();
                com1.Connection = con1;

                com1.CommandText = "Select * from Customer where FristName='" + textBox3.Text.Trim() + "'";

                SqlDataReader dr = com1.ExecuteReader();
                if (dr.Read())
                {
                    // string cons0 = dr.GetString(0);
                    int cons0 = dr.GetInt32(0);
                    string cons1 = dr.GetString(1).Trim();

                    string cons4 = dr.GetString(4).Trim();

                    string cons6 = dr.GetString(6).Trim();

                    string cons8 = dr.GetString(8).Trim();
                    balance1 = dr.GetInt32(10);


                    comboBox2.Text = Convert.ToString(cons0);
                    //comboBox2.Text = cons0;
                    textBox3.Text = cons1;
                    textBox4.Text = cons4;
                    textBox5.Text = cons8;
                    textBox6.Text = cons6;
                    textBox1.Text = balance1.ToString();

                    textBox3.Focus();

                }
                else
                {
                    MessageBox.Show("Invalid Data", "Error");
                    comboBox2.Focus();
                }

                dr.Close();

                con1.Close();




                if (textBox3.Text.Trim() == string.Empty)
                {
                    comboBox3.Enabled = false;
                    textBox8.Enabled = false;
                    textBox9.Enabled = false;
                    textBox9.Enabled = false;
                    textBox12.Enabled = false;
                    button1.Enabled = false;
                    textBox10.Enabled = false;
                    //button3.Enabled = false;
                    textBox3.Focus();
                }
                else
                {
                    comboBox3.Enabled = true;
                    textBox8.Enabled = true;
                    textBox12.Enabled = true;
                    textBox10.Enabled = true;
                    button1.Enabled = true;
                    if (textBox5.Text.Trim() != "Credit")
                    {
                        textBox7.Enabled = false;
                        textBox11.Enabled = false;

                    }
                    else
                    {
                        textBox7.Enabled = true;


                    }
                    comboBox3.Focus();
                }

            }
        }

        private void textBox4_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox5.Focus();
            }
        }

        private void textBox5_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                textBox6.Focus();
            }
        }

        private void textBox6_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                comboBox3.Focus();
            }
        }



        private void comboBox3_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                con1.Open();
                SqlCommand com1 = new SqlCommand();
                com1.Connection = con1;

                com1.CommandText = "Select * from Item where ItemCode= '" + comboBox3.Text + "' ";

                SqlDataReader dr = com1.ExecuteReader();
                if (dr.Read())
                {
                    string cons0 = dr.GetString(0).Trim();
                    string cons1 = dr.GetString(1).Trim();


                    string cons7 = dr.GetString(7).Trim();


                    qty = dr.GetInt32(13);

                    comboBox3.Text = cons0;
                    textBox8.Text = cons1;
                    textBox9.Text = cons7;
                    textBox10.Focus();
                    dr.Close();
                    con1.Close();



                }
                else
                {
                    MessageBox.Show("Invalid Data", "Error");
                    comboBox3.Focus();
                    dr.Close();
                    con1.Close();
                }



            }

        }

        private void textBox8_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                con1.Open();
                SqlCommand com1 = new SqlCommand();
                com1.Connection = con1;

                com1.CommandText = "Select * from Item where ItemName= '" + textBox8.Text.Trim() + "' ";

                SqlDataReader dr = com1.ExecuteReader();
                if (dr.Read())
                {
                    string cons0 = dr.GetString(0).Trim();
                    string cons1 = dr.GetString(1).Trim();


                    string cons7 = dr.GetString(7).Trim();


                    qty = dr.GetInt32(13);

                    comboBox3.Text = cons0;
                    // textBox8.Text = cons1;
                    textBox9.Text = cons7;
                    textBox10.Focus();




                }
                else
                {
                    MessageBox.Show("Invalid Data", "Error");
                    comboBox3.Focus();
                }


                dr.Close();
                con1.Close();



                textBox10.Focus();
            }



        }

        private void textBox9_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox10.Focus();
            }
        }





        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            Help h1 = new Help();
            h1.Show();
            h1.Hide();
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {

            printDocument1.Print();
        }

        private bool Cu()
        {
            if (textBox3.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Customer Name required", "Error");
                textBox3.Focus();
                return false;
            }
            return true;
        }

        private bool isvalid()
        {
            if (textBox3.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Customer Name required", "Error");
                textBox3.Focus();
                return false;
            }
            if (comboBox3.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Item ID required", "Error");
                comboBox3.Focus();
                return false;
            }
            if (textBox8.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Item required", "Error");
                textBox8.Focus();
                return false;
            }
            if (textBox10.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Quantity required", "Error");
                textBox10.Focus();
                return false;
            }
            else
            {
                int teq;
                bool isNumeric = int.TryParse(textBox9.Text.Trim(), out teq);
                if (!isNumeric)
                {
                    MessageBox.Show("Price should be numbers", "Error");
                    textBox9.Focus();
                    return false;
                }
                isNumeric = int.TryParse(textBox10.Text.Trim(), out teq);
                if (!isNumeric)
                {
                    MessageBox.Show("Quantity should be numbers", "Error");
                    textBox10.Focus();
                    return false;
                }

                return true;
            }
        }


        private List<invo> invop = new List<invo>();
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (isvalid())
            {

                sum = total + sum;
                bool hassameItem = false;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (Convert.ToInt32(row.Cells["ItemCode"].Value) == Convert.ToInt32(comboBox3.Text))
                    {
                        row.Cells["Quantity"].Value = Convert.ToDecimal(row.Cells["Quantity"].Value) + Convert.ToDecimal(textBox10.Text);
                        row.Cells["Total"].Value = Convert.ToDecimal(row.Cells["Quantity"].Value) * Convert.ToDecimal(textBox9.Text);

                        hassameItem = true;
                    }

                }
                if (hassameItem == false)
                {
                    invo inv = new invo()
                    {
                        ItemCode = Convert.ToInt32(comboBox3.Text),
                        ItemName = textBox8.Text,
                        Quantity = Convert.ToDecimal(textBox10.Text),
                        UnitPrice = Convert.ToDecimal(textBox9.Text),
                        Total = Convert.ToDecimal(textBox12.Text),
                    };

                    invop.Add(inv);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = invop;


                }
                decimal totalA = invop.Sum(x => x.Total);
                textBox13.Text = totalA.ToString();

                comboBox3.Text = null;
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();
                textBox12.Clear();
                comboBox3.Focus();
            }
        }

        private void textBox12_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.Focus();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Invoice mc = new Invoice(textBox2.Text.Trim());
            mc.Show();
            this.Hide();
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            Invoice ic = new Invoice(textBox2.Text);
            this.Hide();
            ic.Show();
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hari = dataGridView1.HitTest(e.X, e.Y);
                dataGridView1.Rows[hari.RowIndex].Selected = true;

                contextMenuStrip1.Show(dataGridView1, e.X, e.Y);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            invop.RemoveAt(index);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = invop;

            decimal totalA = invop.Sum(x => x.Total);
            textBox13.Text = totalA.ToString();



        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("MAX CITY", new Font("Snap ITC", 60, FontStyle.Underline), Brushes.Black, new Point(140, 30));
            e.Graphics.DrawString("204,Kandy Road ,Chavakachcheri", new Font("Snap ITC", 12, FontStyle.Regular), Brushes.Black, new Point(250, 150));
            e.Graphics.DrawString("Telephone:077-3038601 ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(250, 170));

            e.Graphics.DrawString("Date: " + DateTime.Now.ToShortDateString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 190));
            e.Graphics.DrawString("Address : " + textBox4.Text.Trim(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 240));
            e.Graphics.DrawString("Contact No : " + textBox6.Text.Trim(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 310));
            e.Graphics.DrawString("Customer Name: " + textBox3.Text.Trim(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 210));
            e.Graphics.DrawString("Invoice No : " + textBox16.Text.Trim(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, 190));
            e.Graphics.DrawString("User Name: " + textBox2.Text.Trim(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, 210));
            e.Graphics.DrawString("----------------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 330));
            e.Graphics.DrawString("Item Name ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 340));
            e.Graphics.DrawString("Price  ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(375, 340));
            e.Graphics.DrawString("Quantity", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(525, 340));
            e.Graphics.DrawString("Amount ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(675, 340));
            e.Graphics.DrawString("----------------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 360));

            int ypos = 390;
            foreach (var i in invop)
            {
                e.Graphics.DrawString(i.ItemName, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, ypos));
                e.Graphics.DrawString(i.UnitPrice.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(375, ypos));
                e.Graphics.DrawString(i.Quantity.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(525, ypos));
                e.Graphics.DrawString(i.Total.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(675, ypos));

                ypos = ypos + 30;

            }

            e.Graphics.DrawString("----------------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, ypos));
            e.Graphics.DrawString("--Credit Customer-------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(350, ypos + 30));
            e.Graphics.DrawString("Paid                 : " + textBox7.Text.Trim(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(350, ypos + 60));
            e.Graphics.DrawString("Credit Balance : " + textBox11.Text.Trim(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(350, ypos + 90));
            e.Graphics.DrawString("-----------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(350, ypos + 110));

            e.Graphics.DrawString("Total       : " + textBox13.Text.Trim(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(600, ypos + 30));
            e.Graphics.DrawString("Discount : " + textBox17.Text.Trim(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(600, ypos + 60));
            e.Graphics.DrawString("NetTotal : " + textBox18.Text.Trim(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(600, ypos + 90));
            e.Graphics.DrawString("Payment  : " + textBox14.Text.Trim(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(600, ypos + 120));
            e.Graphics.DrawString("Balance  : " + textBox15.Text.Trim(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(600, ypos + 150));

            /* e.Graphics.DrawString("---------------------------" , new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(600, ypos + 560));
             e.Graphics.DrawString("Manager Signature " , new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(600, ypos + 590));

             e.Graphics.DrawString("---------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, ypos + 560));
             e.Graphics.DrawString("Customer Signature ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, ypos + 590));*/
        }


        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
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

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (Cu())
            {

                String code = "O";
                int Qty = 0;
                con1.Open();

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    SqlCommand com1 = new SqlCommand();
                    com1.Connection = con1;
                    com1.CommandText = "Insert into Invoice  values ('" + textBox16.Text.Trim() + "','" + textBox2.Text.Trim() + "','" + comboBox2.Text.Trim() + "','" + textBox3.Text.Trim() + "','" + textBox6.Text.Trim() + "',@IN6,@IN7,@IN8,@IN9,@IN10,@IN11,@IN12,@IN13,'" + dateTimePicker1.Value + "','" + dateTimePicker1.Value + "','" + textBox17.Text.Trim() + "','" + textBox18.Text.Trim() + "')";



                    com1.Parameters.AddWithValue("@IN6", dataGridView1.Rows[i].Cells[0].Value);
                    com1.Parameters.AddWithValue("@IN7", dataGridView1.Rows[i].Cells[1].Value);
                    com1.Parameters.AddWithValue("@IN8", dataGridView1.Rows[i].Cells[2].Value);
                    com1.Parameters.AddWithValue("@IN9", dataGridView1.Rows[i].Cells[3].Value);
                    com1.Parameters.AddWithValue("@IN10", dataGridView1.Rows[i].Cells[4].Value);
                    com1.Parameters.AddWithValue("@IN11", textBox13.Text);
                    com1.Parameters.AddWithValue("@IN12", textBox7.Text);
                    com1.Parameters.AddWithValue("@IN13", textBox11.Text);
                    code = Convert.ToString(dataGridView1.Rows[i].Cells[0].Value);
                    Qty = Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);

                    test t1 = new test(code, Qty, true);

                    com1.ExecuteNonQuery();

                }
                code = comboBox2.Text.Trim();
                Qty = balance1 + Convert.ToInt32(textBox11.Text.Trim());

                test t2 = new test(code, Qty, false);
                MessageBox.Show("Successfully Saved");


                con1.Close();

                Invoice ic = new Invoice(textBox2.Text);
                this.Hide();
                ic.Show();
            }

        }

        private void textBox7_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                decimal total = Convert.ToDecimal(textBox18.Text);
                decimal paid = Convert.ToDecimal(textBox7.Text);
                decimal balance = total - paid;
                textBox11.Text = Convert.ToString(balance);
                textBox14.Enabled = true;
                textBox14.Focus();
            }
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void textBox14_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBox14_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            decimal total = 0;
            if (e.KeyCode == Keys.Enter)
            {

                if (textBox14.Text != String.Empty)
                {
                    decimal paid = Convert.ToDecimal(textBox14.Text);
                    if (textBox7.Enabled == true || textBox7.Text != "0")
                    {
                        total = Convert.ToDecimal(textBox7.Text);
                    }
                    else
                    {
                        total = Convert.ToDecimal(textBox18.Text);
                    }
                    decimal balance = paid - total;
                    if (balance < 0)
                    {
                        MessageBox.Show("Money is not enough");
                    }
                    else
                    {
                        textBox15.Text = Convert.ToString(balance);
                        textBox15.Focus();

                        if (e.KeyData == Keys.Enter)
                        {
                            if (Cu())
                            {

                                String code = "O";
                                int Qty = 0;
                                con1.Open();

                                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                                {
                                    SqlCommand com1 = new SqlCommand();
                                    com1.Connection = con1;
                                    com1.CommandText = "Insert into Invoice  values ('" + textBox16.Text.Trim() + "','" + textBox2.Text.Trim() + "','" + comboBox2.Text.Trim() + "','" + textBox3.Text.Trim() + "','" + textBox6.Text.Trim() + "',@IN6,@IN7,@IN8,@IN9,@IN10,@IN11,@IN12,@IN13,'" + dateTimePicker1.Value + "','" + dateTimePicker1.Value + "','" + textBox17.Text.Trim() + "','" + textBox18.Text.Trim() + "')";



                                    com1.Parameters.AddWithValue("@IN6", dataGridView1.Rows[i].Cells[0].Value);
                                    com1.Parameters.AddWithValue("@IN7", dataGridView1.Rows[i].Cells[1].Value);
                                    com1.Parameters.AddWithValue("@IN8", dataGridView1.Rows[i].Cells[2].Value);
                                    com1.Parameters.AddWithValue("@IN9", dataGridView1.Rows[i].Cells[3].Value);
                                    com1.Parameters.AddWithValue("@IN10", dataGridView1.Rows[i].Cells[4].Value);
                                    com1.Parameters.AddWithValue("@IN11", textBox13.Text);
                                    com1.Parameters.AddWithValue("@IN12", textBox7.Text);
                                    com1.Parameters.AddWithValue("@IN13", textBox11.Text);
                                    code = Convert.ToString(dataGridView1.Rows[i].Cells[0].Value);
                                    Qty = Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);

                                    test t1 = new test(code, Qty, true);

                                    com1.ExecuteNonQuery();

                                }
                                code = comboBox2.Text.Trim();
                                Qty = balance1 + Convert.ToInt32(textBox11.Text.Trim());

                                test t2 = new test(code, Qty, false);
                                MessageBox.Show("Successfully Saved");


                                con1.Close();

                                printPreviewDialog1.Document = printDocument1;
                                printPreviewDialog1.ShowDialog();

                                Invoice ic = new Invoice(textBox2.Text);
                                this.Hide();
                                ic.Show();
                            }

                        }
                    }
                }
                else
                {
                    MessageBox.Show("Money is not enough");
                }
            }

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void textBox16_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox2.Focus();
            }
        }

        private void textBox11_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (Cu())
                {

                    String code = "O";
                    int Qty = 0;
                    con1.Open();

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        SqlCommand com1 = new SqlCommand();
                        com1.Connection = con1;
                        com1.CommandText = "Insert into Invoice  values ('" + textBox16.Text.Trim() + "','" + textBox2.Text.Trim() + "','" + comboBox2.Text.Trim() + "','" + textBox3.Text.Trim() + "','" + textBox6.Text.Trim() + "',@IN6,@IN7,@IN8,@IN9,@IN10,@IN11,@IN12,@IN13,'" + dateTimePicker1.Value + "','" + dateTimePicker1.Value + "','" + textBox17.Text.Trim() + "','" + textBox18.Text.Trim() + "')";



                        com1.Parameters.AddWithValue("@IN6", dataGridView1.Rows[i].Cells[0].Value);
                        com1.Parameters.AddWithValue("@IN7", dataGridView1.Rows[i].Cells[1].Value);
                        com1.Parameters.AddWithValue("@IN8", dataGridView1.Rows[i].Cells[2].Value);
                        com1.Parameters.AddWithValue("@IN9", dataGridView1.Rows[i].Cells[3].Value);
                        com1.Parameters.AddWithValue("@IN10", dataGridView1.Rows[i].Cells[4].Value);
                        com1.Parameters.AddWithValue("@IN11", textBox13.Text);
                        com1.Parameters.AddWithValue("@IN12", textBox7.Text);
                        com1.Parameters.AddWithValue("@IN13", textBox11.Text);
                        code = Convert.ToString(dataGridView1.Rows[i].Cells[0].Value);
                        Qty = Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);

                        test t1 = new test(code, Qty, true);

                        com1.ExecuteNonQuery();

                    }
                    code = comboBox2.Text.Trim();
                    Qty = balance1 + Convert.ToInt32(textBox11.Text.Trim());

                    test t2 = new test(code, Qty, false);
                    MessageBox.Show("Successfully Saved");


                    con1.Close();

                    Invoice ic = new Invoice(textBox2.Text);
                    this.Hide();
                    ic.Show();
                }
            }

        }

        private void textBox15_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {


        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                textBox17.Focus();
            }
        }

        private void textBox17_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                decimal total = Convert.ToDecimal(textBox13.Text.Trim());
                decimal disc = Convert.ToDecimal(textBox17.Text.Trim());
                decimal nettotal = Math.Round(total * ((100 - disc) / 100));
                textBox18.Text = Convert.ToString(nettotal).Trim();
                if (textBox7.Enabled == true)
                {
                    textBox7.Focus();
                }
                else
                {
                    textBox14.Enabled = true;
                    textBox14.Focus();
                }

            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void toolStripSeparator_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {   

        }










    }
}
