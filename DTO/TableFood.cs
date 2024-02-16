using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPMUD_Project.DTO
{
    internal class TableFood
    {
        public TableFood() { }
        public int idTable { get; set; }
        public string tableName { get; set; }
        public string status { get; set; }
        public string note { get; set; }

        public TableFood(DataRow row)
        {
            this.idTable = (int)row["Food_Table_ID"];
            this.tableName = row["Food_Table_Name"].ToString();
            this.status = row["Status"].ToString();
            this.note = row["note"].ToString();
        }
    }
}
