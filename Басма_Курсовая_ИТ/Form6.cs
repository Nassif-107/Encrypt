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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
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
            new Form5().Show();
            this.Hide();
        }

        private void главноеМенюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form4().Show();
            this.Hide();
        }

        private void логинToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmLogin().Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            string filename = "";
            DialogResult dr = ofdInsert.ShowDialog();
            if (dr == DialogResult.OK)
            {
                filename = ofdInsert.FileName;
                txtFilename.Text = filename;
            }
        }
        public string reverseGam = "";
        private void button3_Click(object sender, EventArgs e)
        {
            if(richTextBox1.Text == "")
            {
                string contents = File.ReadAllText(txtFilename.Text);
                reverseGam = gam.Decrypt(contents, textBox2.Text);
                decode_02 decode = new decode_02(this);
                decode.Show();
                this.Hide();

            }
            else
            {
                reverseGam = gam.Decrypt(richTextBox1.Text, textBox2.Text);
                decode_02 decode = new decode_02(this);
                decode.Show();
                this.Hide();

            }


        }
    }
}
