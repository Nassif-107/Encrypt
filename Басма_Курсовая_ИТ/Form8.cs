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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void вернутсяНазадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState= FormWindowState.Minimized;
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
        public string encryptedText = "";

        private void button3_Click(object sender, EventArgs e)
        {
            string contents = File.ReadAllText(txtFilename.Text);
            string text = richTextBox1.Text;
            string key = textBox2.Text;

            if (richTextBox1.Text == "")
            {
                if (key?.Length != contents.Length)
                {
                    int l = key.Length;
                    for (int k = key.Length; k <= contents.Length; k++)
                    {
                        key += key[k - l];
                    }
                }
                for (int i = 0; i < contents.Length; i++)
                {
                    encryptedText += (char)(contents[i] ^ key[i]);
                }

                decode_01 decode = new decode_01(this);
                decode.Show();
                this.Hide();

            }
            else
            {
                if (key?.Length != text.Length)
                {
                    int l = key.Length;
                    for (int k = key.Length; k <= text.Length; k++)
                    {
                        key += key[k - l];
                    }
                }
                for (int i = 0; i < text.Length; i++)
                {
                    encryptedText += (char)(text[i] ^ key[i]);
                }

                decode_01 decode = new decode_01(this);
                decode.Show();
                this.Hide();

            }

        }
    }
}
