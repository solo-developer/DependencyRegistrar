using System;

namespace ServiceCollectionScanner.Exceptions
{
    public class NonNullValueException : Exception
    {
        public NonNullValueException(string message = "Value cannot be null") : base(message)
        {

        }
    }
}
