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
    public partial class test : Form

    {
        SqlConnection con1 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\maxcity\data.mdf;Integrated Security=True;User Instance=True");
       
        public  test(String code, int Qty,Boolean check)
        {
            InitializeComponent();
            textBox1.Text = code;
           
            textBox2.Text = Convert.ToString(Qty);
            int cons0 = 0;
            if (check)
            {
                con1.Open();

                SqlCommand com1 = new SqlCommand("SELECT * FROM Item where ItemCode = '" + textBox1.Text + "'", con1);
                SqlDataReader dr = com1.ExecuteReader();
                if (dr.Read())
                {
                    cons0 = dr.GetInt32(13);
                }

                dr.Close();
                con1.Close();
                int q1 = Convert.ToInt32(Qty);
                int nq = cons0 - q1;
                textBox2.Text = Convert.ToString(nq).Trim();

                con1.Open();

                SqlCommand com2 = new SqlCommand();
                com2.Connection = con1;
                com2.CommandText = "SELECT * FROM Item WHERE ItemCode='" + textBox1.Text + "'";
                SqlDataReader dr2 = com2.ExecuteReader();
                if (dr2.Read())
                {
                    com2.CommandText = "UPDATE Item SET Qnty = '" + textBox2.Text + "' WHERE ItemCode='" + textBox1.Text + "' ";
                    dr2.Close();
                    com2.ExecuteNonQuery();
                    
                    con1.Close();


                }
            }
            else
            {
                con1.Open();
                SqlCommand com1 = new SqlCommand();
                com1.Connection = con1;

                com1.CommandText = "Select * from Customer where [CID]='" + textBox1.Text + "'";

                SqlDataReader dr = com1.ExecuteReader();
                if (dr.Read())
                {
                    cons0 = dr.GetInt32(10);
                }
                dr.Close();
                con1.Close();
                int q1 = Convert.ToInt32(Qty);
                int nq = q1;
                textBox2.Text = Convert.ToString(nq).Trim();

                con1.Open();
                SqlCommand com2 = new SqlCommand();
                com2.Connection = con1;
                com2.CommandText = "SELECT * FROM Customer WHERE CID='" + textBox1.Text + "'";
                SqlDataReader dr2 = com2.ExecuteReader();
                if (dr2.Read())
                {
                    com2.CommandText = "UPDATE Customer SET  balance='" + textBox2.Text + "' WHERE CID='" + textBox1.Text + "' ";
                    dr2.Close();
                    com2.ExecuteNonQuery();
                   
                    con1.Close();
                   

                }
            }

        }
        public string TextBox1Value
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }
        public string TextBox2Value
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }
        public string TextBox1get
        {
            get { return textBox1.Text; }
        }
        

        private void test_Load(object sender, EventArgs e)
        {

        }
    }
}
