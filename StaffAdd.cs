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

namespace PTPMUD_Project
{
    public partial class StaffAdd : Form
    {
        public new DialogResult DialogResult { get; private set; }
        public StaffAdd()
        {
            InitializeComponent();
            accountBUS = new AccountBUS();
            txtPhone.KeyPress += new KeyPressEventHandler(txtPhone_KeyPress);
            txtUsername.Text = "";
            txtPass.Text = "";
            txtEmail.Text = "";
            txtName.Text = "";
            txtPerID.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            txtDOB.Text = "";
            txtGender.SelectedIndex = -1;
            btnUpdate.Visible = false;
        }

        public StaffAdd(Account account)
        {
            InitializeComponent();
            accountBUS = new AccountBUS();
            txtPhone.KeyPress += new KeyPressEventHandler(txtPhone_KeyPress);
            SelectedAccount = account;
            txtUsername.Text = SelectedAccount.Username;
            txtPass.Text = SelectedAccount.Password;
            txtEmail.Text = SelectedAccount.Email;
            txtName.Text = SelectedAccount.Name;
            txtPerID.Text = SelectedAccount.Personal_ID;
            txtAddress.Text = SelectedAccount.Address;
            txtPhone.Text = SelectedAccount.PhoneNumber;

            if (DateTime.TryParse(SelectedAccount.DOB, out DateTime dob))
            {
                txtDOB.Text = dob.ToString("MM/dd/yyyy");
            }

            txtGender.SelectedIndex = SelectedAccount.Gender;
            btnAdd.Visible = false;
        }

        public Account SelectedAccount;


        private AccountBUS accountBUS;



        private void StaffAdd_Load_1(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string Username = txtUsername.Text;
                string Password = txtPass.Text;
                string Email = txtEmail.Text;
                string Type = "Employee";
                string Name = txtName.Text;
                string Personal_ID = txtPerID.Text;
                string Address = txtAddress.Text;
                string Phone = txtPhone.Text;
                string DOB = txtDOB.Text;
                int Gender = -1;
                if (txtGender.SelectedItem.ToString() == "Nam")
                {
                    Gender = 0;
                }
                else if (txtGender.SelectedItem.ToString() == "Nữ")
                {
                    Gender = 1;
                }
                bool result = accountBUS.InsertAccount(Username, Password, Email, Type, Name, Personal_ID, Address, Phone, DOB, Gender);
                if (result)
                {
                    DialogResult dialogResult = MessageBox.Show("Thêm thành công! Bạn muốn thêm tiếp không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.Yes)
                    {
                        txtUsername.Text = "";
                        txtPass.Text = "";
                        txtEmail.Text = "";
                        txtName.Text = "";
                        txtPerID.Text = "";
                        txtAddress.Text = "";
                        txtPhone.Text = "";
                        txtDOB.Text = "";
                        txtGender.SelectedIndex = -1;
                    }
                    else
                    {
                        DialogResult = DialogResult.OK; // Cập nhật DialogResult
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("thêm thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel; // Đặt DialogResult là Cancel khi đóng form
            Close();
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Suppress non-numeric input
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int Id = SelectedAccount.Id;
            string Username = txtUsername.Text;
            string Password = txtPass.Text;
            string Email = txtEmail.Text;
            string Type = "Employee";
            string Name = txtName.Text;
            string Personal_ID = txtPerID.Text;
            string Address = txtAddress.Text;
            string Phone = txtPhone.Text;
            string DOB = txtDOB.Text;
            int Gender = -1;
            if (txtGender.SelectedItem.ToString() == "Nam")
            {
                Gender = 0;
            }
            else if (txtGender.SelectedItem.ToString() == "Nữ")
            {
                Gender = 1;
            }

            bool result = accountBUS.UpdateAccount(Id, Username, Password, Email, Type, Name, Personal_ID, Address, Phone, DOB, Gender);
            if (result)
            {
                MessageBox.Show("Cập nhật thành công!");
                DialogResult = DialogResult.OK; // Cập nhật DialogResult
                Close();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!");
            }
        }

        private void txtDOB_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
