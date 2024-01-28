using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTPMUD_Project
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

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
    }
}
