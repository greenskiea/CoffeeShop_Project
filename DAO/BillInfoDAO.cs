using PTPMUD_Project.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPMUD_Project.DAO
{
    internal class BillInfoDAO
    {
        private SqlSystem sqlSystem;
        private static BillInfoDAO instance;
        public static BillInfoDAO Instance
        {
            get { if (instance == null) instance = new BillInfoDAO(); return BillInfoDAO.instance; }
            private set { BillInfoDAO.instance = value; }
        }
        public BillInfoDAO()
        {
            sqlSystem = new SqlSystem();
        }

        public void deleteBillInfoByFoodID(int id)
        {
            DataTable dt = new DataTable();
            string query = "Delete BillInfo where idFood = " + id;

            try
            {

                dt = sqlSystem.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public DataTable getListBillInfo(int id)
        {
            DataTable dt = new DataTable();
            string query = "Select * from BillInfo where idBill = " + id;

            try
            {

                dt = sqlSystem.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dt;
            
        }

        public DataTable insertBillInfo(int idBill, int idFood, int count)
        {
            DataTable dt = new DataTable();
            
            try
            {

                dt = sqlSystem.ExecuteQuery("exec USP_InsertBillInfo @idBill , @idFood , @count", new object[] { idBill, idFood, count });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dt;
        }

        public void DeleteBillInfoByFoodID(int id)
        {
            sqlSystem.ExecuteQuery("Delete Bill_Info where Food_ID = " + id);
        }
    }
}
