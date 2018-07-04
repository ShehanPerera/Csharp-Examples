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
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.Value = progressBar1.Value + 2;
            }
            else if (progressBar1.Value >= 100)
            {
                timer1.Enabled = false;
                MAX_CITY mdi = new MAX_CITY();
                mdi.Show();
                this.Hide();
            }
        }
    }
}
