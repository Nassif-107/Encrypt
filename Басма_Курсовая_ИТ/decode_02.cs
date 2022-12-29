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
    public partial class decode_02 : Form
    {
        Form6 f;
        public decode_02(Form6 f)
        {
            InitializeComponent();
            this.f = f;
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
            new Form6().Show();
            this.Hide();
        }

        private void расшифроватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form1().Show();
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

        private void главноеМенюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form4().Show();
            this.Hide();
        }
    }
}
