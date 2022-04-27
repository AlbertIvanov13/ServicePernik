using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicePernik.Models.Reservation
{
    public class EditReservationVM
    {
        public int Id { get; set; }
        public int HourId { get; set; }
        public string Description { get; set; }
        public DateTime DateReservation { get; set; }
        public int StatusReservationId { get; set; }
        public int ClientId { get; set; }
    }
}
