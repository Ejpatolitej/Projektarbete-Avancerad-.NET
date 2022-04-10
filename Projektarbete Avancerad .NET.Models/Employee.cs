using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Projektarbete_Avancerad_.NET.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public int ProjectID { get; set; }
        public Project Project { get; set; }

        public ICollection<TimeRepEmployee> TimeRepEmployees { get; set; }

    }
}
