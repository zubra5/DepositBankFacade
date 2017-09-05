using NUnit.Framework;
using BankRepository.Enitities;
using BankRepository.Repositories;


namespace DepositBankUnitTest
{
    [TestFixture]
    public class TrasferMoneyTest
    {
        static AccountRepository _accountRepository;
        static Account _accountCard;
        static Account _accountDeposit;
        static Account _accountInterest;
        static float startBalanceCardAccount = 5000;
        static float transferSum = 2000;

        [SetUp]
        public static void SetUp()
        {
            _accountRepository = new AccountRepository();
            Client client = ClientsRepository.CreateNewClient("test");
            _accountCard = _accountRepository.AddCardAccount(client);
            _accountCard.Balance = startBalanceCardAccount;
            _accountDeposit = _accountRepository.AddDepositAccount(client);
            _accountInterest = _accountRepository.AddInterestAccount(client);
        }

        [Test]
        public static void FromCardToDeposit()
        {
            _accountRepository.TransferMoney(_accountCard, _accountDeposit, transferSum);
            Assert.AreEqual(_accountCard.Balance, startBalanceCardAccount - transferSum);
            Assert.AreEqual(_accountDeposit.Balance, transferSum);
        }

        [Test]
        public static void FromDepositToCard()
        {
            _accountDeposit.Balance = transferSum;
            _accountRepository.TransferMoney(_accountDeposit, _accountCard,  transferSum);
            Assert.AreEqual(_accountCard.Balance, startBalanceCardAccount + transferSum);
            Assert.AreEqual(_accountDeposit.Balance, 0);
        }


        [Test]
        public static void FromInterestToCard()
        {
            _accountInterest.Balance = transferSum;
            _accountRepository.TransferMoney(_accountInterest, _accountCard, transferSum);
            Assert.AreEqual(_accountCard.Balance, startBalanceCardAccount + transferSum);
            Assert.AreEqual(_accountInterest.Balance, 0);
        }

     
    }
}
