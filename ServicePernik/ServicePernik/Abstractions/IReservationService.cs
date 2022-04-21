using ServicePernik.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicePernik.Abstractions
{
    public interface IReservationService
    {
        bool CreateReservation(int hourId, string userId, string description);
        List<Reservation> GetReservations();
        
    }
}
