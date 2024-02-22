using PTPMUD_Project.BUS;
using PTPMUD_Project.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PTPMUD_Project
{
    public partial class Login : Form
    {
        private AccountBUS accountBUS;
        public Login()
        {
            InitializeComponent();
            accountBUS = new AccountBUS();
            txtUsername.Text = string.Empty;
            txtPass.Text = string.Empty;
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string pass = txtPass.Text;
            if (accountBUS.IsValidUser(username, pass))
            {
                this.Hide();
                Menu menu = new Menu(username);
                menu.Show();
            }
            else
            {
                WarningDialog.Show("Invalid username and password, please try again!");
                return;
            }
        }

        private void txtUsername_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Please Enter The UserName";
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void txtPass_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Please Enter The Password";
        }

        private void btnLogin_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Press to Login";
        }

        private void btnExit_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Press to Exit App";

        }
    }
}
