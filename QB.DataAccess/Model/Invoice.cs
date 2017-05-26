using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QB.DAL
{
    public class Invoice
    {
        public string InvoiceNumber { get; set; }
        public string Item { get; set; }
        public double Quantity { get; set; }
        public string ItemDescription { get; set; }
        public string Note { get; set; }
        public string UpcCode { get; set; }
        public string UnitPrice { get; set; }
        public string TotalPrice { get; set; }
        public string PerUnit { get; set; }
        //
        public string CustomerName { get; set; }
        public string BillAddressAdd1 { get; set; }
        public string BillAddressAdd2 { get; set; }
        public string BillAddressCity { get; set; }
        public string BillAddressState { get; set; }
        public string BillAddressPostalCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Memo { get; set; }
        public string ListId { get; set; }
        public string EditSequence { get; set; }

    }
}
