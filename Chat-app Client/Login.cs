using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chat_app_Client;
using MySql.Data.MySqlClient;


namespace Login_and_Register_System
{
    public partial class Login : Form
    {
        public Login()
        {

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Account.getUserStatus(txtUsername.Text) == true)
            {
                MessageBox.Show("User already logged in", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Account.checkUser(txtUsername.Text, txtPassword.Text))
            {
                this.Hide();
                Chat chat = new Chat(txtUsername.Text);
                chat.Closed += (s, args) => this.Close();
                chat.Show();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password, Please Try again", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Text = "";
                txtPassword.Text = "";
                txtUsername.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtUsername.Focus();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register register = new Register();
            register.Closed += (s, args) => this.Close();
            register.Show();
        }
    }
}
