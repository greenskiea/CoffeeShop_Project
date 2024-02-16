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
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
            foodBus = new FoodBUS();
            categoryBus = new CategoryBUS();
            catelist = new List<Category>();
            lsvProduct.View = View.Details;
            load();
        }

        List<Category> catelist;
        FoodBUS foodBus;
        CategoryBUS categoryBus;

        #region Methods
        void load()
        {
            loadListFood();
        }
        void loadListFood()
        {
            lsvProduct.Items.Clear();
            List<Food> foodList = foodBus.getALLFood();
            foreach (Food f in foodList)
            {

                ListViewItem item = new ListViewItem(new string[] { f.foodID.ToString() });
                item.SubItems.Add(f.foodName.ToString());
                item.SubItems.Add(f.price.ToString());
                item.SubItems.Add(f.categoryID.ToString());
                item.SubItems.Add(f.quantity.ToString());
                item.SubItems.Add(f.type.ToString());
                lsvProduct.Items.Add(item);

            }
        }
        #endregion
        #region Events
        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Product_Load(object sender, EventArgs e)
        {
            List<Category> cateList = categoryBus.getALLCategory();
            foreach (Category cate in cateList)
            {
                TreeNode tn = new TreeNode(cate.categoryName);
                tn.Name = cate.categoryName;
                tn.Tag = cate.categoryID;
                treeView1.Nodes.Add(tn);
                //treeView1.ExpandAll();
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

            TreeNode node = e.Node;
            List<Food> foodList = foodBus.GetFoodByCategoryID((int)node.Tag);
            lsvProduct.Items.Clear();
            List<Category> categoryList = categoryBus.getALLCategory();
            foreach (Food f in foodList)
            {

                Category category = categoryList.FirstOrDefault(c => c.categoryID == f.categoryID);
                ListViewItem item = new ListViewItem(new string[] { f.foodID.ToString() });
                item.SubItems.Add(f.foodName.ToString());
                item.SubItems.Add(f.price.ToString());
                item.SubItems.Add(f.categoryID.ToString(category.categoryName));
                item.SubItems.Add(f.quantity.ToString());
                item.SubItems.Add(f.type.ToString());
                lsvProduct.Items.Add(item);

            }
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            AddProduct addProduct = new AddProduct();
            this.Hide();
            addProduct.ShowDialog();
            this.Show();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
        private void btnEditFood_Click(object sender, EventArgs e)
        {
            EditProduct editProduct = new EditProduct();
            this.Hide();
            editProduct.ShowDialog();
            this.Show();
        }

        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            if (lsvProduct.SelectedItems.Count > 0) {
                ListViewItem selectedItem = lsvProduct.SelectedItems[0];

                int id = Convert.ToInt32(selectedItem.SubItems[0].Text);
                if (foodBus.DeleteFood(id))
                {
                    MessageBox.Show("Xóa món thành công");
                    loadListFood();
                    //if (deleteFood != null)
                    //    deleteFood(this, new EventArgs());

                }
                else
                {
                    MessageBox.Show("Có lối khi Xóa món ăn");
                }



            }
                
        }
        #endregion


    }
}
