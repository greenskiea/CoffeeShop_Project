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
    internal class Food_PromotionBUS
    {
        private Food_PromotionDAO food_PromotionDAO;

        public Food_PromotionBUS()
        {
            food_PromotionDAO = new Food_PromotionDAO();
        }
        public List<DTO.Food_Promotion> GetAllFood_Promotion()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = food_PromotionDAO.getAllFood_Promotion();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            List<Food_Promotion> foodPromotionList = new List<Food_Promotion>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Food_Promotion foodPromotion = new Food_Promotion();
                    foodPromotion.FoodPromotion_ID = Convert.ToInt32(row["FoodPromotion_ID"]);
                    foodPromotion.Promotion_ID = Convert.ToInt32(row["Promotion_ID"]);
                    foodPromotion.Food_ID = Convert.ToInt32(row["Food_ID"]);


                    foodPromotionList.Add(foodPromotion);
                }
            }
            return foodPromotionList;
        }
    }
}
