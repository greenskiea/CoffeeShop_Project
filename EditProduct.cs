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
    public partial class EditProduct : Form
    {
        public EditProduct()
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

        #endregion
    }
}
