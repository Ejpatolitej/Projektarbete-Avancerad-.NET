using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Projektarbete_Avancerad_.NET.Models
{
    public class TimeReport
    {
        [Key]
        public int TimeReportID { get; set; }
        public int HoursWorked { get; set; }
        public int Week { get; set; }

        public ICollection<TimeRepEmployee> TimeRepEmployees { get; set; }

    }
}
