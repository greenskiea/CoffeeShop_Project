using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTPMUD_Project.DTO;

namespace PTPMUD_Project.DAO
{
    internal class FoodDAO
    {
        private SqlSystem sqlSystem;
        public FoodDAO()
        {
            sqlSystem = new SqlSystem();
        }
        public DataTable GetFoodList()
        {

            DataTable dt = new DataTable();
            string query = "Select * From Food";

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

        public DataTable GetFoodByCategoryID(int _id)
        {
            string query = "select * from [Food] where Category_ID = @ID_Category";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@ID_Category", SqlDbType.Int)
            {
                Value = _id
            };
            return sqlSystem.ExecuteSelectQuery(query, sqlParameters);

        }

        public bool InsertFood(Food food)
        {
            string query = string.Format("Insert into [Food] (Food_Name, Price, Category_ID, quantity, Type, Promotion_ID) values  (@foodName,  @price, @categoryID, @quantity, @type, @promotionID)");
            SqlParameter[] sqlParameters = new SqlParameter[6];

            sqlParameters[0] = new SqlParameter("@foodName", SqlDbType.NVarChar)
            {
                Value = (object)food.foodName ?? DBNull.Value
            };

            sqlParameters[1] = new SqlParameter("@price", SqlDbType.Float)
            {
                Value = (object)food.price ?? DBNull.Value
            };

            sqlParameters[2] = new SqlParameter("@categoryID", SqlDbType.Int)
            {
                Value = (object)food.categoryID ?? DBNull.Value
            };

            sqlParameters[3] = new SqlParameter("@quantity", SqlDbType.Int)
            {
                Value = (object)food.quantity ?? DBNull.Value
            };

            sqlParameters[4] = new SqlParameter("@type", SqlDbType.Int)
            {
                Value = (object)food.type ?? DBNull.Value
            };

            sqlParameters[5] = new SqlParameter("@promotionID", SqlDbType.Int)
            {
                Value = (object)food.promotionID ?? DBNull.Value
            };
            return sqlSystem.ExecuteInsertQuery(query, sqlParameters);
        }
    }
}
