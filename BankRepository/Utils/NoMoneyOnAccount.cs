using System;
using System.Runtime.Serialization;

namespace BankRepository.Utils
{
    [Serializable]
    public class NoMoneyOnAccount : Exception
    {
        public NoMoneyOnAccount()
        {
        }

        public NoMoneyOnAccount(string message) : base(message)
        {
        }

        public NoMoneyOnAccount(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoMoneyOnAccount(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}