using System;

namespace Hiring.Application.Exceptions
{
    public class InvalidOrderLineException : Exception
    {
        public InvalidOrderLineException(string message)
            : base(message)
        {
        }
    }
}
