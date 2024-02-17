using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPMUD_Project.DTO
{
    internal class Voucher
    {
        public Voucher() { }
        public int Id { get; set; }
        public string code { get; set; }
        public float discountValue { get; set; }
        public DateTime? dateFrom { get; set; }
        public DateTime? dateTo { get; set; }
        public float maxPrice { get; set; }

        public Voucher(DataRow row)
        {
          
            this.discountValue = (float)Convert.ToDouble(row["Discount_Values"].ToString());

        }

    }
}
