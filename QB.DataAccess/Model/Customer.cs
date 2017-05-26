using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QB.DAL
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CustomerName { get; set; }
        public string CompanyName { get; set; }
        public string BillAddressAdd1 { get; set; }
        public string BillAddressAdd2 { get; set; }
        public string BillAddressCity { get; set; }
        public string BillAddressState { get; set; }
        public string BillAddressPostalCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Memo { get; set; }
        public string Currency { get; set; }
        public string Email { get; set; }
        public string CCEmail { get; set; }
        public string ListId { get; set; }
        public string EditSequence { get; set; }
        public string CustomField { get; set; }
    }
}
