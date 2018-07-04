using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pchjaffna
{
    public partial class Form6 : Form
    {
        decimal sum = 0;
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox2.Text);
            listBox2.Items.Add(textBox5.Text);
            decimal total = Convert.ToInt32(textBox5.Text) * Convert.ToInt32(textBox6.Text);
            sum = total + sum;
            listBox3.Items.Add(textBox6.Text);
            listBox4.Items.Add(total.ToString());
            textBox7.Text = sum.ToString();
            textBox2.Text = " ";
            textBox5.Text = " ";
            textBox6.Text = " ";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = listBox1.SelectedItems.Count - 1; i >= 0; i--)
            {
                listBox1.Items.Remove(listBox1.SelectedItems[i]);

            }
            for (int i = listBox2.SelectedItems.Count - 1; i >= 0; i--)
            {
                listBox2.Items.Remove(listBox2.SelectedItems[i]);

            }
            for (int i = listBox3.SelectedItems.Count - 1; i >= 0; i--)
            {
                listBox3.Items.Remove(listBox3.SelectedItems[i]);

            }
            for (int i = listBox4.SelectedItems.Count - 1; i >= 0; i--)
            {
                listBox4.Items.Remove(listBox4.SelectedItems[i]);

            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //e.Graphics.DrawString(listBox1.Items.new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 100));
            e.Graphics.DrawString("Cline Name : " +textBox1.Text ,new Font("Arial" ,12, FontStyle.Regular) ,Brushes.Black ,new Point (25 ,100));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            printDialog1.Document = printDocument1;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.Show();
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }
    }
}
