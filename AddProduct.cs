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
            load();
        }

        FoodBUS foodBus;
        CategoryBUS categoryBus;
        #region Methods

        void load()
        {

            loadCategoryIntoCombobox(cboCategory_ID);
        }
        void loadCategoryIntoCombobox(System.Windows.Forms.ComboBox cb)
        {
            cb.DataSource = categoryBus.getALLCategory();
            cb.DisplayMember = "categoryName";
        }

        #endregion
        #region Events
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            try
            {
                string foodName = txtFood_Name.Text;
                float price = (float)nmPrice.Value;
                int cateID = (cboCategory_ID.SelectedItem as Category).categoryID;
                int quantity = (int)nmQuantity.Value;
                int type = 0;

                if (cboType.SelectedItem != null)
                {
                    string selectedType = cboType.SelectedItem.ToString();
                    if (selectedType == "Morning")
                    {
                        type = 1;
                    }
                    else if (selectedType == "Afternoon")
                    {
                        type = 2;
                    }
                }

                if (foodBus.InsertFood(foodName, price, cateID, quantity, type))
                {
                    DialogResult dialogResult = MessageBox.Show("Add success! Do you want more?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        txtFood_Name.Text = "";
                        nmPrice.Value = 0;
                        nmQuantity.Value = 0;
                    }
                    else
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                    }

                }
                else
                {
                    MessageBox.Show("Error adding item");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
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

        }
        #endregion

        private void AddProduct_Load(object sender, EventArgs e)
        {

        }
    }
}
