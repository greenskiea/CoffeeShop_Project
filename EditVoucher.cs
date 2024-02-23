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
    public partial class EditVoucher : Form
    {
        private VoucherBUS voucherBUS { get; set; }
        public new DialogResult DialogResult { get; private set; }
        public EditVoucher()
        {
            InitializeComponent();
            voucherBUS = new VoucherBUS();
            LabelName.Text = "Add Voucher";
            btnAdd.Visible = true;
            btnUpdateVoucher.Visible = false;
            txtCode.Text = string.Empty;
            txtDFD.Text = string.Empty;
            txtDTD.Text = string.Empty;
            txtDiscountValue.Text = string.Empty;
            txtMaxPrice.Text = string.Empty;
        }

        private Voucher selectedVoucher;
        public EditVoucher(Voucher voucher)
        {
            InitializeComponent();
            voucherBUS = new VoucherBUS();
            LabelName.Text = "Edit Voucher";
            btnAdd.Visible = false;
            btnUpdateVoucher.Visible = true;
            selectedVoucher = voucher;
            txtCode.Text = selectedVoucher.code;
            txtDFD.Text = selectedVoucher.dateFrom.ToString("MM/dd/yyyy");
            txtDTD.Text = selectedVoucher.dateTo.ToString("MM/dd/yyyy");
            txtDiscountValue.Text = selectedVoucher.discountValue.ToString();
            txtMaxPrice.Text = selectedVoucher.maxPrice.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string code = txtCode.Text;
            if (!float.TryParse(txtDiscountValue.Text, out float Value))
            {
                MessageBox.Show("Giá trị giảm giá không hợp lệ. Vui lòng nhập một số hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method to prevent further execution
            }
            if (!float.TryParse(txtMaxPrice.Text, out float MaxPrice))
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

            bool result = voucherBUS.InsertVoucher(code, Value, DFD, DTD, MaxPrice);
            if (result)
            {
                DialogResult dialogResult = MessageBox.Show("Thêm thành công! Bạn muốn thêm tiếp không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    txtCode.Text = string.Empty;
                    txtDiscountValue.Text = string.Empty;
                    txtMaxPrice.Text = string.Empty;
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

        private void btnUpdateVoucher_Click(object sender, EventArgs e)
        {
            int id = selectedVoucher.Id;
            string code = txtCode.Text;
            if (!float.TryParse(txtDiscountValue.Text, out float Value))
            {
                MessageBox.Show("Giá trị giảm giá không hợp lệ. Vui lòng nhập một số hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method to prevent further execution
            }
            if (!float.TryParse(txtMaxPrice.Text, out float MaxPrice))
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

            bool result = voucherBUS.UpdateVoucher(id, code, Value, DFD, DTD, MaxPrice);
            if (result)
            {
                DialogResult dialogResult = MessageBox.Show("Cập Nhật thành công!", "Thông báo");
                DialogResult = DialogResult.OK; // Cập nhật DialogResult
                Close();
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
    }
}
