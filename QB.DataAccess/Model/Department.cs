using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QB.DataAccess
{
    public class Department
    {
        public string DepartmentName { get; set; }
        public string DepartmentCode { get; set; }
        public string DefaultMarginPercent { get; set; }
        public string DefaultMarkupPercent { get; set; }
        public string TaxCode { get; set; }
    }
}
