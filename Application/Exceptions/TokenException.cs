using System;

namespace Application.Errors
{
    public class TokenException : Exception
    {
        public TokenException(string message) : base(message) { }
    }
}
