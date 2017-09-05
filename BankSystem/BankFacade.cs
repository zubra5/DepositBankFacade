using BankRepository;
using BankRepository.Enitities;
using BankRepository.Repositories;

namespace BankSystem
{
    public class BankFacade
    {
        public BankFacade()
        {
            DepositRepository = new DepositRepository();
            AccountRepository = new AccountRepository();
        }

        public IDepositRepository DepositRepository { get; set; }
        public IAccountRepository AccountRepository { get; set; }


        public void OpenDeposit(Client client, int termMonth, Account accCard, float depositSum)
        {
            Account accDeposit = AccountRepository.AddDepositAccount(client);
            DepositRepository.CreateDeposit(client, accDeposit, termMonth);
            AccountRepository.TransferMoney(accCard, accDeposit, depositSum);
        }
    }
}