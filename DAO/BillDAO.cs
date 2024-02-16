using PTPMUD_Project.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PTPMUD_Project.DAO
{
    internal class BillDAO
    {
        private SqlSystem sqlSystem;
        public BillDAO()
        {
            sqlSystem = new SqlSystem();
        }

        public int getUnCheckBillIDByTableID(int id)
        {
            string query = "Select * from Bill where idTable = " + id + " and status = 0";
            DataTable dt = sqlSystem.ExecuteQuery(query);
            if (dt.Rows.Count > 0)
            {
                Bill bill = new Bill(dt.Rows[0]);
                return bill.idBill;
            }
            return -1;
        }
        //public void checkOut(int id, int discount, float totalPrice)
        //{
        //    DataTable dt = new DataTable();
        //    string query = "Update Bill set status = 1 , DateCheckOut = GETDATE(), " + "discount = " + discount + ", totalPrice = " + totalPrice + " where id = " + id;
        //    try
        //    {

        //        dt = sqlSystem.ExecuteSelectAllQuery(query);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    return dt;
        //}
        public void insertBill(int idTable)
        {
            DataTable dt = new DataTable();
            try
            {

                dt = sqlSystem.ExecuteSelectAllQuery("exec USP_InsertBill @idTable", new object[] { idTable});
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public DataTable getListBillByDate(DateTime checkedDate)
        {
            DataTable dt = new DataTable();
            try
            {

                dt = sqlSystem.ExecuteQuery("exec USP_GetListBillByDate @checked", new object[] { checkedDate });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dt;
        }
        public int getMaxIDBill()
        {
            
            try
            {

               return (int)sqlSystem.ExecuteScala("Select MAX(id) from Bill");
            }
            catch
            {
                return 1;
            }
            
        }
    }
}
