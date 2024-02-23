using PTPMUD_Project.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PTPMUD_Project.DAO
{
    internal class MenuFoodDAO
    {
        private SqlSystem sqlSystem;
        public MenuFoodDAO()
        {
            sqlSystem = new SqlSystem();
        }

        public List<MenuFood> GetListMenuByTable(int id)
        {

            List<MenuFood> listMenu = new List<MenuFood>();
            string query = "Select bi.Food_ID ,f.Food_Name , bi.count , f.price , f.price*bi.count as totalPrice from Bill_Info as bi , Bill as b , Food as f where bi.Bill_ID = b.Bill_ID and bi.Food_ID = f.Food_ID and b.Status_Bill = 0 and b.Table_ID = " + id;
            
            DataTable data = sqlSystem.ExecuteQuery(query);
            
            foreach (DataRow item in data.Rows)
            {
                MenuFood menu = new MenuFood(item);
                listMenu.Add(menu);
            }
            return listMenu;



        }
    }
}