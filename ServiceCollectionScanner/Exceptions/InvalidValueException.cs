using System;

namespace ServiceCollectionScanner.Exceptions
{
    public class InvalidValueException : Exception
    {
        public InvalidValueException(string message = "Provided value is not valid.") : base(message)
        {

        }
    }
}
