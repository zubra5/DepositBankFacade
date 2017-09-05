using System;
using NUnit.Framework;
using BankRepository.Enitities;
using BankRepository.Repositories;
using BankRepository;
using System.Collections.Generic;

namespace DepositBankUnitTest
{
    [TestFixture]
    public class WorkDepositTest
    {
        private static AccountRepository _accountRepository;
        private static Client _client;
        private static Account _accountDeposit;
        private static DepositRepository _depositRepository;

        [SetUp]
        public static void SetUp()
        {
            _client = ClientsRepository.CreateNewClient("test");
            _accountRepository = new AccountRepository();
            _accountDeposit = _accountRepository.AddDepositAccount(_client);
            _depositRepository = new DepositRepository();
        }

        [Test]
        public static void DepositIsInRepositoryTest()
        {
            Deposit deposit = _depositRepository.CreateDeposit(_client, _accountDeposit);
            List<Deposit> deposits = _depositRepository.GetAllDeposits();
            Assert.That(deposits, Has.Member(deposit));
        }

        [Test]
        public static void DepositHasStartDateTest()
        {
            Deposit deposit = _depositRepository.CreateDeposit(_client, _accountDeposit);
            Assert.AreEqual(deposit.StartDate, DateTime.Today);
        }

        [Test]
        public static void DepositHasEndDateTest()
        {
            int termMonth = 12;
            DateTime endDate = DateTime.Today.AddMonths(termMonth);
            Deposit deposit = _depositRepository.CreateDeposit(_client, _accountDeposit, termMonth);
            Assert.AreEqual(deposit.EndDate, endDate);
        }

        [Test]
        public static void DepositHasDefaultEndDateTest()
        {
            int termMonth = 36;
            DateTime endDate = DateTime.Today.AddMonths(termMonth);
            Deposit deposit = _depositRepository.CreateDeposit(_client, _accountDeposit);
            Assert.AreEqual(deposit.EndDate, endDate);
        }

        //открыть депозит - создать для заданного клиента 2 счета - депозит-счета и счета интереса
        //создание сущности депозита, где храняться ссылки на эти счета
        //перевод денег на счет депозита с карт-счета 
    }
}
