using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPMUD_Project.DTO
{
    internal class Bill
    {
        public Bill() { }

        public int idBill { get; set; }
        public DateTime? dateChecked { get; set; }
        public float totalPrice { get; set; }
        public int tableID { get; set; }
        public int statusBill { get; set; }
        public int voucherID { get; set; }

        public Bill (DataRow row)
        {
            this.idBill = (int)row["Bill_ID"];
            this.dateChecked = (DateTime?)row["Date_Checked"];
            this.totalPrice = (float)Convert.ToDouble(row["TotalPrice"].ToString());
            this.tableID = (int)row["Table_ID"];
            this.statusBill = (int)row["Status_Bill"];
            this.voucherID = (int)row["Voucher_ID"];
        }
    }
}
