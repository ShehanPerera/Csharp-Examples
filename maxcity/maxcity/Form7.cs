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
    public partial class Form7 : Form
    {
        Timer t = new Timer();

        double pbUnit;
        int pbWIDTH, pbHEIGHT, pbComplete;

        Bitmap bmp;
        Graphics g;

        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

            pbWIDTH = picboxPB.Width;
            pbHEIGHT = picboxPB.Height;

            pbUnit = pbWIDTH / 92.0;

            pbComplete = 0;

            bmp = new Bitmap(pbWIDTH, pbHEIGHT);

            t.Interval = 15;
            t.Tick += new EventHandler(this.t_Tick);
            t.Start();

        }

        private void t_Tick(object sender, EventArgs e)
        {
            g = Graphics.FromImage(bmp);

            g.Clear(Color.Black);

            g.FillRectangle(Brushes.LimeGreen, new RectangleF(0, 0, (int)(pbComplete * pbUnit), pbHEIGHT));

            g.DrawString(pbComplete + "% Loading...", new Font("Arial", pbHEIGHT / 2), Brushes.Red, new PointF(pbWIDTH / 2 - pbHEIGHT, pbHEIGHT / 10));

            picboxPB.Image = bmp;

            pbComplete++;
            if (pbComplete > 101)
            {
                g.Dispose();
                t.Stop();

                Form1 f2 = new Form1();
                f2.Show();
                this.Hide();
            }



        }

        private void picboxPB_Click(object sender, EventArgs e)
        {

        }
    }
}
