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
    public partial class Loan_Customer_View : Form
    {
        SqlConnection con1 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\maxcity\data.mdf;Integrated Security=True;User Instance=True");
       
        public Loan_Customer_View()
        {
            InitializeComponent();
        }

        private void Loan_Customer_View_Load(object sender, EventArgs e)
        {
          
            try
            {
                con1.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Customer where Balance>0 ", con1);
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
            e.Graphics.DrawString("Loan Customers  ", new Font("Arial", 16, FontStyle.Bold), Brushes.Black, new Point(360, 30));
           
            e.Graphics.DrawString("CID", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(15, 100));
            e.Graphics.DrawString("FirstName", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(55, 100));
            e.Graphics.DrawString("LastName", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(115, 100));
            e.Graphics.DrawString("NIC", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(195, 100));
            e.Graphics.DrawString("Address", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(285, 100));
           // e.Graphics.DrawString("Tel", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(500, 100));
            e.Graphics.DrawString("Mobile", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(500, 100));
           // e.Graphics.DrawString("Type", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(700, 100));
            e.Graphics.DrawString("Balance", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(700, 100));
            e.Graphics.DrawString("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 6, FontStyle.Bold), Brushes.Black, new Point(10, 120));
           

            int ypos = 150;
            int count = dataGridView1.RowCount;
            for (int i = 0; i < count; i++)
            {
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[0].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(15, ypos));
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[1].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(55, ypos));
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[2].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(115, ypos));
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[3].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(195, ypos));
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[4].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(285, ypos));
                //e.Graphics.DrawString(dataGridView1.Rows[i].Cells[5].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(500, ypos));
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[6].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(500, ypos));
                 //e.Graphics.DrawString(dataGridView1.Rows[i].Cells[8].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(700, ypos));
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[10].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(700, ypos));
                e.Graphics.DrawString("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 6, FontStyle.Bold), Brushes.Black, new Point(10, ypos+40));
           
                ypos = ypos + 70;

            }

        }
    }
}
