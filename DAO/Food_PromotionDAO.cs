using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPMUD_Project.DAO
{
    internal class Food_PromotionDAO
    {
        private SqlSystem sqlSystem;
        public Food_PromotionDAO()
        {
            sqlSystem = new SqlSystem();
        }

        public DataTable getAllFood_Promotion()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * from Food_Promotion";
            try
            {
                dt = sqlSystem.ExecuteSelectAllQuery(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in getAllFood_Promotion: " + ex.Message);
            }
            return dt;
        }
    }
}
