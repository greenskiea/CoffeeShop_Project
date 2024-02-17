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

namespace PTPMUD_Project
{
    public partial class EditProduct : Form
    {
        private Food foods;

        public Food Foods
        {

            get { return foods; }


            set { foods = value; loadFood(foods); }
        }
        public EditProduct(Food food)
        {
            InitializeComponent();
            this.Foods = food;
            foodBus = new FoodBUS();
            categoryBus = new CategoryBUS();
            load();
        }
        FoodBUS foodBus;
        CategoryBUS categoryBus;
        #region Methods
        public void load()
        {

            loadCategoryIntoCombobox(cboCategory_ID);
        }
        public void loadFood(Food food)
        {
            txtIDFood.Text = Foods.foodID.ToString();
            txtFood_Name.Text = Foods.foodName.ToString();
            nmPrice.Value = (decimal)Foods.price;
            cboCategory_ID.SelectedItem = Foods.categoryID;
            nmQuantity.Value = (decimal)Foods.quantity;

            int type = Foods.type;
            if (type == 1)
            {
                cboType.SelectedItem = "Sáng";
            }
            if (type == 2)
            {
                cboType.SelectedItem = "Chiều";
            }


        }
        public void loadCategoryIntoCombobox(System.Windows.Forms.ComboBox cb)
        {
            cb.DataSource = categoryBus.getALLCategory();
            cb.DisplayMember = "categoryName";
        }



        public void UpdateFoodInfo()
        {
            int idFood = Convert.ToInt32(txtIDFood.Text);
            string foodName = txtFood_Name.Text;
            float price = (float)nmPrice.Value;
            int categoryID = (cboCategory_ID.SelectedItem as Category).categoryID;
            int quantity = (int)nmQuantity.Value;
            int type = 0;

            if (cboType.SelectedItem != null)
            {
                if (cboType.SelectedItem.ToString().Equals("Sáng"))
                {
                    type = 1;
                }
                else if (cboType.SelectedItem.ToString().Equals("Chiều"))
                {
                    type = 2;
                }
            }

            if (foodBus.UpdateFood(idFood, foodName, price, categoryID, quantity, type))
            {
                MessageBox.Show("Cập nhật thành công");
                if (updateFood != null)
                {
                    updateFood(this, new FoodEvent(foodBus.GetFoodByID(idFood)));
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }

        }
        #endregion

        #region Events
        private event EventHandler<FoodEvent> updateFood;
        public event EventHandler<FoodEvent> UpdateFood
        {
            add { updateFood += value; }
            remove { updateFood -= value; }
        }
        private void EditProduct_Load(object sender, EventArgs e)
        {

            int type = Foods.type;
            if (type == 1)
            {
                cboType.SelectedItem = "Sáng";
            }
            if (type == 2)
            {
                cboType.SelectedItem = "Chiều";
            }
        }

        private void btnSaveFood_Click(object sender, EventArgs e)
        {
            UpdateFoodInfo();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtIDFood_TextChanged(object sender, EventArgs e)
        {
            
                int id = (cboCategory_ID.SelectedItem as Category).categoryID;

                Category category = categoryBus.GetCategoryByID(id);
                cboCategory_ID.SelectedItem = category;

                int index = -1;
                int i = 0;
                foreach (Category item in cboCategory_ID.Items)
                {
                    if (item.categoryID == category.categoryID)
                    {
                        index = i; break;
                    }
                    i++;

                }
                cboCategory_ID.SelectedIndex = index;
            
        }
        #endregion




    }
    public class FoodEvent : EventArgs
    {
        private Food food;

        public Food Food { get => food; set => food = value; }

        public FoodEvent(Food food)
        {
            this.Food = food;
        }
    }
}
