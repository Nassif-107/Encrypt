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
using MySql.Data.MySqlClient;

namespace Басма_Курсовая_ИТ
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();

        }
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\db_users.accdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        private void frmRegister_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command= new MySqlCommand("INSERT INTO users (User_name, Password) VALUES (@un, @pw)", db.getConnection());

            command.Parameters.Add("@un", MySqlDbType.VarChar,140).Value = txtUserName.Text;
            command.Parameters.Add("@pw", MySqlDbType.VarChar, 140).Value = txtPassword.Text;

            db.openConnection();

            if ((txtUserName.Text == "" && txtPassword.Text == "" && txtRepPassword.Text == "") ||
                txtUserName.Text == "" || txtPassword.Text == "" || txtRepPassword.Text == "")
            {
                MessageBox.Show("Поля регистрации пустые", "Регистрация не выполнена", MessageBoxButtons.OK, MessageBoxIcon.Error);
                button2_Click(sender, e);
            }
            else if (txtPassword.Text != txtRepPassword.Text)
            {
                MessageBox.Show("Пороли не совподают", "Пожалуйста повторно введите пороль", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Text = "";
                txtRepPassword.Text = "";
                txtPassword.Focus();
            }
            else
            {
                if (checkUsername())
                {
                    MessageBox.Show("Этот пользователь уже существует", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Ваша учетная запись была успешно создана!", "Регистрация выполнена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        new frmLogin().Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка в регистрации!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }

            db.closeConnection();

        }
        public Boolean checkUsername()
        {
            DB db = new DB();
            string username = txtUserName.Text;
            string password = txtPassword.Text;

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM users WHERE User_name = @un", db.getConnection());

            command.Parameters.Add("@un", MySqlDbType.VarChar, 140).Value = username;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if ( checkBox1.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtRepPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '•';
                txtRepPassword.PasswordChar = '•';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtRepPassword.Text = "";
            txtUserName.Focus();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new frmLogin().Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState= FormWindowState.Minimized;
        }
    }
}
