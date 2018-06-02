using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Datagridview;

namespace maxcity
{
    public partial class Invoice : Form
    {
        decimal sum = 0;
        decimal total = 0;
       
        public Invoice()
        {
            InitializeComponent();
            textBox17.Text = "0";
            textBox18.Text = "0";
            comboBox3.Text = "100";
            comboBox3.Focus();
         }
              
        private bool isvalid()
        {
           
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
      
      private void button1_Click(object sender, EventArgs e)
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

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void textBox10_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                total = Convert.ToDecimal(textBox9.Text) * Convert.ToDecimal(textBox10.Text);
                textBox12.Text = total.ToString();
                textBox12.Focus();
             }
        }

        private void textBox8_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox9.Focus();
            }
        }

        private void textBox9_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox10.Focus();
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
                textBox14.Focus();
            }
            
        }

        private void textBox14_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            decimal total = 0;
            if (e.KeyCode == Keys.Enter)
            {

                if (textBox14.Text != String.Empty)
                {
                    decimal paid = Convert.ToDecimal(textBox14.Text);

                    total = Convert.ToDecimal(textBox18.Text);

                    decimal balance = paid - total;
                    if (balance < 0)
                    {
                        MessageBox.Show("Money is not enough");
                    }
                    else
                    {
                        textBox15.Text = Convert.ToString(balance);
                        textBox15.Focus();

                    }
                }
            }

        }

        private void textBox13_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                textBox17.Focus();
            }
        }

        private void comboBox3_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                textBox8.Text = "Item" + comboBox3.Text;
                textBox8.Focus();
            }
        }

        private void textBox12_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.Focus();
            }
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            Invoice invoice = new Invoice();
            invoice.Show();
            this.Hide();
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Datagridview Printer Example", new Font("Snap ITC", 30, FontStyle.Underline), Brushes.Black, new Point(90, 30));
            e.Graphics.DrawString("Date: " + DateTime.Now.ToShortDateString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 190));
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


            e.Graphics.DrawString("Total       : " + textBox13.Text.Trim(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(600, ypos + 30));
            e.Graphics.DrawString("Discount : " + textBox17.Text.Trim(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(600, ypos + 60));
            e.Graphics.DrawString("NetTotal : " + textBox18.Text.Trim(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(600, ypos + 90));
            e.Graphics.DrawString("Payment  : " + textBox14.Text.Trim(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(600, ypos + 120));
            e.Graphics.DrawString("Balance  : " + textBox15.Text.Trim(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(600, ypos + 150));

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

       
     }
}
