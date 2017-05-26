using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QB.DataAccess
{
    public class PurchaseOrder
    {
        public string PONumber { get; set; }
        public string ItemName { get; set; }
        public string Address { get; set; }
        public string VendorRefListID { get; set; }
        public string ItemRefListID { get; set; }
        public double ItemOrdered { get; set; }
        public string Description { get; set; }
        public double ItemQuantity { get; set; }
    }
}
