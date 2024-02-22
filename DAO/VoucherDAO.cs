using PTPMUD_Project.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PTPMUD_Project.DAO
{
    internal class VoucherDAO
    {
        private SqlSystem sqlSystem;
        public VoucherDAO()
        {
            sqlSystem = new SqlSystem();
        }

        public float getDiscountValue(int id)
        {
            DataTable data = sqlSystem.ExecuteQuery("SELECT v.Discount_Values FROM Voucher as v, Bill as b where b.Date_Checked >= v.DateFrom_Discount and b.Date_Checked <= v.DateTo_Discount and b.Voucher_ID = v.Voucher_ID and b.Bill_ID = " + id);

            if (data.Rows.Count > 0)
            {
                foreach (DataRow dr in data.Rows)
                {
                    Voucher voucher = new Voucher();
                    voucher.discountValue = (float)Convert.ToDouble(dr["Discount_Values"].ToString());
                    return voucher.discountValue;
                }
            }
            return -1;
        }

        public DataTable GetVoucherList()
        {

            DataTable dt = new DataTable();
            string query = "Select * From Voucher";

            try
            {

                dt = sqlSystem.ExecuteSelectAllQuery(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dt;
        }

        public float getMaxPrice(int id)
        {
            DataTable data = sqlSystem.ExecuteQuery("Select v.MaxPrice From Voucher as v , Bill as b where v.Voucher_ID = b.Voucher_ID and b.Bill_ID = "+ id);

            if (data.Rows.Count > 0)
            {
                foreach (DataRow dr in data.Rows)
                {
                    Voucher voucher = new Voucher();
                    voucher.maxPrice = (float)Convert.ToDouble(dr["MaxPrice"].ToString());
                    //Voucher voucher = new Voucher(data.Rows[0]);
                    return voucher.maxPrice;
                }
            }
            return -1;
        }
        public DateTime? getVoucherDateFrom(int idVoucher)
        {
            string query = "Select DateFrom_Discount from Voucher where Voucher_ID = " + idVoucher;
            DataTable dt = sqlSystem.ExecuteQuery(query);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Voucher voucher = new Voucher();
                    voucher.dateFrom = (DateTime?)dr["DateFrom_Discount"];
                    return voucher.dateFrom;
                }
            }
            return null;
        }

        public DateTime? getVoucherDateTo(int idVoucher)
        {
            string query = "Select DateTo_Discount from Voucher where Voucher_ID = " + idVoucher;
            DataTable dt = sqlSystem.ExecuteQuery(query);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Voucher voucher = new Voucher();
                    voucher.dateTo = (DateTime?)dr["DateTo_Discount"];
                    return voucher.dateTo;
                }
            }
            return null;
        }

        public bool deleteVoucher(string idVoucher)
        {
            try
            {
                string query = "DELETE FROM Voucher WHERE Voucher_ID = @idVoucher";

                SqlParameter[] parameters =
                {
            new SqlParameter("@idVoucher", SqlDbType.NVarChar) { Value = idVoucher }
            };

                return sqlSystem.ExecuteDeleteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }


    }
}
