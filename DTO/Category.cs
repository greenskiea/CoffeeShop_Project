using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PTPMUD_Project.DTO
{
    public class Category
    {
        public Category() { 

        }
        public int categoryID { get; set; }
        public string categoryName { get; set; }

        public Category(DataRow row)
        {
            this.categoryID = (int)row["Category_ID"];
            this.categoryName = row["Category_Name"].ToString();
        }
    }
}
