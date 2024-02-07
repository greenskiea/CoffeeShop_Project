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

        public DataTable GetName(string username)
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM Account WHERE Username = @Username";

            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Username", username)
                };

                dt = sqlSystem.ExecuteSelectQuery(query, parameters);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            return dt;
        }

        public DataTable getAllStaff()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * from Account Where Type = 'Employee'";
            try
            {
                dt = sqlSystem.ExecuteSelectAllQuery(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in getAllStaff: " + ex.Message);
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

        public bool InsertAccount(string Username, string Password, string Email, string Type, string Name,string Personal_ID, string Address, string Phone, string DOB, int Gender)
        {
            try { 
                string query = "INSERT INTO Account (Email, Personal_ID, Username, Password, Type, Name, Address, Phone, Gender, DOB) Values (@Email, @Personal_ID, @Username, @Password, @Type, @Name, @Address, @Phone, @Gender, @DOB)";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Email", SqlDbType.NVarChar) { Value = Email },
                    new SqlParameter("@Personal_ID", SqlDbType.NVarChar) { Value = Personal_ID },
                    new SqlParameter("@Username", SqlDbType.NVarChar) { Value = Username },
                    new SqlParameter("@Password", SqlDbType.NVarChar) { Value = Password },
                    new SqlParameter("@Type", SqlDbType.NVarChar) { Value = Type },
                    new SqlParameter("@Name", SqlDbType.NVarChar) { Value = Name },
                    new SqlParameter("@Address", SqlDbType.NVarChar) { Value = Address },
                    new SqlParameter("@Phone", SqlDbType.NVarChar) { Value = Phone },
                    new SqlParameter("@Gender", SqlDbType.Int) { Value = Gender },
                    new SqlParameter("@DOB", SqlDbType.NVarChar) { Value = DOB }
                };
                return sqlSystem.ExecuteInsertQuery(query, parameters);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }

        public bool DeleteAccount(string User_ID)
        {
            try
            {
                string query = "DELETE FROM Account WHERE User_ID = @User_ID";

                SqlParameter[] parameters =
                {
            new SqlParameter("@User_ID", SqlDbType.NVarChar) { Value = User_ID }
            };

                return sqlSystem.ExecuteDeleteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }

        public bool Update(int Id, string Username, string Password, string Email, string Type, string Name, string Personal_ID, string Address, string Phone, string DOB, int Gender)
        {
            try
            {
                string query = "UPDATE Account SET " +
                               "Username = @Username, " +
                               "Password = @Password, " +
                               "Email = @Email, " +
                               "Type = @Type, " +
                               "Name = @Name, " +
                               "Personal_ID = @Personal_ID, " +
                               "Address = @Address, " +
                               "Phone = @Phone, " +
                               "DOB = @DOB, " +
                               "Gender = @Gender " +
                               "WHERE User_ID = @User_ID";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@Username", SqlDbType.NVarChar) { Value = Username },
                    new SqlParameter("@Password", SqlDbType.NVarChar) { Value = Password },
                    new SqlParameter("@Email", SqlDbType.NVarChar) { Value = Email },
                    new SqlParameter("@Type", SqlDbType.NVarChar) { Value = Type },
                    new SqlParameter("@Name", SqlDbType.NVarChar) { Value = Name },
                    new SqlParameter("@Personal_ID", SqlDbType.NVarChar) { Value = Personal_ID },
                    new SqlParameter("@Address", SqlDbType.NVarChar) { Value = Address },
                    new SqlParameter("@Phone", SqlDbType.NVarChar) { Value = Phone },
                    new SqlParameter("@DOB", SqlDbType.NVarChar) { Value = DOB },
                    new SqlParameter("@Gender", SqlDbType.Int) { Value = Gender },
                    new SqlParameter("User_ID", SqlDbType.Int) {Value = Id}
                };

                return sqlSystem.ExecuteUpdateQuery(query, parameters);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }
    }
}
