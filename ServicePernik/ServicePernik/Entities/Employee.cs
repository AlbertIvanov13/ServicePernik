using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicePernik.Entities
{
    public class Employee
    {
        public Employee()
        {
            this.Hours = new HashSet<Hour>();
            this.Reservations = new HashSet<Reservation>();          
        }
        [Key]

        public int Id { get; set; }

        
        [Display(Name = "First Name")]

        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]

        public string LastName { get; set; }

        [Required]
        [MaxLength(30)]

        public string JobTitle { get; set; }

        public string UserId { get; set; }

        public virtual ServiceUser User { get; set; }

        public virtual ICollection<Hour> Hours { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
