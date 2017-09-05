using System;
using System.Collections.Generic;
using System.Linq;
using BankRepository.Enitities;
using BankRepository.Utils;

namespace BankRepository.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private static List<Account> _accounts;

        private static int _lastAccountId;

        public AccountRepository()
        {
            _accounts = new List<Account>
            {
                new Account() { Id = _lastAccountId++, Number = "123456789", ClientId = 1 },
                new Account() { Id = _lastAccountId++, Number = "22222222", ClientId = 2 },
                new Account() { Id = _lastAccountId++, Number = "33333333", ClientId = 3 }
            };
        }

        public Account AddDepositAccount(Client client)
        {
            return AddAccount(client, TypeAccount.Deposit);
        }

        private Account AddAccount(Client client, TypeAccount type)
        {
            string accNumber = DateTime.Now.ToLongTimeString();
            int newId = GetNewId();
            Account acc = new Account() { Id = newId, Number = accNumber, TypeAccount = type, ClientId = client.Id };
            _accounts.Add(acc);
            return acc;
        }

        public void TransferMoney(Account accountFrom, Account accountTo, float sumTransaction)
        {
            if (accountFrom.Balance < sumTransaction)
            {
                throw new NoMoneyOnAccount($"No money on account number {accountFrom.Number}");
            }

            if (sumTransaction <=0)
            {
                throw new WrongSumTransaction("Sum of transaction should be more 0");
            }

            accountFrom.Balance -= sumTransaction;
            accountTo.Balance += sumTransaction;
        }

        public Account AddCardAccount(Client client)
        {
            return AddAccount(client, TypeAccount.Card);
        }

        public static void Add(Account acc)
        {
            _accounts.Add(acc);
        }

        public List<Account> GetAllAccounts()
        {
            return _accounts;
        }

        public Account GetAccountByClient(Client client)
        {
            return _accounts.FirstOrDefault(x => x.ClientId == client.Id);
        }

        public static int GetNewId()
        {
            return _lastAccountId++;
        }

        public static int GetLastId()
        {
            return _lastAccountId;
        }

        public Account AddInterestAccount(Client client)
        {
            return AddAccount(client, TypeAccount.Interest);
        }
    }
}
