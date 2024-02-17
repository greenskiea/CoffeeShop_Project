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

        public Food getFoodByID(int id)
        {
            DataTable data = sqlSystem.ExecuteSelectAllQuery("Select * from Food where Food_ID = " + id);
            foreach (DataRow item in data.Rows)
            {
                return new Food(item);
            }
            return null;
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

        public int getQuantityFood(int id)
        {
            int quantity = -1; // Giá trị mặc định nếu không tìm thấy dữ liệu

            string query = "SELECT Quantity FROM Food WHERE Food_ID = " + id;
            DataTable dt = sqlSystem.ExecuteQuery(query);

            if (dt.Rows.Count > 0)
            {
                // Lấy giá trị quantity từ dòng đầu tiên của DataTable
                quantity = Convert.ToInt32(dt.Rows[0]["Quantity"]);
            }

            return quantity;
        }

        public bool updateFood(int idFood, string foodName, float price, int categoryID, int quantity, int type)
        {
            int result = sqlSystem.ExecuteNonQuery("exec USP_UpdateFood @idFood , @foodName , @price , @categoryID , @quantity , @type", new object[] { idFood, foodName, price, categoryID, quantity, type });
            return result > 0;
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

        public bool deleteFood(int idFood)
        {
            BillInfoDAO.Instance.DeleteBillInfoByFoodID(idFood);
            string query = string.Format("Delete Food where Food_ID = {0}", idFood);
            int result = sqlSystem.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
