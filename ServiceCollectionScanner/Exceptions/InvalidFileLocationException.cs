using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceCollectionScanner.Exceptions
{
    public class InvalidFileLocationException : Exception
    {
        public InvalidFileLocationException(string message = "File location is invalid.") : base(message)
        {

        }
    }
}
