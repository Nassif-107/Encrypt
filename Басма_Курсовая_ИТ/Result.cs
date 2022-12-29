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
using System.Diagnostics;

namespace Басма_Курсовая_ИТ
{
    public partial class Result : Form
    {
        Form2 f;
        public Result(Form2 f)
        {
            InitializeComponent();
            this.f = f;
        }

        private void опцииToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState= FormWindowState.Minimized;
        }

        private void вернутсяНазадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form2().Show();
            this.Hide();
        }

        private void вернутсяВЛогинToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmLogin().Show();
            this.Hide();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Result_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = f.encryptedText;
        }

        private void расшифроватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form5().Show();
            this.Hide();
        }
    }
}
