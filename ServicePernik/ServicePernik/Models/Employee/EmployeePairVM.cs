using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicePernik.Models.Employee
{
    public class EmployeePairVM
    {
        [Key]
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
    }
}
