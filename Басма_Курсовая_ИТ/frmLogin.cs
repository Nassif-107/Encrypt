using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Configuration;
using System.Xml.Linq;
using System.IO;
using MySql.Data.MySqlClient;

namespace Басма_Курсовая_ИТ
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            string username = txtUserName.Text;
            string password = txtPassword.Text;

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM users WHERE User_name = @un and Password = @pw", db.getConnection());

            command.Parameters.Add("@un",MySqlDbType.VarChar, 140).Value = username;
            command.Parameters.Add("@pw",MySqlDbType.VarChar, 140).Value = password;

            adapter.SelectCommand= command;
            adapter.Fill(table);

            if(table.Rows.Count > 0)
            {
                new Form4().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неверные данные, пожалуйста, попробуйте еще раз", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                button2_Click(sender, e);
                this.txtUserName.Focus();
                return;
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtUserName.Focus();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '•';
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new frmRegister().Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
