using System;

namespace API.Exceptions
{
    public class DtoInvalidException : Exception
    {
        public DtoInvalidException(string message) : base(message) { }
    }
}
