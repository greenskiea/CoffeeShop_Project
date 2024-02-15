using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        
    }
}
