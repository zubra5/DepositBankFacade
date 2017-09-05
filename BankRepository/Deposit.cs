using BankRepository.Enitities;
using System;

namespace BankRepository
{
    public class Deposit
    {
        public Client Client { get; set; }
        public Account AccountDeposit { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Deposit(Client client, Account accountDeposit, DateTime endDate)
        {
            Client = client;
            AccountDeposit = accountDeposit;
            StartDate = DateTime.Today;
            EndDate = endDate;
        }
    }
}