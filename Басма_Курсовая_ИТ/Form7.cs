using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Басма_Курсовая_ИТ
{
    public partial class Form7 : Form
    {
        Form3 f;
        public Form7(Form3 f)
        {
            InitializeComponent();
            this.f = f;
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = f.gamText;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState= FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            string path = saveFileDialog1.FileName;

            try
            {
                using (FileStream fs = File.Create(path))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(richTextBox1.Text);
                    fs.Write(info, 0, info.Length);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Проблема с сохранением!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void вернутсяНазадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form3().Show();
            this.Hide();
        }

        private void расшифроватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form5().Show();
            this.Hide();
        }

        private void вернутсяВЛогинToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmLogin().Show();
            this.Hide();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void опцииToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
