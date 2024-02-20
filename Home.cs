using PTPMUD_Project.BUS;
using PTPMUD_Project.DAO;
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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            billBus = new BillBUS();
            load();
        }
        BillBUS billBus;
        #region Methods
        void load()
        {
            loadDateTimePickerBill();
            loadListBillbyDate(dtpkFromDate.Value, dtpkToDate.Value);
        }
        void loadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpkFromDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpkToDate.Value = dtpkFromDate.Value.AddMonths(1).AddDays(-1);
        }

        void loadListBillbyDate(DateTime checkedFrom, DateTime checkedTo)
        {
            dtgvBill.DataSource = billBus.GetListBillByDate(checkedFrom, checkedTo);
        }
        #endregion

        #region Events
        private void btnViewBill_Click(object sender, EventArgs e)
        {
            loadListBillbyDate(dtpkFromDate.Value, dtpkToDate.Value);
        }
        #endregion


    }
}
