using System.Collections.Generic;
using BankRepository.Enitities;

namespace BankRepository.Repositories
{
    public interface IClientsRepository
    {
        Client GetClientById(int id);
        List<Client> GetList();
    }
}