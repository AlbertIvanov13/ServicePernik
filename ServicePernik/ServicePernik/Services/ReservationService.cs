using ServicePernik.Abstractions;
using ServicePernik.Data;
using ServicePernik.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicePernik.Services
{
    public class ReservationService : IReservationService
    {
        private readonly ApplicationDbContext _context;

        public ReservationService(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool CreateReservation(int hourId, string userId, string description)
        {
            var client = _context.Clients.FirstOrDefault(x => x.UserId == userId);
            var reservation = new Reservation
            {
                HourId = hourId,
                ClientId = client.Id,
                Description = description,
                DateReservation = DateTime.Now,
                StatusReservationId = 1
            };

            _context.Reservations.Add(reservation);
            _context.SaveChanges();
            var hour = _context.Hours.Find(hourId);
            hour.ReservationId = reservation.Id;
            _context.Update(hour);
            return _context.SaveChanges() != 0;

        }

        public List<Reservation> GetReservations()
        {
            List<Reservation> reservations = _context.Reservations
                 .ToList();
            return reservations;
        }
    }
}
