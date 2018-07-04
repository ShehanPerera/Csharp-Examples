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
    public partial class Daily_Sales : Form
        
        
    {
        SqlConnection con1 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\maxcity\data.mdf;Integrated Security=True;User Instance=True");
       
        public Daily_Sales()
        {
            InitializeComponent();
            dateTimePicker1.Enabled = false;
        }
        //int count = 0;
        private void Daily_Sales_Load(object sender, EventArgs e)
        {
            try
            {
                con1.Open();
                String d = Convert.ToString(dateTimePicker1.Value);
                d = d.Remove(9);


                SqlCommand cmd = new SqlCommand("SELECT  InvoiceNo,CID,CName,Contact,ItemCode,ItemName,Qut as Qunatity,Price,Amount,Total,Paid,Balance as Loan_Balance,Discount,NetTotal,[User],Date FROM Invoice where Date1 Like '" + d + "%'", con1);
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

        private void button1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("  Daily Sales Report", new Font("Arial", 14, FontStyle.Underline), Brushes.Black, new Point(35, 30));
           
            
            e.Graphics.DrawString("INo", new Font("Arial", 6, FontStyle.Bold), Brushes.Black, new Point(15, 100));
            e.Graphics.DrawString("CID", new Font("Arial", 6, FontStyle.Bold), Brushes.Black, new Point(40, 100));
            e.Graphics.DrawString("CName", new Font("Arial", 6, FontStyle.Bold), Brushes.Black, new Point(60, 100));
            e.Graphics.DrawString("ItemCode ", new Font("Arial", 6, FontStyle.Bold), Brushes.Black, new Point(120, 100));
            e.Graphics.DrawString("ItemName", new Font("Arial", 6, FontStyle.Bold), Brushes.Black, new Point(180, 100));
            e.Graphics.DrawString("Qunatity ", new Font("Arial", 6, FontStyle.Bold), Brushes.Black, new Point(325, 100));
            e.Graphics.DrawString("Price ", new Font("Arial", 6, FontStyle.Bold), Brushes.Black, new Point(375, 100));
            e.Graphics.DrawString("Amount", new Font("Arial", 6, FontStyle.Bold), Brushes.Black, new Point(415, 100));
            e.Graphics.DrawString("Total", new Font("Arial", 6, FontStyle.Bold), Brushes.Black, new Point(460, 100));
            e.Graphics.DrawString("Paid", new Font("Arial", 6, FontStyle.Bold), Brushes.Black, new Point(510, 100));
            e.Graphics.DrawString("Discount", new Font("Arial", 6, FontStyle.Bold), Brushes.Black, new Point(550, 100));
            e.Graphics.DrawString("NetTotal", new Font("Arial", 6, FontStyle.Bold), Brushes.Black, new Point(598, 100));
            e.Graphics.DrawString("Loan", new Font("Arial", 6, FontStyle.Bold), Brushes.Black, new Point(646, 100));
            e.Graphics.DrawString("User", new Font("Arial", 6, FontStyle.Bold), Brushes.Black, new Point(700, 100));
            e.Graphics.DrawString("Date", new Font("Arial", 6, FontStyle.Bold), Brushes.Black, new Point(760, 100));
            e.Graphics.DrawString("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 6, FontStyle.Bold), Brushes.Black, new Point(10, 120));
           
            int ypos = 150;
            int count = dataGridView1.RowCount;
            string c = Convert.ToString(count);
          
           
             for(int i=0;i<count;i++)
            {
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[0].Value.ToString(), new Font("Arial", 6, FontStyle.Regular), Brushes.Black, new Point(15, ypos));
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[1].Value.ToString(), new Font("Arial", 6, FontStyle.Regular), Brushes.Black, new Point(40, ypos));
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[2].Value.ToString(), new Font("Arial", 6, FontStyle.Regular), Brushes.Black, new Point(60, ypos));
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[4].Value.ToString(), new Font("Arial", 6, FontStyle.Regular), Brushes.Black, new Point(120, ypos));
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[5].Value.ToString(), new Font("Arial", 6, FontStyle.Regular), Brushes.Black, new Point(180, ypos));
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[6].Value.ToString(), new Font("Arial", 6, FontStyle.Regular), Brushes.Black, new Point(325, ypos));
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[7].Value.ToString(), new Font("Arial", 6, FontStyle.Regular), Brushes.Black, new Point(375, ypos));
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[8].Value.ToString(), new Font("Arial", 6, FontStyle.Regular), Brushes.Black, new Point(415, ypos));
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[9].Value.ToString(), new Font("Arial", 6, FontStyle.Regular), Brushes.Black, new Point(460, ypos));
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[10].Value.ToString(), new Font("Arial", 6, FontStyle.Regular), Brushes.Black, new Point(510, ypos));
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[12].Value.ToString(), new Font("Arial", 6, FontStyle.Regular), Brushes.Black, new Point(550, ypos));
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[13].Value.ToString(), new Font("Arial", 6, FontStyle.Regular), Brushes.Black, new Point(598, ypos));
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[11].Value.ToString(), new Font("Arial", 6, FontStyle.Regular), Brushes.Black, new Point(646, ypos));
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[14].Value.ToString(), new Font("Arial", 6, FontStyle.Regular), Brushes.Black, new Point(700, ypos));
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[15].Value.ToString(), new Font("Arial", 6, FontStyle.Regular), Brushes.Black, new Point(760, ypos));
                e.Graphics.DrawString("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 6, FontStyle.Bold), Brushes.Black, new Point(10, ypos+5));
          
                ypos = ypos + 30;

            }
            

        }
    }
}
