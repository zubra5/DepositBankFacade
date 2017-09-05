using System.Collections.Generic;
using BankRepository.Enitities;

namespace BankRepository.Repositories
{
    public interface IAccountRepository
    {
        Account AddCardAccount(Client client);
        Account AddDepositAccount(Client client);
        Account AddInterestAccount(Client client);
        Account GetAccountByClient(Client client);
        List<Account> GetAllAccounts();
        void TransferMoney(Account accountFrom, Account accountTo, float sumTransaction);
    }
}