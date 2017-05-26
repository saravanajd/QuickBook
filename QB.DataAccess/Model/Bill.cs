using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QB.DAL
{
    public class Bill
    {
        public string VendorName { get; set; }
        public string Address { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public string Memo { get; set; }
        public string QuickBooksID { get; set; }
        public string CustomerListID { get; set; }
        public string ItemName { get; set; }
        public string ToDate { get; set; }
        public string FromDate { get; set; }
        public double ItemQuantity { get; set; }

    }
}
