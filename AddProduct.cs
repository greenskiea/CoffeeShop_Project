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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PTPMUD_Project
{
    public partial class AddProduct : Form
    {
        public AddProduct()
        {
            InitializeComponent();
            foodBus = new FoodBUS();
            categoryBus = new CategoryBUS();
        }

        FoodBUS foodBus;
        CategoryBUS categoryBus;
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            try
            {
                
                
                Food food = new Food
                {
                    foodName = txtFood_Name.Text,
                    price = (float)nmPrice.Value,
                    categoryID = Int32.Parse(cboCategory_ID.ValueMember.ToString()),
                    quantity = (int)nmQuantity.Value,
                    type = Int32.Parse(cboType.Text),
                    promotionID = Int32.Parse(cboPromotion_ID.Text)

                };
                bool result = foodBus.InsertFood(food);
                if (result)
                {
                    MessageBox.Show("Thêm thành công!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void nmQuantity_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cboCategory_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Category> cate = categoryBus.getALLCategory();
            System.Windows.Forms.ComboBox comboBox = new System.Windows.Forms.ComboBox();
            cboCategory_ID.DataSource = cate;
            cboCategory_ID.DisplayMember = "Category_Name";
            cboCategory_ID.ValueMember = "Category_ID";
            foreach (Category c in cate)
            {
                ListItem item = new ListItem(c.categoryName, c.categoryID);

                // Thêm ListItem vào ComboBox
                cboCategory_ID.Items.Add(item);
            }
            comboBox.DisplayMember = "Text";

            comboBox.ValueMember = "Value";
        }
    }
}
