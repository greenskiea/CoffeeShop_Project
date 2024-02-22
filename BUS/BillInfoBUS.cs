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
    internal class BillInfoBUS
    {
        private BillInfoDAO billInfoDAO;
        public BillInfoBUS()
        {
            billInfoDAO = new BillInfoDAO();
        }

        public void DeleteBillInfoByFoodID(int id)
        {
            billInfoDAO.deleteBillInfoByFoodID(id);
        }
        public List<BillInfo> GetListBillInfo(int id)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = billInfoDAO.getListBillInfo(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            List<BillInfo> listBillInfo = new List<BillInfo>();
            foreach (DataRow item in dt.Rows)
            {
                BillInfo info = new BillInfo(item);
                listBillInfo.Add(info);
            }

            return listBillInfo;
        }

        public void InsertBillInfo(int idBill, int idFood, int count)
        {
            try
            {
              billInfoDAO.insertBillInfo(idBill, idFood, count);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
