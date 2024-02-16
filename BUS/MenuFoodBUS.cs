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
    internal class MenuFoodBUS
    {
        private MenuFoodDAO menuFoodDAO;
        public MenuFoodBUS()
        {
            menuFoodDAO = new MenuFoodDAO();
        }

        public List<MenuFood> GetListMenuByTable(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = menuFoodDAO.GetListMenuByTable(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            List<MenuFood> listMenu = new List<MenuFood>();

            foreach (DataRow item in dt.Rows)
            {
                MenuFood menu = new MenuFood(item);
                listMenu.Add(menu);
            }
            return listMenu;
        }
    }
}

