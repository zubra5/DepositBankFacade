using System.Collections.Generic;
using BankRepository.Enitities;

namespace BankRepository
{
    public interface IDepositRepository
    {
        Deposit CreateDeposit(Client client, Account accountDeposit);
        Deposit CreateDeposit(Client client, Account accountDeposit, int termMonth);
        List<Deposit> GetAllDeposits();
    }
}