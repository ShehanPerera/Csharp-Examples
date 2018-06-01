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
    public partial class Loging : Form
    {
        public Loging()
        {
            InitializeComponent();
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Log.Focus();
            }
        }

        private void Log_Click(object sender, EventArgs e)
        {
               String uname = usernameBox.Text;
               String password = passwordBox.Text;

            if(uname.Equals("admin")&& password.Equals("123"))
             {
                MainPage mainPage = new MainPage(uname);
                this.Hide();
                mainPage.Show();

            }                           
            else
            {
                MessageBox.Show("Invalid User Name or Password", "Error");
                usernameBox.Clear();
                passwordBox.Clear();
                usernameBox.Focus();
            }
           
        }

        private void Loging_Load(object sender, EventArgs e)
        {
            usernameBox.Focus();
        }
                     
    }
}
