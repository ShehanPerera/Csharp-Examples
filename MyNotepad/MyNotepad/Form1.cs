using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MyNotepad
{
    public partial class MyNotepad : Form
    {
        String path;
        public MyNotepad()
        {
            InitializeComponent();
        }

      
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            path = string.Empty;
            textBox.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog openFileDialog = new OpenFileDialog(){Filter="Text Documents|*.txt",ValidateNames=true,
                Multiselect=false})
                {
                    try
                    {
                     if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            using (StreamReader streamReader = new StreamReader(openFileDialog.FileName))
                            {
                                path = openFileDialog.FileName;
                                String text = streamReader.ReadToEnd();
                                textBox.Text = text;
                            }
                        }
                    } catch (Exception error){
                        MessageBox.Show(error.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(path))
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "Text Documents|*.txt", ValidateNames = true })
                {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            path = saveFileDialog.FileName;
                            using (StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName))
                            {
                                streamWriter.WriteLine(textBox.Text);

                            }
                        } catch (Exception error){
                            MessageBox.Show(error.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

            }
            else
            {
                using(StreamWriter streamWriter = new StreamWriter(path))
                {
                    streamWriter.WriteLine(textBox.Text);

                }

            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(path))
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "Text Documents|*.txt", ValidateNames = true })
                {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            using (StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName))
                            {
                                streamWriter.WriteLine(textBox.Text);

                            }
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show(error.Message,"Message",MessageBoxButtons.OK,MessageBoxIcon.Error);

                        }
                    }
                }

            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

       
    }
}
