using System;
using System.Collections.Generic;
using System.Text;

namespace Projektarbete_Avancerad_.NET.Models
{
    public class TimeRepEmployee
    {
        public int TimeRepEmployeeID { get; set; }


        public int TimeReportID { get; set; }
        public TimeReport TimeReport { get; set; }

        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }
    }
}
