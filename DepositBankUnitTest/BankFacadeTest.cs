using System;
using BankRepository;
using BankRepository.Enitities;
using BankRepository.Repositories;
using BankSystem;
using Moq;
using NUnit.Framework;

namespace DepositBankUnitTest
{
    public class BankFacadeTest
    {

        static AccountRepository _accountRepository;
        static Client _client;
        static Account _accountDeposit;
       
        private static Account _accCard;
        private static Mock<IDepositRepository> _depositMock;
        private static Mock<IAccountRepository> _accountMock;
        private static BankFacade _facade;
        private static int _termMonth;
        private static float _depositSum;

        [SetUp]
        public static void SetUp()
        {
            _client = ClientsRepository.CreateNewClient("test");
            _accountRepository = new AccountRepository();
            _accountDeposit = _accountRepository.AddDepositAccount(_client);
           
            _accCard = _accountRepository.AddCardAccount(_client);
            _accCard.Balance = 5000;
            _depositMock = new Mock<IDepositRepository>();
            _accountMock = new Mock<IAccountRepository>();
            _depositMock.Setup(x => x.CreateDeposit(It.IsAny<Client>(), It.IsAny<Account>(), It.IsAny<int>())).Returns(new Deposit(_client, _accountDeposit, DateTime.Today.AddMonths(_termMonth)));

            _accountMock.Setup(x => x.AddDepositAccount(It.IsAny<Client>())).Returns(_accountDeposit);
             _facade = new BankFacade
            {
                AccountRepository = _accountMock.Object,
                DepositRepository = _depositMock.Object
            };

            _termMonth = 12;
            _depositSum = 2000;
        }

        [Test]
        public static void DepositOpenAddDepositAccountTest()
        {
            //Act
            _facade.OpenDeposit(_client, _termMonth, _accCard, _depositSum);
            //Assert
            _accountMock.Verify(f => f.AddDepositAccount(_client), Times.Once);
        }

        [Test]
        public static void DepositOpenTransferMoneyTest()
        {
            //Act
            _facade.OpenDeposit(_client, _termMonth, _accCard, _depositSum);
            //Assert
            _accountMock.Verify(f => f.TransferMoney(_accCard, _accountDeposit, _depositSum), Times.Once);
        }

        [Test]
        public static void DepositOpenCreateDepositTest()
        {
            //Act
            _facade.OpenDeposit(_client, _termMonth, _accCard, _depositSum);
            //Assert
            _depositMock.Verify(f => f.CreateDeposit(_client, _accountDeposit, _termMonth), Times.Once);
        }
    }
}