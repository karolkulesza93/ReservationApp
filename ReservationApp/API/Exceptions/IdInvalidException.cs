using System;

namespace API.Exceptions
{
    public class IdInvalidException : Exception
    {
        public IdInvalidException(string message) : base(message) { }
    }
}
