namespace BankRepository.Enitities
{
    public class Account
    {
        public int Id { get; set; }
        public string Number { get; set; }

        public int ClientId { get; set; }

        public TypeAccount? TypeAccount { get; set; }

        public float Balance = 0;
    }

    public enum TypeAccount
    {
        Deposit,
        Card,
        Interest
    }

    
}