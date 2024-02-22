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
    public partial class EditPro : Form
    {

        private PromotionBUS promotionBUS;
        private Promotion selectPromotion;
        public new DialogResult DialogResult { get; private set; }
        public EditPro()
        {
            InitializeComponent();
            promotionBUS = new PromotionBUS();
            LabelName.Text = "Add Promotion";
            btnUpdate.Visible = false;
            btnAdd.Visible = true;
            txtPromotionName.Text = string.Empty;
            txtDiscountValue.Text = string.Empty;
            txtDFD.Text = string.Empty;
            txtDTD.Text = string.Empty;
        }

        public EditPro(Promotion promotion)
        {
            InitializeComponent();
            promotionBUS = new PromotionBUS();
            LabelName.Text = "Update Promotion";
            btnUpdate.Visible = true;
            btnAdd.Visible = false;
            selectPromotion = promotion;
            txtPromotionName.Text = selectPromotion.PromotionName;
            txtDiscountValue.Text = selectPromotion.DiscountValue.ToString(); // Corrected to handle float
            txtDFD.Text = selectPromotion.DateFrom_Discount.ToString("MM/dd/yyyy");
            txtDTD.Text = selectPromotion.DateTo_Discount.ToString("MM/dd/yyyy");
            txtPromotionName.ReadOnly = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string Name = txtPromotionName.Text;
            if (!float.TryParse(txtDiscountValue.Text, out float Value) )
            {
                MessageBox.Show("Giá trị giảm giá không hợp lệ. Vui lòng nhập một số hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method to prevent further execution
            }
            if (Value <= 0 || Value >= 100)
            {
                MessageBox.Show("Giá trị giảm giá không hợp lệ. Vui lòng nhập một số hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method to prevent further execution
            }
            DateTime.TryParse(txtDFD.Text, out DateTime DFD);
            DateTime.TryParse(txtDTD.Text, out DateTime DTD);

            if (DFD >= DTD)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method to prevent further execution
            }

            bool result = promotionBUS.InsertPromotion(Name, Value, DFD, DTD);
            if (result)
            {
                DialogResult dialogResult = MessageBox.Show("Thêm thành công! Bạn muốn thêm tiếp không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    txtPromotionName.Text = string.Empty;
                    txtDiscountValue.Text = string.Empty;
                    txtDFD.Text = string.Empty;
                    txtDTD.Text = string.Empty;
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
            int id = selectPromotion.PromotionID;
            string PromotionName = txtPromotionName.Text;
            if (!float.TryParse(txtDiscountValue.Text, out float Value))
            {
                MessageBox.Show("Giá trị giảm giá không hợp lệ. Vui lòng nhập một số hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method to prevent further execution
            }
            if(Value <= 0 || Value >= 100)
            {
                MessageBox.Show("Giá trị giảm giá không hợp lệ. Vui lòng nhập một số hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method to prevent further execution
            }
            DateTime.TryParse(txtDFD.Text, out DateTime DFD);
            DateTime.TryParse(txtDTD.Text, out DateTime DTD);
            if (DFD >= DTD)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method to prevent further execution
            }
            bool result = promotionBUS.UpdatePromotion(id, PromotionName, Value, DFD, DTD);
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
    }
}
