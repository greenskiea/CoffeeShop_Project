using PTPMUD_Project.DAO;
using System;
using System.Collections.Generic;
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

        public float getDiscountValue()
        {
            return voucherDAO.getDiscountValue();
        }
    }
}
