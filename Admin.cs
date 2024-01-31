using PTPMUD_Project.BUS;
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
    public partial class Admin : Form
    {
        private AccountBUS accountBUS;
        public Admin()
        {
            InitializeComponent();
            accountBUS = new AccountBUS();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            StaffAdd staffAdd = new StaffAdd();
            staffAdd.Show();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            EmployeeDataGridView.DataSource = accountBUS.GetAllStaff();
        }

        private void EmployeeDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 8 && e.Value != null)
            {
                int genderValue = (int)e.Value;

                // Change the displayed value based on the Gender
                e.Value = (genderValue == 0) ? "Nam" : "Nữ";
                e.FormattingApplied = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (EmployeeDataGridView.SelectedRows.Count > 0)
            {
                string Email = EmployeeDataGridView.SelectedRows[0].Cells["Email"].Value.ToString();

                DialogResult result = MessageBox.Show("Are you sure you want to delete this account?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    bool success = accountBUS.DeleteAccount(Email);

                    if (success)
                    {
                        EmployeeDataGridView.DataSource = accountBUS.GetAllStaff();
                        MessageBox.Show("Account deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an account to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}
