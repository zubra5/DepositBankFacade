using System;
using System.Runtime.Serialization;

namespace BankRepository.Utils
{
    [Serializable]
    public class WrongSumTransaction : Exception
    {
        public WrongSumTransaction()
        {
        }

        public WrongSumTransaction(string message) : base(message)
        {
        }

        public WrongSumTransaction(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected WrongSumTransaction(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}