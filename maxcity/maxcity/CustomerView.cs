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
    public partial class CustomerView : Form
    {
        SqlConnection con1 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\maxcity\data.mdf;Integrated Security=True;User Instance=True");
       
        public CustomerView()
        {
            InitializeComponent();
        }
        
        private void CustomerView_Load(object sender, EventArgs e)
        {
            try
            {
                con1.Open();
                

                SqlCommand cmd = new SqlCommand("SELECT CID,FristName as First_Name,LastName as Last_Name,NIC,Address,Tel,Mobile,Mail,Type,Date,Balance FROM Customer ", con1);
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
