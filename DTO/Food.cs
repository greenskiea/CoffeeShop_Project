using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPMUD_Project.DTO
{
    public class Food
    {
        public Food() { }

        public int foodID { get; set; }
        public string foodName { get; set; }
        public float price { get; set; }
        public int categoryID { get; set; }
        public int quantity { get; set; }
        public int type { get; set; }

        public Food(DataRow row)
        {
            this.foodID = (int)row["Food_ID"];
            this.foodName = row["Food_Name"].ToString();
            this.price = (float)Convert.ToDouble(row["Price"].ToString());
            this.categoryID = (int)row["Category_ID"];
            this.quantity = (int)row["Quantity"];
            this.type = (int)row["type"];
        }
    }
}
