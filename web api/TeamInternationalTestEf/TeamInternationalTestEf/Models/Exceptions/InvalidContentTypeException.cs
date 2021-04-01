using System;

namespace TeamInternationalTestEf.Models.Exceptions
{
    [Serializable]
    public class InvalidContentTypeException : Exception
    {
        public InvalidContentTypeException()
        {

        }

        public InvalidContentTypeException(string message)
            : base(message)
        {

        }
    }
}
