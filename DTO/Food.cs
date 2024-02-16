using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPMUD_Project.DTO
{
    internal class Food
    {
        public Food() { }

        public int foodID { get; set; }
        public string foodName { get; set; }
        public float price { get; set; }
        public int categoryID { get; set; }
        public int quantity { get; set; }
        public int type { get; set; }
    }
}
