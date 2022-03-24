using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicePernik.Entities
{
    public class StatusReservation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
