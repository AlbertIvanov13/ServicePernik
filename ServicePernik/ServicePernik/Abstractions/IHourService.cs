using ServicePernik.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicePernik.Abstractions
{
    public interface IHourService
    {
        bool CreateHour(DateTime freeHour, int employeeId);
        bool UpdateHour(int hourId, DateTime freeHour, int employeeId);
        List<Hour> GetHours();
        List<Hour> GetFreeHours();
        Hour GetHourById(int hourId);
        List<Reservation> GetReservationsByHour(int hourId);
        public bool RemoveById(int hourId);
    }
}
