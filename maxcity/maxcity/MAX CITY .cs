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
    public partial class MAX_CITY : Form
    {
        //private int childFormNumber = 0;

        public MAX_CITY(string uname)
        {
            InitializeComponent();
            textBox1.Text = uname;
            textBox1.Enabled = false;
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Invoice ic = new Invoice(textBox1.Text);
            ic.Show();

        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void itemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Item_Create ic = new Item_Create();
            ic.Show();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customer_Create cc = new Customer_Create();
            cc.Show();
        }

        private void vendorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vendor_Create vc = new Vendor_Create();
            vc.Show();
        }

        private void invoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Invoice ic = new Invoice(textBox1.Text);
            ic.Show();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void invoiceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Invoice ic = new Invoice(textBox1.Text);
            ic.Show();

        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Create_Account CA = new Create_Account();
            CA.Show();
        }

        private void customerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Customer_Update cu = new Customer_Update();
            cu.Show();
        }

        private void vendorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Update_Vendor vu = new Update_Vendor();
            vu.Show();
        }

        private void itemToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ItemUpdate iu = new ItemUpdate();
            iu.Show();
        }
       
        private void MAX_CITY_Load(object sender, EventArgs e)
        {
           
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void printPreviewToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Invoice ic = new Invoice(textBox1.Text);
            ic.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Customer_Create cc = new Customer_Create();
            cc.Show();
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            Item_Create ic = new Item_Create();
            ic.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Customer_Update cu = new Customer_Update();
            cu.Show();
        }

        private void button1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                Invoice ic = new Invoice(textBox1.Text);
                ic.Show();

            }
        }

        private void button2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               
                Customer_Create cc = new Customer_Create();
                cc.Show();
            }
        }

        private void button3_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                Item_Create ic = new Item_Create();
                ic.Show();
            }
        }

        private void button4_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Customer_Update cu = new Customer_Update();
                cu.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Invoice ic = new Invoice(textBox1.Text);
            ic.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Customer_Create cc = new Customer_Create();
            cc.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Item_Create ic = new Item_Create();
            ic.Show();
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            
        }

        private void customerToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CustomerView cv = new CustomerView();
            cv.Show();

        }

        private void vendorToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            VendorView vv = new VendorView();
            vv.Show();
        }

        private void itemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemView iv = new ItemView();
            iv.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Low_Items_View iv = new Low_Items_View();
            iv.Show();

            Creditor cc = new Creditor();
            cc.Show();

            Loan_Customer_View cv = new Loan_Customer_View();
            cv.Show();

            Daily_Sales ds = new Daily_Sales();
            ds.Show();

        }

        private void accontsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountView av = new AccountView();
            av.Show();
        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sales sl = new Sales();
            sl.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Vendor_Create vc = new Vendor_Create();
            vc.Show();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Help he = new Help();
            he.Show();
            he.Hide();
            //System.Diagnostics.Process.Start("C:Help.pdf");
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }
            
    }
}