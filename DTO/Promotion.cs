using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPMUD_Project.DTO
{
    public class Promotion
    {
        public int PromotionID { get; set; }
        public string PromotionName { get; set; }
        public float DiscountValue { get; set; }
        public DateTime DateFrom_Discount { get; set; }
        public DateTime DateTo_Discount { get; set; }

        public Promotion() { }

        public Promotion(int promotionID, string promotionName, float discountValue, DateTime dateFrom_Discount, DateTime dateTo_Discount)
        {
            PromotionID = promotionID;
            PromotionName = promotionName;
            DiscountValue = discountValue;
            DateFrom_Discount = dateFrom_Discount;
            DateTo_Discount = dateTo_Discount;
        }
    }
}
