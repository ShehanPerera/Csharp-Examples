﻿using System;
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
    public partial class AccountView : Form
    {

        SqlConnection con1 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\maxcity\maxcity\data.mdf;Integrated Security=True;User Instance=True");
       
        public AccountView()
        {
            InitializeComponent();
            fillList();
        }

        void fillList()
        {
           
            try
            {
                con1.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Account", con1);
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
