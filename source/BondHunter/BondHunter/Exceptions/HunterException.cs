namespace BondHunter.Exceptions
{
    using System;

    public sealed class HunterException : Exception
    {
        public HunterException(string message) : base(message) { }

        public HunterException(string message, Exception inner)
            : base(message, inner) { }
    }
}