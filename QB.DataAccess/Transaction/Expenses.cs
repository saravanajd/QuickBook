using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QB.DAL.Transaction
{
    public class Expenses
    {
        public int ExpencesId { get; set; }
        public string Expense { get; set; }
        public string OperatingExpense { get; set; }
        public string ComputerExpense { get; set; }
        public string Insurense { get; set; }
        //6251 · Miscellaneous Operating Expense
        public string BadDebt { get; set; }
        //Postage And Delivary
        public string Shipping { get; set; }
        public string MiscPayOuts { get; set; }
        public string CustomreCare { get; set; }
        public string EmployeeExpense { get; set; }
        public string Repairs { get; set; }
        public string Fees { get; set; }
        public string ProfessionlaFees { get; set; }
        public string AutoMobileExpense { get; set; }
        //utilities
        public string Telephone { get; set; }
        public string VolvolineFranchise { get; set; }
        //6003 · Partner Draw And Payroll
        //7750 · Payroll Expenses
        public string PayrollTaxes { get; set; }
        public string QualifiesProfitSharingPlan { get; set; }
        public string PartnerDraw { get; set; }
        public string PartneDrawAndPayroll { get; set; }
        public string DepreciationAndAmortization { get; set; }
    }
}
