using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicePernik.Entities
{
    public class Report
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int RepairId { get; set; }
        public virtual Repair Repair { get; set; }

        public DateTime TimeOfRepair { get; set; }

       /* [Required]
        public int ReservationId { get; set; }
        public virtual Reservation Reservation { get; set; }*/
    }
}
