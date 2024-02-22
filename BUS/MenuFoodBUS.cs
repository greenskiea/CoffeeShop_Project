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
            return menuFoodDAO.GetListMenuByTable(id);
        }
    }
}

