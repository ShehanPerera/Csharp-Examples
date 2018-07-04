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
    public partial class Creditor : Form

    {
        SqlConnection con1 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\maxcity\data.mdf;Integrated Security=True;User Instance=True");
       
        public Creditor()
        {
            InitializeComponent();
        }

        private void Creditor_Load(object sender, EventArgs e)
        {
            try
            {
                con1.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Venodor where Loan > 0 ", con1);
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

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Creditors  ", new Font("Arial", 16, FontStyle.Bold), Brushes.Black, new Point(360, 30));

            e.Graphics.DrawString("CID", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(15, 100));
            e.Graphics.DrawString("CompanyName", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(55, 100));
            e.Graphics.DrawString("Address", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(255, 100));
            e.Graphics.DrawString("Tel", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(500, 100));
            e.Graphics.DrawString("Account", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(620, 100));
            e.Graphics.DrawString("Laon", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(800, 100));
            e.Graphics.DrawString("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 6, FontStyle.Bold), Brushes.Black, new Point(10, 120));
           

            int ypos = 150;
            int count = dataGridView1.RowCount;
            for (int i = 0; i < count; i++)
            {
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[0].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(15, ypos));
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[1].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(55, ypos));
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[2].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(255, ypos));
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[3].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(500, ypos));
                 e.Graphics.DrawString(dataGridView1.Rows[i].Cells[6].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(620, ypos));
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[10].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(800, ypos));
                e.Graphics.DrawString("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 6, FontStyle.Bold), Brushes.Black, new Point(10, ypos+45));
           
                ypos = ypos + 70;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
    }
}
