using PTPMUD_Project.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PTPMUD_Project.DAO
{
    internal class BillDAO
    {
        private SqlSystem sqlSystem;
        public BillDAO()
        {
            sqlSystem = new SqlSystem();
        }

        public int getUnCheckBillIDByTableID(int id)
        {
            string query = "Select * from Bill where Table_ID = " + id + " and Status_Bill = 0";
            DataTable dt = sqlSystem.ExecuteQuery(query);
            if (dt.Rows.Count > 0)
            {
                Bill bill = new Bill(dt.Rows[0]);
                return bill.idBill;
            }
            return -1;
        }
        public void checkOut(int id, float totalPrice)
        {
            try
            {
                 sqlSystem.ExecuteNonQuery(string.Format("Update Bill Set Status_Bill = 1 , Date_Checked = GETDATE() , TotalPrice = {0} where Bill_ID = {1}", totalPrice, id));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void deleteBillByTableID(int id)
        {

            sqlSystem.ExecuteQuery("Delete Bill where Table_ID = " + id);
        }
        public void insertBill(int idTable)
        {

            try
            {

                sqlSystem.ExecuteNonQuery("exec USP_InsertBill @idTable", new object[] { idTable });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public DataTable getListBillByDate(DateTime checkedFrom, DateTime checkedTo)
        {
            DataTable dt = new DataTable();
            try
            {

                dt = sqlSystem.ExecuteQuery("exec USP_GetListBillByDate @checkedFrom , @checkedTo", new object[] { checkedFrom, checkedTo });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dt;
        }
        public int getMaxIDBill()
        {

            try
            {

                return (int)sqlSystem.ExecuteScala("Select MAX(id) from Bill");
            }
            catch
            {
                return 1;
            }

        }

        public DateTime? checkVoucherDate(int id)
        {
            string query = "Select b.Date_Checked from Bill as b, Voucher as v where b.Date_Checked >= v.DateFrom_Discount and b.Date_Checked <= v.DateTo_Discount and b.Voucher_ID = v.Voucher_ID and b.Bill_ID = " + id;
            DataTable dt = sqlSystem.ExecuteQuery(query);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                return (DateTime?)dr["Date_Checked"];
            }
            return null;
        }

        public float GetTotalBillChart(DateTime Date_Checked)
        {
            DateTime saleDateDay = Date_Checked.Date;
            float totalRevenue = 0;
            try
            {
                // Query to calculate total revenue for a specific date
                string query = "SELECT SUM(TotalPrice) AS TotalRevenue FROM Bill WHERE Date_Checked = @Date_Checked";

                // Parameter for the SQL query
                SqlParameter[] parameters =
                {
            new SqlParameter("@Date_Checked", saleDateDay)
                };

                // Execute the query
                DataTable dataTable = sqlSystem.ExecuteSelectQuery(query, parameters);

                if (dataTable.Rows.Count > 0 && dataTable.Rows[0]["TotalRevenue"] != DBNull.Value)
                {
                    // Get the TotalRevenue from the first row
                    totalRevenue = Convert.ToSingle(dataTable.Rows[0]["TotalRevenue"]);
                }

                // If no TotalRevenue is found, return 0 or throw an exception based on your requirements
                // You may choose to return -1 or throw an exception based on your requirements
                return totalRevenue;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting total revenue by date: {ex.Message}");
                // Handle exceptions here if needed
                // You may choose to return -1 or throw an exception based on your requirements
                return -1;
            }
        }
        public List<DTO.Bill> GetAllSalesByDate(DateTime startDate, DateTime endDate)
        {
            DateTime SD = startDate.Date;
            DateTime ED = endDate.Date;
            string query = "select [Bill_ID], [Date_Checked], [TotalPrice]\r\nfrom [dbo].[Bill] \r\nwhere [Date_Checked] between @StartDate and @EndDate and Status_Bill = 1";
            SqlParameter[] parameter =
                 {
            new SqlParameter("@StartDate", SD),
            new SqlParameter("@EndDate", ED),
        };
            DataTable dataTable = sqlSystem.ExecuteSelectQuery(query, parameter);
            List<DTO.Bill> sales = new List<DTO.Bill>();
            foreach (DataRow row in dataTable.Rows)
            {
                Bill sale = new Bill
                {
                    idBill = Convert.ToInt32(row["Bill_ID"]),
                    dateChecked = Convert.ToDateTime(row["Date_Checked"]),
                    totalPrice = Convert.ToSingle(row["TotalPrice"])
                };

                sales.Add(sale);

            }
            return sales;
        }

        public bool setDiscountValeByID(int idVoucher, int idBill)
        {
            string query = "Update Bill set Voucher_ID = " + idVoucher + " where Bill_ID = " + idBill;
            int result = sqlSystem.ExecuteNonQuery(query);
            return result > 0;
        }

    }
    }
