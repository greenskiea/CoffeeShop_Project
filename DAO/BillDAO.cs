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
            string query = "Select * from Bill where Table_ID = " + id + " and Status_Bill = 0";
            DataTable dt = sqlSystem.ExecuteQuery(query);
            if (dt.Rows.Count > 0)
            {
                Bill bill = new Bill(dt.Rows[0]);
                return bill.idBill;
            }
            return -1;
        }
        public void checkOut(int id, float totalPrice)
        {
            try
            {

                 sqlSystem.ExecuteNonQuery("exec USP_CheckOut @idBill , @totalPrice", new object[] {id,totalPrice});
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

       
        public void insertBill(int idTable)
        {
            
            try
            {

                sqlSystem.ExecuteNonQuery("exec USP_InsertBill @idTable", new object[] { idTable});
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public DataTable getListBillByDate(DateTime checkedFrom, DateTime checkedTo)
        {
            DataTable dt = new DataTable();
            try
            {

                dt = sqlSystem.ExecuteQuery("exec USP_GetListBillByDate @checkedFrom , @checkedTo", new object[] { checkedFrom, checkedTo });
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
