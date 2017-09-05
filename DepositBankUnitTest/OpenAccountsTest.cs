using NUnit.Framework;
using BankRepository.Enitities;
using BankRepository.Repositories;
using System.Collections.Generic;

namespace DepositBankUnitTest
{
    [TestFixture]
    public class OpenAccountsTest
    {       
        static AccountRepository _accountRepository;

        static Client _client;

        [SetUp]
        public static void SetUp()
        {           
            _accountRepository = new AccountRepository();           
            _client = ClientsRepository.CreateNewClient("test");           
        }

        [Test]
        public static void DepositAccountIsDeposit()
        {           
            Account account = _accountRepository.AddDepositAccount(_client);
            Assert.AreEqual(account.TypeAccount, TypeAccount.Deposit);          
        }

        [Test]
        public static void DepositAccountHasInRepository()
        {          
            Account account = _accountRepository.AddDepositAccount(_client);
            List<Account> accounts = _accountRepository.GetAllAccounts();
            Assert.That(accounts, Has.Member(account));
        }

        [Test]
        public static void CardAccountIsDeposit()
        {
            Account account = _accountRepository.AddCardAccount(_client);
            Assert.AreEqual(account.TypeAccount, TypeAccount.Card);
        }

        [Test]
        public static void CardAccountHasInRepository()
        {
            Account account = _accountRepository.AddCardAccount(_client);
            List<Account> accounts = _accountRepository.GetAllAccounts();
            Assert.That(accounts, Has.Member(account));
        }

        [Test]
        public static void InterestAccountIsDeposit()
        {
            Account account = _accountRepository.AddInterestAccount(_client);
            Assert.AreEqual(account.TypeAccount, TypeAccount.Interest);
        }

        [Test]
        public static void InterestAccountHasInRepository()
        {
            Account account = _accountRepository.AddInterestAccount(_client);
            List<Account> accounts = _accountRepository.GetAllAccounts();
            Assert.That(accounts, Has.Member(account));
        }


    }
}
