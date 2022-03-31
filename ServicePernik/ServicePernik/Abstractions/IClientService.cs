using ServicePernik.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicePernik.Abstractions
{
    public interface IClientService
    {
        List<Client> GetClients();

        Client GetClientByUserId(string userId);
        List<Reservation> GetReservationsByClient(int clientId);
        List<Repair> GetRepairsByClient(int clientId);

        public bool RemoveById(int clientId);

        string GetFullName(int clientId);

        public bool CreateClient(string firstName, string lastName, string address, string userId);
    }
}
