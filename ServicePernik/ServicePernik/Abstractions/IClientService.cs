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

        public bool RemoveById(int clientId);

        string GetFullName(int clientId);

        bool CreateClient(string firstName, string lastName, string address, string userId);
    }
}
