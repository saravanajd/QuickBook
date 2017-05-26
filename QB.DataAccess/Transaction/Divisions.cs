using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QB.DAL.Transaction
{
    public class Divisions
    {
        public int DivisionId { get; set; }
        public string EasternDivision { get; set; }
        public string WesternDivision { get; set; }
        public string CentralDivision { get; set; }
        public string OhioWV { get; set; }
        public string OperationsManagement { get; set; }
        public string Corporate { get; set; }
        public string Office { get; set; }
        public string Unclassified { get; set; }
    }
}
