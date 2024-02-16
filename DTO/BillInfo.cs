using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPMUD_Project.DTO
{
    internal class BillInfo
    {
        public BillInfo() { }
        public int id { get; set; }
        public int idBill { get; set; }
        public int idFood { get; set; }
        public int count { get; set; }

        public BillInfo(DataRow row)
        {
            this.id = (int)row["Bill_Info_ID"];
            this.idBill = (int)row["Bill_ID"];
            this.idFood = (int)row["Food_ID"];
            this.count = (int)row["Count"];
        }
    }
}
