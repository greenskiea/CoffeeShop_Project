using PTPMUD_Project.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            string query = string.Format("Insert Table_Food (Food_Table_Name, Status, note) Values (N'{0}', N'{1}', N'{2}')", tableName, status, note);
            int result = sqlSystem.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool updateTable(int idTable, string tableName, string status, string note)
        {
            string query = string.Format("Update Table_Food Set Food_Table_Name = N'{0}' , Status = N'{1}' , note = N'{2}' Where Food_Table_ID = {3}", tableName, status, note, idTable);
            int result = sqlSystem.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteTable(string idTable)
        {
            try
            {
                string query = "DELETE FROM Table_Food WHERE Food_Table_ID = @idTable";

                SqlParameter[] parameters =
                {
            new SqlParameter("@idTable", SqlDbType.NVarChar) { Value = idTable }
            };

                return sqlSystem.ExecuteDeleteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }

        public bool setNoteTableFood(string note,int id)
        {
            string query = string.Format("Update Table_Food Set note = N'{0}' where Food_Table_ID = {1} ", note,id);
            int result = sqlSystem.ExecuteNonQuery(query);  
            return result > 0;
        }
    }
}
