using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace maxcity
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
            textBox1.Text = "Loaing";
            textBox1.Enabled = false;
        }

        private void Help_Load(object sender, EventArgs e)
        {

            System.Diagnostics.Process.Start(@"C:\maxcity\Help.pdf");
          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
