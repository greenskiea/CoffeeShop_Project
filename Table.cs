using PTPMUD_Project.BUS;
using PTPMUD_Project.DAO;
using PTPMUD_Project.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTPMUD_Project
{
    public partial class Table : Form
    {
        public Table()
        {
            InitializeComponent();
            tableFoodBus = new TableFoodBUS();
            menuFoodBus = new MenuFoodBUS();
            categoryBus = new CategoryBUS();
            FoodBus = new FoodBUS();
            billBus = new BillBUS();
            billInfoBus = new BillInfoBUS();
            VoucherBus = new VoucherBUS();
            load();
        }
        TableFoodBUS tableFoodBus;
        MenuFoodBUS menuFoodBus;
        CategoryBUS categoryBus;
        FoodBUS FoodBus;
        BillBUS billBus;
        BillInfoBUS billInfoBus;
        VoucherBUS VoucherBus;
        #region Methods
        void load()
        {
            loadTable();
            loadCategory();
            loadComboboxTable(cboTable);
            float discountValue = VoucherBus.getDiscountValue();
            nmDiscount.Value = (decimal)discountValue;
        }
        void loadCategory()
        {
            List<Category> listCategory = categoryBus.getALLCategory();
            cbocategory.DataSource = listCategory;
            cbocategory.DisplayMember = "categoryName";
        }

        void loadFoodBycategoryID(int id)
        {
            List<Food> listFood = FoodBus.GetFoodByCategoryID(id);
            cboFood.DataSource = listFood;
            cboFood.DisplayMember = "foodName";
        }
        void ShowBill(int id)
        {
            lsvBill.Items.Clear();
            List<MenuFood> listBillInfo = menuFoodBus.GetListMenuByTable(id);
            float totalPrice = 0;
            foreach (MenuFood item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.foodName.ToString());
                lsvItem.SubItems.Add(item.count.ToString());
                lsvItem.SubItems.Add(item.price.ToString());
                lsvItem.SubItems.Add(item.totalPrice.ToString());
                totalPrice += item.totalPrice;
                lsvBill.Items.Add(lsvItem);
            }
            CultureInfo culture = new CultureInfo("vi-VN"); // en-US: tiền đô

            //Thread.CurrentThread.CurrentCulture = culture;

            txbTotalPrice.Text = totalPrice.ToString("c", culture);


        }
        void loadTable()
        {
            flbTable.Controls.Clear();
            List<DTO.TableFood> tableList = tableFoodBus.getALLTable();
            foreach (TableFood item in tableList)
            {
                Button btn = new Button() { Width = TableFoodBUS.TableWidth, Height = TableFoodBUS.TableHeight };
                btn.Text = item.tableName + Environment.NewLine + item.status;
                btn.Click += btn_Click;
                btn.Tag = item;
                switch (item.status)
                {
                    case "Trống":
                        btn.BackColor = Color.Aqua;
                        break;
                    default:
                        btn.BackColor = Color.LightPink;
                        break;
                }
                flbTable.Controls.Add(btn);
            }
        }
        #endregion

        #region Events
        void btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as TableFood).idTable;
            lsvBill.Tag = (sender as Button).Tag;
            ShowBill(tableID);
        }
        private void cbocategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
                return;
            Category selected = cb.SelectedItem as Category;
            id = selected.categoryID;
            loadFoodBycategoryID(id);
        }
        void loadComboboxTable(ComboBox cb)
        {
            cb.DataSource = tableFoodBus.getALLTable();
            cb.DisplayMember = "tableName";
        }
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            TableFood table = lsvBill.Tag as TableFood;
            if (table == null)
            {
                MessageBox.Show("Hãy chọn bàn");
                return;
            }

            int idBill = billBus.GetUnCheckBillIDByTableID(table.idTable);
            int foodID = (cboFood.SelectedItem as Food).foodID;
            int count = (int)nmQuantity.Value;
            int quantity = FoodBus.getQuantityFood(foodID);
            if (count < quantity)
            {
                if (idBill == -1)
                {
                    billBus.InsertBill(table.idTable);
                    billInfoBus.InsertBillInfo(billBus.GetMaxIDBill(), foodID, count);
                }
                else
                {
                    billInfoBus.InsertBillInfo(idBill, foodID, count);
                }
                ShowBill(table.idTable);
                loadTable();
            }
            else
            {
                MessageBox.Show("Nhập quá số lượng món ăn trong kho! Yêu cầu nhập lại");
                return;
            }

        }

        private void btnSwitchTable_Click(object sender, EventArgs e)
        {
            int id1 = (lsvBill.Tag as TableFood).idTable;
            int id2 = (cboTable.SelectedItem as TableFood).idTable;
            if (MessageBox.Show(string.Format("Do you really want to move table {0} to table {1} ?", (lsvBill.Tag as TableFood).tableName, (cboTable.SelectedItem as TableFood).tableName), "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                tableFoodBus.SwitchTable(id1, id2);
                loadTable();
            }
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            TableFood table = lsvBill.Tag as TableFood; // lấy được table hiện tại
            float discountValue = VoucherBus.getDiscountValue();
            nmDiscount.Value = (decimal)discountValue;
            int idBill = billBus.GetUnCheckBillIDByTableID(table.idTable);
            double totalPrice = double.Parse(txbTotalPrice.Text, NumberStyles.Currency, new CultureInfo("vi-VN"));
            double finalTotalPrice = totalPrice - (totalPrice / 100) * discountValue;

            if (idBill != -1)
            {
                if (MessageBox.Show(string.Format("Bạn có chăc thanh toán hóa đơn cho bàn {0}\n Tổng tiền - (Tổng tiền / 100) x Giảm giá\n=> {1} - ({1} / 100) x {2} = {3} ", table.tableName, totalPrice, discountValue, finalTotalPrice), "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    billBus.CheckOut(idBill, (float)finalTotalPrice);
                    ShowBill(table.idTable);
                    loadTable();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }


    }
}
