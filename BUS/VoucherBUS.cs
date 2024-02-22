using PTPMUD_Project.DAO;
using PTPMUD_Project.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPMUD_Project.BUS
{
    internal class VoucherBUS
    {
        public VoucherDAO voucherDAO;

        public VoucherBUS()
        {
            voucherDAO = new VoucherDAO();
        }

        public float getDiscountValue(int id)
        {
            return voucherDAO.getDiscountValue(id);
        }

        public List<DTO.Voucher> getALLVoucher()
        {
            DataTable dt = new DataTable();

            try
            {
                dt = voucherDAO.GetVoucherList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            List<Voucher> list = new List<Voucher>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Voucher voucher = new Voucher();
                    voucher.Id = Int32.Parse(dr["Voucher_ID"].ToString());
                    voucher.code = dr["Code"].ToString();
                    voucher.discountValue = (float)Convert.ToDouble(dr["Discount_Values"].ToString());
                    voucher.dateFrom = (DateTime)dr["DateFrom_Discount"];
                    voucher.dateTo = (DateTime)dr["DateTo_Discount"];
                    voucher.maxPrice = (float)Convert.ToDouble(dr["MaxPrice"].ToString());
                    
                    list.Add(voucher);

                }
            }
            return list;
        }

        public float getMaxPrice(int id)
        {
            return voucherDAO.getMaxPrice(id);
        }    
    }
}
