using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QB.DAL
{
    public class SalesOrder
    {
        public string CustomerName { get; set; }
        public string ItemName { get; set; }
        public string Address { get; set; }
        public string CustomerRefListID { get; set; }
        public string ItemRefListID { get; set; }
        public double ItemOrdered { get; set; }
        public string Description { get; set; }
        public double ItemQuantity { get; set; }

    }
}
