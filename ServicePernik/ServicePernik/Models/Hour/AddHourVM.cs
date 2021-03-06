using ServicePernik.Models.Employee;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicePernik.Models.Hour
{
    public class AddHourVM
    {
        public AddHourVM()
        {
            Employees = new List<EmployeePairVM>();
        }

        [Key]
        public int Id { get; set; }
        public DateTime FreeHour { get; set; }

        [Required]
        [DisplayName("Employee")]
        public int EmployeeId { get; set; }

        public virtual List<EmployeePairVM> Employees { get; set; }
    }
}
