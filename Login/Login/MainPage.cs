using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Login
{
    public partial class MainPage : Form
    {
        public MainPage(String username)
        {
            InitializeComponent();
            textBox1.Text = username;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void back_Click(object sender, EventArgs e)
        {
            Login loging = new Login();
            loging.Show();
            this.Hide();
        }

    }
}
