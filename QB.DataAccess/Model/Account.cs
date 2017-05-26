using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QB.DAL
{
    public class Account
    {
        public string Name { get; set; }
        public double OpenBalance { get; set; }
        public DateTime OpenBalanceDate { get; set; }
        public double AccountType { get; set; }
        public string Description { get; set; }
        public int TaxLineID { get; set; }

    }
}
