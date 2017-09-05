using System.Collections.Generic;
using System.Linq;
using BankRepository.Enitities;

namespace BankRepository.Repositories
{
    public class ClientsRepository : IClientsRepository
    {
        private static List<Client> _clients;

        private static int _lastClientId;

        public ClientsRepository()
        {
            _lastClientId = 0;
            _clients = new List<Client>
            {
                new Client() { Id = _lastClientId++, Name = "Ivanov" },
                new Client() { Id = _lastClientId++, Name = "Petrov" },
                new Client() { Id = _lastClientId++, Name = "Jons" },
                new Client() { Id = _lastClientId++, Name = "Peters" }
            };
        }

        public List<Client> GetList()
        {
            return _clients;
        }

        public Client GetClientById(int id)
        {
            return _clients.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Factory Method
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Client CreateNewClient(string name)
        {
            if (_clients == null)
            {
                _clients = new List<Client>();
            }
            Client client = new Client
            {
                Id = _lastClientId++,
                Name = name
            };
            _clients.Add(client);
            return client;
        }
    }
}
