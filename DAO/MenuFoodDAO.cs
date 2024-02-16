using PTPMUD_Project.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPMUD_Project.DAO
{
    internal class MenuFoodDAO
    {
        private SqlSystem sqlSystem;
        public MenuFoodDAO()
        {
            sqlSystem = new SqlSystem();
        }

        public DataTable GetListMenuByTable(int id)
        {

            DataTable dt = new DataTable();
            string query = "Select f.Food_Name, bi.count, f.price, f.price*bi.count as totalPrice from Bill_Info as bi, Bill as b, Food as f where bi.Bill_ID = b.Bill_ID and bi.Food_ID = f.Food_ID and b.Status_Bill = 0 and b.Table_ID = " + id;
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
    }
}