using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyWebBrowser
{
    public partial class Mywebbrowser : Form
    {
        public Mywebbrowser()
        {
            InitializeComponent();
        }

        private void prev_Click(object sender, EventArgs e)
        {
            webBrowser.GoBack();
        }

        private void next_Click(object sender, EventArgs e)
        {
            webBrowser.GoForward();
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            webBrowser.Refresh();
        }

        private void Go_Click(object sender, EventArgs e)
        {          
                webBrowser.Navigate(urlBox.Text);  
        }

        private void urlBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
               webBrowser.Navigate(urlBox.Text);
            }
        }   
              
    }
}
