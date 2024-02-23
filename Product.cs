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
            promotionBus = new PromotionBUS();
            catelist = new List<Category>();
            voucherBus = new VoucherBUS();
            lsvProduct.View = View.Details;
            load();
        }

        List<Category> catelist;
        FoodBUS foodBus;
        CategoryBUS categoryBus;
        PromotionBUS promotionBus;
        VoucherBUS voucherBus;

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
                Category category = categoryBus.GetCategoryByID(f.categoryID);
                string categoryName = (category != null) ? category.categoryName : "Unknown";
                string types = "";
                int type = f.type;
                if (type == 1)
                {
                    types = "Sáng";
                }
                else if (type == 2)
                {
                    types = "Chiều";
                }

                ListViewItem item = new ListViewItem(new string[] { f.foodID.ToString() });
                item.SubItems.Add(f.foodName.ToString());
                item.SubItems.Add(f.price.ToString());
                item.SubItems.Add(categoryName);
                item.SubItems.Add(f.quantity.ToString());
                item.SubItems.Add(types);
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

            CategoryGridView.DataSource = categoryBus.getALLCategory();
            CategoryGridView.Columns["categoryID"].Visible = false;
            PromotionGridView.DataSource = promotionBus.getAllPromotion();
            PromotionGridView.Columns["PromotionID"].Visible = false;
            dtgvVoucher.DataSource = voucherBus.getALLVoucher();
            dtgvVoucher.Columns["Id"].Visible = false;

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



        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
        private void btnEditFood_Click(object sender, EventArgs e)
        {
            if (lsvProduct.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lsvProduct.SelectedItems[0];

                int id = Convert.ToInt32(selectedItem.SubItems[0].Text);
                Food foods = foodBus.GetFoodByID(id);
                EditProduct editProduct = new EditProduct(foods);
                this.Hide();
                editProduct.ShowDialog();
                this.Show();
            }

        }

        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            if (lsvProduct.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lsvProduct.SelectedItems[0];

                int id = Convert.ToInt32(selectedItem.SubItems[0].Text);
                if (foodBus.DeleteFood(id))
                {
                    MessageBox.Show("Delete item successfully");
                    loadListFood();
                    //if (deleteFood != null)
                    //    deleteFood(this, new EventArgs());

                }
                else
                {
                    MessageBox.Show("Error while deleting item");
                }



            }

        }
        #endregion


        private void AddCatebtn_Click(object sender, EventArgs e)
        {
            ChangeCate changeCate = new ChangeCate();
            changeCate.FormClosed += (s, args) => RefreshDataGridView();
            changeCate.ShowDialog();
        }

        public void RefreshDataGridView()
        {
            CategoryGridView.DataSource = categoryBus.getALLCategory();
        }

        public void RefreshPromotionGridView()
        {
            PromotionGridView.DataSource = promotionBus.getAllPromotion();
        }

        private void EditCateBtn_Click(object sender, EventArgs e)
        {
            if (CategoryGridView.SelectedRows.Count > 0)
            {
                Category SelectedCategory = (Category)CategoryGridView.SelectedRows[0].DataBoundItem;
                ChangeCate changeCate = new ChangeCate(SelectedCategory);
                changeCate.FormClosed += (s, args) => RefreshDataGridView();
                changeCate.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select an account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteCatebtn_Click(object sender, EventArgs e)
        {
            if (CategoryGridView.SelectedRows.Count > 0)
            {
                string CategoryID = CategoryGridView.SelectedRows[0].Cells["categoryID"].Value.ToString();

                DialogResult result = MessageBox.Show("Are you sure you want to delete this ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    bool success = categoryBus.DeleteCategory(CategoryID);

                    if (success)
                    {
                        CategoryGridView.DataSource = categoryBus.getALLCategory();
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
                MessageBox.Show("Please select an account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchProductTxt_TextChanged(object sender, EventArgs e)
        {
            SearchProducts(SearchProductTxt.Text);
        }

        private void SearchProducts(string keyword)
        {
            // Xóa tất cả các mục hiện tại trong ListView
            lsvProduct.Items.Clear();

            // Lấy danh sách tất cả các sản phẩm
            List<Food> foodList = foodBus.getALLFood();

            // Lặp qua từng sản phẩm để tìm kiếm và hiển thị
            foreach (Food f in foodList)
            {
                // Kiểm tra xem tên sản phẩm chứa từ khoá tìm kiếm
                if (f.foodName.ToLower().Contains(keyword.ToLower()))
                {
                    Category category = categoryBus.GetCategoryByID(f.categoryID);
                    string categoryName = (category != null) ? category.categoryName : "Unknown";
                    string types = "";
                    int type = f.type;
                    if (type == 1)
                    {
                        types = "Sáng";
                    }
                    else if (type == 2)
                    {
                        types = "Chiều";
                    }

                    ListViewItem item = new ListViewItem(new string[] { f.foodID.ToString() });
                    item.SubItems.Add(f.foodName.ToString());
                    item.SubItems.Add(f.price.ToString());
                    item.SubItems.Add(categoryName);
                    item.SubItems.Add(f.quantity.ToString());
                    item.SubItems.Add(types);
                    lsvProduct.Items.Add(item);
                }
            }
        }

        private void guna2TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2TabControl1.SelectedTab == tabProduct)
            {
                SearchProductTxt.Visible = true;
                List<Category> cateList = categoryBus.getALLCategory();
                foreach (Category cate in cateList)
                {
                    TreeNode tn = new TreeNode(cate.categoryName);
                    tn.Name = cate.categoryName;
                    tn.Tag = cate.categoryID;
                    treeView1.Nodes.Add(tn);
                    label1.Text = "Food";
                    //treeView1.ExpandAll();
                }
                label2.Visible = true;
            }
            else if (guna2TabControl1.SelectedTab == tabCategory)
            {
                SearchProductTxt.Visible = false;
                label2.Visible = false;
                treeView1.Nodes.Clear();
                label1.Text = "Category";
            }

            else if (guna2TabControl1.SelectedTab == tabPromotion)
            {
                SearchProductTxt.Visible = false;
                label2.Visible = false;
                treeView1.Nodes.Clear();
                label1.Text = "Promotion";
            }
            else if (guna2TabControl1.SelectedTab == tabVoucher)
            {
                SearchProductTxt.Visible = false;
                label2.Visible = false;
                treeView1.Nodes.Clear();
                label1.Text = "Voucher";
            }
        }

        public EditPro editPro;
        private void btnAddPro_Click(object sender, EventArgs e)
        {
            editPro = new EditPro();
            editPro.FormClosed += (s, args) => RefreshPromotionGridView();
            editPro.ShowDialog();
        }

        private void btnEditPro_Click(object sender, EventArgs e)
        {
            if (PromotionGridView.SelectedRows.Count > 0)
            {
                Promotion selectedPro = (Promotion)PromotionGridView.SelectedRows[0].DataBoundItem;

                editPro = new EditPro(selectedPro);
                editPro.FormClosed += (s, args) => RefreshPromotionGridView();
                editPro.ShowDialog();
            }
        }

        private void btnExitPro_Click(object sender, EventArgs e)
        {
            if (PromotionGridView.SelectedRows.Count > 0)
            {
                string PromotionID = PromotionGridView.SelectedRows[0].Cells["PromotionID"].Value.ToString();

                DialogResult result = MessageBox.Show("Are you sure you want to delete this ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    bool success = promotionBus.DeletePromotion(PromotionID);

                    if (success)
                    {
                        PromotionGridView.DataSource = promotionBus.getAllPromotion();
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
                MessageBox.Show("Please select an account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public EditVoucher editVoucher;
        private void btnAddVoucher_Click(object sender, EventArgs e)
        {
            editVoucher = new EditVoucher();
            editVoucher.FormClosed += (s, args) => RefreshVoucher();
            editVoucher.ShowDialog();
        }

        public void RefreshVoucher()
        {
            dtgvVoucher.DataSource = voucherBus.getALLVoucher();
        }

        private void btnEditVoucher_Click(object sender, EventArgs e)
        {
            if (dtgvVoucher.SelectedRows.Count > 0)
            {
                Voucher SelectedVou = (Voucher)dtgvVoucher.SelectedRows[0].DataBoundItem;

                editVoucher = new EditVoucher(SelectedVou);
                editVoucher.FormClosed += (s, args) => RefreshVoucher();
                editVoucher.ShowDialog();
            }
        }

        private void btnDeleteVoucher_Click(object sender, EventArgs e)
        {
            if (dtgvVoucher.SelectedRows.Count > 0)
            {
                string voucherID = dtgvVoucher.SelectedRows[0].Cells["Id"].Value.ToString();

                DialogResult result = MessageBox.Show("Are you sure you want to delete this ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    bool success = voucherBus.DeleteVoucher(voucherID);

                    if (success)
                    {
                        dtgvVoucher.DataSource = voucherBus.getALLVoucher();
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
                MessageBox.Show("Please select an account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
