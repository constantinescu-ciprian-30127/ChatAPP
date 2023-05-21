using Chat_app_Client;
using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Login_and_Register_System
{
    public partial class Register : Form
    {

        public Register()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" && txtPassword.Text == "" && txtConfirmPass.Text == "")
            {
                MessageBox.Show("Username and Password fields are empty", "Registration failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Account.searchUser(txtUsername.Text))
            {
                MessageBox.Show("User already exists", "Registration failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Text = "";
                txtConfirmPass.Text = "";
                txtPassword.Text = "";

            }
            else if(txtPassword.Text == txtConfirmPass.Text)
            {
                Account.addUser(txtUsername.Text, txtPassword.Text);

                txtUsername.Text = "";
                txtConfirmPass.Text = "";
                txtPassword.Text = "";

                MessageBox.Show("Your Account has been Successfully Created!", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Passwords does not match, Please Re-enter", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Text = "";
                txtConfirmPass.Text = "";
                txtPassword.Focus();
            }


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtConfirmPass.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
                txtConfirmPass.PasswordChar = '*';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtConfirmPass.Text = "";
            txtPassword.Text = "";
            txtUsername.Focus();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Closed += (s, args) => this.Close();
            login.Show();
        }

    }
}
