using PTPMUD_Project.DAO;
using PTPMUD_Project.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PTPMUD_Project.BUS
{
    internal class BillBUS
    {
        private BillDAO billDAO;
        public BillBUS()
        {
            billDAO = new BillDAO();
        }

        public int GetUnCheckBillIDByTableID(int id)
        {
           return billDAO.getUnCheckBillIDByTableID(id);
        }

        //public void CheckOut(int id, int discount, float totalPrice)
        //{
        //    string query = "Update Bill set status = 1 , DateCheckOut = GETDATE(), " + "discount = " + discount + ", totalPrice = " + totalPrice + " where id = " + id;
        //    DataProvider.Instance.ExecuteNonQuery(query);
        //}
        public void InsertBill(int idTable)
        {
            billDAO.insertBill(idTable);
        }

        public DataTable GetListBillByDate(DateTime checkedDate)
        {
            return billDAO.getListBillByDate(checkedDate);
        }
        public int GetMaxIDBill()
        {
            return billDAO.getMaxIDBill();
        }

        public void CheckOut(int id, float totalPrice)
        {
            billDAO.checkOut(id, totalPrice);
        }



    }
}
