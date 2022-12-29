using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Басма_Курсовая_ИТ
{
    public partial class decode_01 : Form
    {
        Form8 f;
        public decode_01(Form8 f)
        {
            InitializeComponent();
            this.f = f;
        }

        private void decode_01_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = f.encryptedText;
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
            new Form8().Show();
            this.Hide();
        }

        private void вернутсяВЛогинToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmLogin().Show();
            this.Hide();
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

        private void расшифроватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }
    }
}
