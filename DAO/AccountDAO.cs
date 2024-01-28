using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPMUD_Project.DAO
{
    internal class AccountDAO
    {
        private SqlSystem sqlSystem;

        public AccountDAO()
        {
            sqlSystem = new SqlSystem();
        }

        public DataTable getAccount()
        {
            DataTable dt = new DataTable();
            string query = "select * from Account";
            try
            {
                dt = sqlSystem.ExecuteSelectAllQuery(query);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            return dt;
        }

        public bool IsValidUser(string username,string password)
        {
            try
            {
                bool isValid = false;
                DataTable dt = new DataTable();
                string query = "SELECT * FROM Account WHERE Username = @Username AND Password = @Password";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Username", username),
                    new SqlParameter("@Password", password)
                };

                dt = sqlSystem.ExecuteSelectQuery(query, parameters);

                if (dt != null && dt.Rows.Count > 0)
                {
                    isValid = true;
                }

                return isValid;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }
    }
}
