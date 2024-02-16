using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTPMUD_Project.DTO;
using System.Diagnostics;

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

        public bool InsertFood(string foodName, float price, int categoryID, int quantity, int type)
        {
            try
            {
                string query = string.Format("Insert into [Food] (Food_Name, Price, Category_ID, quantity, Type) values  (@foodName,  @price, @categoryID, @quantity, @type)");
                SqlParameter[] sqlParameters = new SqlParameter[5];

                sqlParameters[0] = new SqlParameter("@foodName", SqlDbType.NVarChar)
                {
                    Value = foodName
                };

                sqlParameters[1] = new SqlParameter("@price", SqlDbType.Float)
                {
                    Value = price
                };

                sqlParameters[2] = new SqlParameter("@categoryID", SqlDbType.Int)
                {
                    Value = categoryID
                };

                sqlParameters[3] = new SqlParameter("@quantity", SqlDbType.Int)
                {
                    Value = quantity
                };

                sqlParameters[4] = new SqlParameter("@type", SqlDbType.Int)
                {
                    Value = type
                };

                return sqlSystem.ExecuteInsertQuery(query, sqlParameters);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }

        }
    }
}
