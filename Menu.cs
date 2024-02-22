using PTPMUD_Project.BUS;
using PTPMUD_Project.DAO;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PTPMUD_Project
{
    public partial class Menu : Form
    {

        public Menu(string account)
        {
            InitializeComponent();
            Account = account;
            accountBUS = new AccountBUS();
        }

        private AccountBUS accountBUS;

        string Account;

        public void AddControl(Form f)
        {
            CenterPanel.Controls.Clear();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            CenterPanel.Controls.Add(f);
            f.Show();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            AddControl(new Home());
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            AddControl(new Order());
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            AddControl(new Product());
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            AddControl(new Table());
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            AddControl(new Admin());
        }
        public int id;
        private void Menu_Load(object sender, EventArgs e)
        {
            List<Account> Names = accountBUS.GetName(Account);
            foreach (Account Name in Names)
            {
                label2.Text = Name.Name;
                this.id = Name.Id;
                if (Name.Type != "Admin")
                {
                    btnAdmin.Visible = false;
                    adminToolStripMenuItem1.Visible = false;
                    changeDataAdminToolStripMenuItem.Visible = false;
                    btnOut.Location = new Point(0, 439);
                }
                else
                {
                    btnAdmin.Visible = true;
                    adminToolStripMenuItem1.Visible = true;
                    changeDataAdminToolStripMenuItem.Visible = true;
                    btnOut.Location = new Point(0, 490);
                }
            }
        }

        private void CenterPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnHome.PerformClick();
            AddControl(new Home());
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void orderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnOrder.PerformClick();
            AddControl(new Order());
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnProduct.PerformClick();
            AddControl(new Product());
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnTable.PerformClick();
            AddControl(new Table());
        }

        private void adminToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            btnAdmin.PerformClick();
            AddControl(new Admin());
        }

        private void changeDataAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StaffAdd staffAdd = new StaffAdd(id);
            staffAdd.FormClosed += (s, args) => Refresh();
            staffAdd.ShowDialog();
        }

        public void Refresh()
        {
            List<Account> Names = accountBUS.GetName(Account);
            foreach (Account Name in Names)
            {
                label2.Text = Name.Name;
                id = Name.Id;
                if (Name.Type != "Admin")
                {
                    btnAdmin.Visible = false;
                    adminToolStripMenuItem1.Visible = false;
                    changeDataAdminToolStripMenuItem.Visible = false;
                    btnOut.Location = new Point(0, 439);
                }
                else
                {
                    btnAdmin.Visible = true;
                    adminToolStripMenuItem1.Visible = true;
                    changeDataAdminToolStripMenuItem.Visible = true;
                    btnOut.Location = new Point(0, 490);
                }
            }
        }
    }
}
