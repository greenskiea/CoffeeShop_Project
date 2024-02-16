using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPMUD_Project.DTO
{
    internal class MenuFood
    {
        public MenuFood(string foodName, int count, float price, float totalPrice) {
            this.foodName = foodName;
            this.count = count;
            this.price = price;
            this.totalPrice = totalPrice;
        }

        public MenuFood(DataRow row)
        {
            this.foodName = row["Food_Name"].ToString();
            this.count = (int)row["count"];
            this.price = (float)Convert.ToDouble(row["price"].ToString());
            this.totalPrice = (float)Convert.ToDouble(row["totalPrice"].ToString());
        }
        public string foodName {  get; set; }
        public int count { get; set; }
        public float price { get; set; }
        public float totalPrice { get; set; }
    }
}
