using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Management;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace PTPMUD_Project.DAO
{
    internal class PromotionDAO
    {
        private SqlSystem sqlSystem;

        public PromotionDAO()
        {
            sqlSystem = new SqlSystem();
        }
        public DataTable getAllPromotion()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * from Promotion";
            try
            {
                dt = sqlSystem.ExecuteSelectAllQuery(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in getAllPromotion: " + ex.Message);
            }
            return dt;
        }

        public bool InsertPromotion(string Promotion_Name, float Discount_Value, DateTime DateFrom_Discount, DateTime DateTo_Discount)
        {
            try
            {
                string query = "INSERT INTO Promotion (Promotion_Name, Discount_Value, DateFrom_Discount, DateTo_Discount) Values (@Promotion_Name, @Discount_Value, @DateFrom_Discount, @DateTo_Discount)";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Promotion_Name", SqlDbType.NVarChar) { Value = Promotion_Name },
                    new SqlParameter("@Discount_Value", SqlDbType.Float) { Value = Discount_Value },
                    new SqlParameter("@DateFrom_Discount", SqlDbType.Date) { Value = DateFrom_Discount },
                    new SqlParameter("@DateTo_Discount", SqlDbType.Date) { Value = DateTo_Discount },
                };
                return sqlSystem.ExecuteInsertQuery(query, parameters);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }

        public bool UpdatePromotion(int Promotion_ID, string Promotion_Name, float Discount_Value, DateTime DateFrom_Discount, DateTime DateTo_Discount)
        {
            try
            {
                string query = "UPDATE Promotion SET " +
                               "Promotion_Name = @Promotion_Name ," +
                               "Discount_Value = @Discount_Value ," +
                               "DateFrom_Discount = @DateFrom_Discount ," +
                               "DateTo_Discount = @DateTo_Discount " +
                               "WHERE Promotion_ID = @Promotion_ID";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@Promotion_Name", SqlDbType.NVarChar) { Value = Promotion_Name },
                    new SqlParameter("@Discount_Value", SqlDbType.Float) {Value = Discount_Value},
                    new SqlParameter("@DateFrom_Discount", SqlDbType.Date) { Value = DateFrom_Discount },
                    new SqlParameter("@DateTo_Discount", SqlDbType.Date) { Value = DateTo_Discount },
                    new SqlParameter("@Promotion_ID", SqlDbType.Int) { Value = Promotion_ID },
                };

                return sqlSystem.ExecuteUpdateQuery(query, parameters);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }

        public bool DeletePromotion(string Promotion_ID)
        {
            try
            {
                string query = "DELETE FROM Promotion WHERE Promotion_ID = @Promotion_ID";

                SqlParameter[] parameters =
                {
            new SqlParameter("@Promotion_ID", SqlDbType.NVarChar) { Value = Promotion_ID }
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
