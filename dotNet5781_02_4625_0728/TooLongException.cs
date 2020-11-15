using System;
using System.Runtime.Serialization;

namespace dotNet5781_02_4625_0728
{
    [Serializable]
    internal class TooLongException : Exception
    {
        public override string Message => "The id have to be a positive number of 6 digits maximum";

        public TooLongException()
        {
        }

        public TooLongException(string message) : base(message)
        {
        }

        //public TooLongException(string message, Exception innerException) : base(message, innerException)
        //{
        //}

        //protected TooLongException(SerializationInfo info, StreamingContext context) : base(info, context)
        //{
        //}
    }
}