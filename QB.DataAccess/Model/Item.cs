using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QB.DAL
{
    public class Item
    {

        public string ALU { get; set; }
        public string DepartmentListId { get; set; }
        public string ListID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Rate { get; set; }
        public string AccountName { get; set; }
        public string ItemType { get; set; }
        public string QuickBooksID { get; set; }
        public double OnHandQuantity { get; set; }
        public string CustomField { get; set; }
    }
}
