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
    }
}
