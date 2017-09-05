using System;
using System.Collections.Generic;
using BankRepository.Enitities;

namespace BankRepository
{
    public class DepositRepository : IDepositRepository
    {
        private List<Deposit> _deposits;

        private int defaultTermMonths = 36;
        public DepositRepository()
        {
            _deposits = new List<Deposit>();
        }

        public Deposit CreateDeposit(Client client, Account accountDeposit)
        {
            return CreateDeposit(client, accountDeposit, defaultTermMonths);
        }

        public Deposit CreateDeposit(Client client, Account accountDeposit, int termMonth)
        {
            DateTime endDate = DateTime.Today.AddMonths(termMonth);
            Deposit deposit = new Deposit(client, accountDeposit, endDate);
            _deposits.Add(deposit);
            return deposit;
        }

        public List<Deposit> GetAllDeposits()
        {
            return _deposits;
        }

       
    }
}