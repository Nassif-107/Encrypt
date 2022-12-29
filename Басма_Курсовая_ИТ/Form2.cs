using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;

namespace Басма_Курсовая_ИТ
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState= FormWindowState.Minimized;
        }
        public string encryptedText = "";
        private void button3_Click(object sender, EventArgs e)
        {
            string text = richTextBox1.Text;
            string key = textBox2.Text;
            
            if(richTextBox1.Text == "")
            {
                string contents = File.ReadAllText(txtFilename.Text);
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

                Result result = new Result(this);
                result.Show();
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

                Result result = new Result(this);
                result.Show();
                this.Hide();

            }
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFilename_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
