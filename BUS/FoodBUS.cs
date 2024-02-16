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
    internal class FoodBUS
    {
        private FoodDAO foodDAO;
        public FoodBUS()
        {
            foodDAO = new FoodDAO();
        }
        public List<DTO.Food> getALLFood()
        {
            DataTable dt = new DataTable();

            try
            {
                dt = foodDAO.GetFoodList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            List<Food> list = new List<Food>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Food food = new Food();
                    food.foodID = Int32.Parse(dr["Food_ID"].ToString());
                    food.foodName = dr["Food_Name"].ToString();
                    food.price = Int32.Parse(dr["Price"].ToString());
                    food.categoryID = Int32.Parse(dr["Category_ID"].ToString());
                    food.quantity = Int32.Parse(dr["quantity"].ToString());
                    food.type = Int32.Parse(dr["Type"].ToString());
                    list.Add(food);

                }
            }
            return list;
        }

        public List<DTO.Food> GetFoodByCategoryID(int cateID)
        {
            List<Food> foddList = new List<Food>();

            DataTable dataTable = foodDAO.GetFoodByCategoryID(cateID);
            foreach (DataRow dr in dataTable.Rows)
            {
                Food f = new Food();
                f.foodID = Int32.Parse(dr["Food_ID"].ToString());
                f.foodName = dr["Food_Name"].ToString();
                f.price = Int32.Parse(dr["Price"].ToString());
                f.categoryID = Int32.Parse(dr["Category_ID"].ToString());
                f.quantity = Int32.Parse(dr["quantity"].ToString());
                f.type = Int32.Parse(dr["Type"].ToString());
                foddList.Add(f);
            }
            return foddList;
        }

        public bool InsertFood(string foodName, float price, int categoryID, int quantity, int type)
        {
            try
            {
                return foodDAO.InsertFood(foodName, price, categoryID, quantity, type);

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }

        public bool DeleteFood(int idFood)
        {
            return foodDAO.deleteFood(idFood);
        }
    }
}
 