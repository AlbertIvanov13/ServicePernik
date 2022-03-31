using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicePernik.Models.Reservation
{
    public class AddReservationVM
    {
        [Key]
        public int Id { get; set; }
        public int HourId { get; set; }
        public string Description { get; set; }
    }
}
