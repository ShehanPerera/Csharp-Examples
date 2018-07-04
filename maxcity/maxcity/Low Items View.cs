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
    public partial class Low_Items_View : Form
    {
        SqlConnection con1 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\maxcity\data.mdf;Integrated Security=True;User Instance=True");
       
        public Low_Items_View()
        {
            InitializeComponent();
        }

        private void Low_Items_View_Load(object sender, EventArgs e)
        {
            try
            {
                con1.Open();
                SqlCommand cmd = new SqlCommand("SELECT ItemCode,ItemName,Type,VID,Catogary as [Category],UnitType,Extra,Cost,SalePrice,Warrenty,Date,Qnty as [Qunatity] FROM Item where Qnty<10 ", con1);
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
            e.Graphics.DrawString("Low Items  ", new Font("Arial", 16, FontStyle.Bold), Brushes.Black, new Point(350, 30));

            e.Graphics.DrawString("ItemCode", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(15, 100));
            e.Graphics.DrawString("ItemName", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(85, 100));
            e.Graphics.DrawString("Type", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(300, 100));
            e.Graphics.DrawString("VID", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(370, 100));
            e.Graphics.DrawString("Cost", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(440, 100));
            e.Graphics.DrawString("Saleprice", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(540, 100));
            e.Graphics.DrawString("Qunatity", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(650, 100));
            e.Graphics.DrawString("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 6, FontStyle.Bold), Brushes.Black, new Point(10, 120));
           

            int ypos = 150;
            int count = dataGridView1.RowCount;
            for (int i = 0; i < count; i++)
            {
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[0].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(15, ypos));
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[1].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(85, ypos));
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[2].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(300, ypos));
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[3].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(370, ypos));
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[7].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(440, ypos));
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[8].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(540, ypos));
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[11].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(650, ypos));
                e.Graphics.DrawString("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 6, FontStyle.Bold), Brushes.Black, new Point(10, ypos+5));
           
                ypos = ypos + 30;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
    }
}
