using PTPMUD_Project.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPMUD_Project.DAO
{
    internal class VoucherDAO
    {
        private SqlSystem sqlSystem;
        public VoucherDAO()
        {
            sqlSystem = new SqlSystem();
        }

        public float getDiscountValue()
        {
            DataTable data = sqlSystem.ExecuteQuery("SELECT TOP 1 v.Discount_Values FROM Voucher as v, Bill as b where v.Voucher_ID = b.Voucher_ID ORDER BY b.Date_Checked DESC ");

            if (data.Rows.Count > 0)
            {
                Voucher bill = new Voucher(data.Rows[0]);
                return bill.discountValue;
            }
            return -1;
        }

    }
}
