using PTPMUD_Project.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPMUD_Project.DAO
{
    internal class TableFoodDAO
    {
        private SqlSystem sqlSystem;
        public TableFoodDAO()
        {
            sqlSystem = new SqlSystem();
        }

        public DataTable GetTableList()
        {

            DataTable dt = new DataTable();
            string query = "Select * From Table_Food";

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

        public void switchTable(int id1, int id2)
        {

            try
            {

                sqlSystem.ExecuteQuery("USP_SwitchTabel @idTable1 , @idTable2", new object[] { id1, id2 });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public string GetStatusByID(int id)
        {
            string status = null;
            string query = "SELECT Status FROM Table_Food WHERE Food_Table_ID = " + id;
            DataTable data = sqlSystem.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                status = row["Status"].ToString();
                return status;
            }
            return status;
        }

        public bool inserTable(string tableName, string status, string note)
        {
            string query = string.Format("Insert Table_Food (Food_Table_Name, Status, note) Values (N'{0}',N'{1}', N'{2}')", tableName, status, note);
            int result = sqlSystem.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
