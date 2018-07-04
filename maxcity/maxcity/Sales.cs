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
    public partial class Sales : Form
    {
        SqlConnection con1 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\maxcity\data.mdf;Integrated Security=True;User Instance=True");
       
        public Sales()
        {
            InitializeComponent();
        }
        private void TextGotFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
           if(tb.Text == "M/DD/YY")
            {
            tb.Text = "";
                tb.ForeColor = Color.Black;
            }
        }
        private void TextLostFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "")
           {
                tb.Text = "M/DD/YY";
                tb.ForeColor = Color.LightGray;
            }
        }
         private void textBox1_Enter(object sender, EventArgs e)
        {
           /* if (textBox1.Text == "MM/DD/YY")
            {
                textBox1.Text = "";
            }*/
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            /* if (textBox1.Text == " ")
             {
                 textBox1.Text = "MM/DD/YY";
                 textBox1.ForeColor = Color.LightGray;

             }*/
        } 
        private void Sales_Load(object sender, EventArgs e)
        {
            this.ActiveControl = textBox1;
            textBox1.GotFocus += new EventHandler(this.TextGotFocus);
            textBox1.LostFocus += new EventHandler(this.TextLostFocus);
            //textBox1.Text = "M/DD/YYYY";
           // textBox1.Focus();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con1.Open();


                SqlCommand cmd = new SqlCommand("SELECT  InvoiceNo,CID,CName,Contact,ItemCode,ItemName,Qut as Qunatity,Price,Amount,Total,Paid,Balance as Loan_Balance,Discount,NetTotal,[User],Date FROM Invoice where Date1 Like '" + textBox1.Text + "%'", con1);
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con1.Open();


                SqlCommand cmd = new SqlCommand("SELECT  InvoiceNo,CID,CName,Contact,ItemCode,ItemName,Qut as Qunatity,Price,Amount,Total,Paid,Balance as Loan_Balance,Discount,NetTotal,[User],Date FROM Invoice where [User] Like '" + textBox2.Text + "%'", con1);
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con1.Open();


                SqlCommand cmd = new SqlCommand("SELECT  InvoiceNo,CID,CName,Contact,ItemCode,ItemName,Qut as Qunatity,Price,Amount,Total,Paid,Balance as Loan_Balance,Discount,NetTotal,[User],Date FROM Invoice where InvoiceNo Like '" + textBox3.Text + "%'", con1);
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

        private void textBox2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2.Focus();
            }

        }

        private void textBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.Focus();
            }
        }

        private void textBox3_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button3.Focus();
            }
        }

       
        }
    }

