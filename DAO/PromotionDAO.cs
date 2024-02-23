using PTPMUD_Project.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Management;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public float getPriceDiscountByIDFood(int id)
        {
            DataTable dt = sqlSystem.ExecuteQuery("exec USP_FoodPromotion @idFood", new object[] {id});
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Promotion promotion = new Promotion();
                    promotion.DiscountValue = (float)Convert.ToDouble(dr["Discount_Value"].ToString());
                    return promotion.DiscountValue;
                }
            }
            return -1;
        }

        public DateTime? getDateFrom(int id)
        {
            string query = "SELECT DateFrom_Discount FROM Food_Promotion fb JOIN Promotion p ON fb.Promotion_ID = p.Promotion_ID JOIN Food f ON fb.Food_ID = f.Food_ID where f.Food_ID = " + id;
            DataTable dt = sqlSystem.ExecuteQuery(query);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Promotion promo = new Promotion();
                    promo.DateFrom_Discount = (DateTime)dr["DateFrom_Discount"];
                    return promo.DateFrom_Discount;
                }
            }
            return null;
        }

        public DateTime? getDateTo(int id)
        {
            string query = "SELECT DateTo_Discount FROM Food_Promotion fb JOIN Promotion p ON fb.Promotion_ID = p.Promotion_ID JOIN Food f ON fb.Food_ID = f.Food_ID where f.Food_ID = " + id;
            DataTable dt = sqlSystem.ExecuteQuery(query);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Promotion promo = new Promotion();
                    promo.DateFrom_Discount = (DateTime)dr["DateTo_Discount"];
                    return promo.DateFrom_Discount;
                }
            }
            return null;
        }
    }
}
