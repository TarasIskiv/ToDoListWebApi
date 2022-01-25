using System;

namespace Application.Exceptions
{
    public class NoteException : Exception
    {
        public NoteException(string message) : base(message) { }
    }
}
