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
    internal class CategoryDAO
    {
        private SqlSystem sqlSystem;
        public CategoryDAO()
        {
            sqlSystem = new SqlSystem();
        }
        public DataTable GetCateList()
        {

            DataTable dt = new DataTable();
            string query = "Select * From Category";

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

        public Category getCategoryByID(int id)
        {
            Category category = null;
            string query = "Select * from Category where Category_ID = " + id;
            DataTable data = sqlSystem.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                category = new Category(item);
                return category;
            }
            return category;
        }

        public bool InsertCategory(string CategoryName)
        {
            try
            {
                string query = "INSERT INTO Category (Category_Name) Values (@CategoryName)";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@CategoryName", SqlDbType.NVarChar) { Value = CategoryName },
                };
                return sqlSystem.ExecuteInsertQuery(query, parameters);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }

        public bool UpdateCategory(int Category_ID, string Category_Name)
        {
            try
            {
                string query = "UPDATE Category SET " +
                               "Category_Name = @Category_Name " +
                               "WHERE Category_ID = @Category_ID";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@Category_Name", SqlDbType.NVarChar) { Value = Category_Name },
                    new SqlParameter("@Category_ID", SqlDbType.Int) {Value = Category_ID}
                };

                return sqlSystem.ExecuteUpdateQuery(query, parameters);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }

        public bool DeleteCategory(string Category_ID)
        {
            try
            {
                string query = "DELETE FROM Category WHERE Category_ID = @Category_ID";

                SqlParameter[] parameters =
                {
            new SqlParameter("@Category_ID", SqlDbType.NVarChar) { Value = Category_ID }
            };

                return sqlSystem.ExecuteDeleteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }
    }
}
