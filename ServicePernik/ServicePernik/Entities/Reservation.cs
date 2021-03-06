using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicePernik.Entities
{
    public class Reservation
    {
       /* public Reservation()
        {
            this.Reports = new HashSet<Report>();
        }*/
        [Key]
        public int Id { get; set; }

        [Required]
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }

        public DateTime DateReservation { get; set; }

        [MinLength(10)]
        [MaxLength(50)]
        public string Description { get; set; }

        [Required]
        public int StatusReservationId { get; set; }
        public virtual StatusReservation StatusReservation { get; set; }

        //[Required]
       // public int EmployeeId { get; set; }
        //public virtual Employee Employee { get; set; }

       // public virtual ICollection<Report> Reports { get; set; }

        [Required]
        public virtual int HourId { get; set; }

        public virtual Hour Hour { get; set; }
    }
}
