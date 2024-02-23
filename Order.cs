using PTPMUD_Project.BUS;
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
    public partial class Order : Form
    {
        private int idVoucher;
        public Order()
        {
            InitializeComponent();
            tableFoodBus = new TableFoodBUS();
            menuFoodBus = new MenuFoodBUS();
            categoryBus = new CategoryBUS();
            FoodBus = new FoodBUS();
            billBus = new BillBUS();
            billInfoBus = new BillInfoBUS();
            VoucherBus = new VoucherBUS();
            promotionBus = new PromotionBUS();
            foodPromotionBus = new Food_PromotionBUS();
            load();
        }
        TableFoodBUS tableFoodBus;
        MenuFoodBUS menuFoodBus;
        CategoryBUS categoryBus;
        FoodBUS FoodBus;
        BillBUS billBus;
        BillInfoBUS billInfoBus;
        VoucherBUS VoucherBus;
        PromotionBUS promotionBus;
        Food_PromotionBUS foodPromotionBus;
        #region Methods
        void load()
        {
            loadTable();
            loadCategory();
            loadComboboxTable(cboTable);
            loadVoucher(cboDiscountValue);




        }
        void loadCategory()
        {
            List<Category> listCategory = categoryBus.getALLCategory();
            cbocategory.DataSource = listCategory;
            cbocategory.DisplayMember = "categoryName";
        }

        void loadVoucher(ComboBox cb)
        {
            List<Voucher> listVoucher = VoucherBus.getALLVoucher();
            cb.DataSource = listVoucher;
            cb.DisplayMember = "discountValue";
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
            List<Food> foodList = FoodBus.getALLFood();
            List<Food_Promotion> foodPromotionList = foodPromotionBus.GetAllFood_Promotion();
            float totalPrice = 0;
            float newPrice = 0;
            foreach (MenuFood item in listBillInfo)
            {
                float price = (float)Convert.ToDouble(item.price.ToString());

                float discountValue = promotionBus.GetPriceDiscountByIDFood(item.foodId);

                float discount = 0;

                DateTime? getdate = DateTime.Now.Date;
                DateTime? dateFrom = promotionBus.GetDateFrom(item.foodId);
                DateTime? dateTo = promotionBus.GetDateTo(item.foodId);
                float priceDiscount = price - (price * discountValue) / 100;
                ListViewItem lsvItem = new ListViewItem(item.foodName.ToString());


                foreach (Food_Promotion food_pro in foodPromotionList)
                {
                    if (item.foodId == food_pro.Food_ID)
                    {
                        if (getdate >= dateFrom && getdate <= dateTo)
                        {
                            newPrice = priceDiscount;
                            discount = discountValue;
                            break;
                        }
                        else
                        {
                            newPrice = price;
                            discount = 0;

                        }
                    }
                    else
                    {
                        newPrice = price;
                        discount = 0;
                    }
                }



                lsvItem.SubItems.Add(item.count.ToString());
                lsvItem.SubItems.Add(newPrice.ToString());

                lsvItem.SubItems.Add(item.totalPrice.ToString());

                lsvItem.SubItems.Add(discount.ToString() + "%");

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
            int idBill = billBus.GetUnCheckBillIDByTableID(tableID);
            float discountValue = VoucherBus.getDiscountValue(idBill);
            if (discountValue != -1)
            {
                cboDiscountValue.Text = discountValue.ToString();
            }
            else
            {
                cboDiscountValue.Text = "0";
            }
            TableFood table = (sender as Button).Tag as TableFood;
            txtNote.Text = table.note;
            ShowBill(tableID);
        }
        public void UpdateNoteTextBox(string note)
        {
            txtNote.Text = note;
        }
        void loadComboboxTable(ComboBox cb)
        {
            cb.DataSource = tableFoodBus.getALLTable();
            cb.DisplayMember = "tableName";
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
            string nameFood = cboFood.SelectedItem as string;
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
                MessageBox.Show(string.Format("Nhập quá số lượng sản phẩm trong kho ({0} còn {1}! Yêu cầu nhập lại", nameFood, quantity));
                return;
            }
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            TableFood table = lsvBill.Tag as TableFood; // lấy được table hiện tại
            int idBill = billBus.GetUnCheckBillIDByTableID(table.idTable);
            float discountValue = VoucherBus.getDiscountValue(idBill);
            DateTime? voucehrDate = billBus.CheckVoucherDate(idBill);
            float maxPrice = VoucherBus.getMaxPrice(idBill);
            double totalPrice = double.Parse(txbTotalPrice.Text, NumberStyles.Currency, new CultureInfo("vi-VN"));
            double finalTotalPrice = totalPrice - (totalPrice / 100) * discountValue;

            if (idBill != -1)
            {
                if (voucehrDate != null)
                {
                    if (totalPrice > maxPrice)
                    {
                        if (MessageBox.Show(string.Format("Bạn có chắc thanh toán hóa đơn cho bàn {0}\n Tổng tiền - (Tổng tiền / 100) x Giảm giá\n=> {1} - ({1} / 100) x {2} = {3} ", table.tableName, totalPrice, discountValue, finalTotalPrice), "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            billBus.CheckOut(idBill, (float)finalTotalPrice);
                            ShowBill(table.idTable);
                            loadTable();
                        }
                    }
                    else
                    {
                        if (MessageBox.Show(string.Format("Bạn có chắc thanh toán hóa đơn cho bàn {0}\n Tổng tiền = {1}", table.tableName, totalPrice), "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            billBus.CheckOut(idBill, (float)totalPrice);
                            ShowBill(table.idTable);
                            loadTable();
                        }
                    }

                }
                else
                {
                    if (MessageBox.Show(string.Format("Bạn có chắc thanh toán hóa đơn cho bàn {0}\n Tổng tiền = {1}", table.tableName, totalPrice), "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        billBus.CheckOut(idBill, (float)totalPrice);
                        ShowBill(table.idTable);
                        loadTable();
                    }
                }

            }
        }

        private void btnSwitchTable_Click(object sender, EventArgs e)
        {
            int id1 = (lsvBill.Tag as TableFood).idTable;
            int id2 = (cboTable.SelectedItem as TableFood).idTable;
            if (MessageBox.Show(string.Format("Bạn có muốn chuyển bàn {0} sang bàn {1} ?", (lsvBill.Tag as TableFood).tableName, (cboTable.SelectedItem as TableFood).tableName), "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                tableFoodBus.SwitchTable(id1, id2);
                loadTable();
            }
        }

        private void cboDiscountValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cboDiscountValue.DataSource = VoucherBus.getALLVoucher();
            //cboDiscountValue.DisplayMember = "discountValue";
            cboDiscountValue.ValueMember = "Id";
            idVoucher = (int)cboDiscountValue.SelectedValue;
        }
        private void btnDiscount_Click(object sender, EventArgs e)
        {
            TableFood table = lsvBill.Tag as TableFood; // lấy được table hiện tại
            int idBill = billBus.GetUnCheckBillIDByTableID(table.idTable);
            DateTime? dateFrom = VoucherBus.GetVoucherDateFrom(idVoucher);
            DateTime? dateTo = VoucherBus.GetVoucherDateTo(idVoucher);
            DateTime? voucehrDate = billBus.CheckVoucherDate(idBill);

            if (voucehrDate >= dateFrom && voucehrDate <= dateTo)
            {
                if (billBus.SetDiscountValeByID(idVoucher, idBill))
                {
                    MessageBox.Show("Cập nhật giảm giá món ăn thành công");

                }
            }
            else
            {
                MessageBox.Show("Rất tiết Voucher đã không còn hạn sử dụng");
            }

        }
        private void btnAddNote_Click(object sender, EventArgs e)
        {
            int idTable = (lsvBill.Tag as TableFood).idTable;
            string note = txtNote.Text;
            bool result = tableFoodBus.SetNoteTableFood(note, idTable);
            if (result)
            {
                MessageBox.Show("Thêm ghi chú thành công");
                UpdateNoteTextBox(note);
            }
            else
            {
                MessageBox.Show("Thêm ghi chú thất bại");
            }
        }

        #endregion


        private void cboFood_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }


    }
}
