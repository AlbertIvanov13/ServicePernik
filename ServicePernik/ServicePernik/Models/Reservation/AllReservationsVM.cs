using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicePernik.Models.Reservation
{
    public class AllReservationsVM
    {
        public int Id { get; set; }
        public int HourId { get; set; }
        public string Hour { get; set; }
        public string Description { get; set; }
        public DateTime DateReservation { get; set; }
        public int StatusReservationId { get; set; }
        [Display(Name = "StatusReservation")]
        public string StatusReservationName { get; set; }
        public int ClientId { get; set; }
        public string ClientFullName { get; set; }

    }
}
