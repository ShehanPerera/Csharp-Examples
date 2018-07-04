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
    public partial class ItemView : Form
    {

        SqlConnection con1 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\maxcity\data.mdf;Integrated Security=True;User Instance=True");
       
        public ItemView()
        {
            InitializeComponent();
        }
        //public void printDocument1_PrintPag
        public void item()
        {
           


           
        }

        private void ItemView_Load(object sender, EventArgs e)
        {
            try
            {
                con1.Open();
                SqlCommand cmd = new SqlCommand("SELECT ItemCode,ItemName,Type,VID,Catogary as [Category],UnitType,Extra,Cost,SalePrice,Warrenty,Date,Qnty as [Quantity] FROM Item ", con1);
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
        
    }
}
