using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Projektarbete_Avancerad_.NET.Models
{
    public class Project
    {
        [Key]
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }

        //Many employees for each project
        public ICollection<Employee> Employees { get; set; }
    }
}
