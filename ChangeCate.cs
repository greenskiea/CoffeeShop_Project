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
    public partial class ChangeCate : Form
    {
        public new DialogResult DialogResult { get; private set; }
        private CategoryBUS categoryBUS;
        public Category category;
        public Category SelectedCategory;
        public ChangeCate()
        {
            InitializeComponent();
            categoryBUS = new CategoryBUS();
            txtCategoryName.Text = string.Empty;
            LabelText.Text = "Add Category";
            btnAdd.Visible = true;
            btnUpdate.Visible = false;
        }

        public ChangeCate(Category category)
        {
            InitializeComponent();
            categoryBUS = new CategoryBUS();
            SelectedCategory = category;
            txtCategoryName.Text = SelectedCategory.categoryName;
            LabelText.Text = "Edit Category";
            btnAdd.Visible = false;
            btnUpdate.Visible = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string CategoryName = txtCategoryName.Text;
            bool result = categoryBUS.InsertCategory(CategoryName);
            if (result)
            {
                DialogResult dialogResult = MessageBox.Show("Thêm thành công! Bạn muốn thêm tiếp không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    txtCategoryName.Text = string.Empty;
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel; // Đặt DialogResult là Cancel khi đóng form
            Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = SelectedCategory.categoryID;
            string CategoryName = txtCategoryName.Text;
            bool result = categoryBUS.UpdateCategory(id, CategoryName);
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

        private void ChangeCate_Load(object sender, EventArgs e)
        {

        }
    }
}
