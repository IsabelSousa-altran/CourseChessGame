using System;

namespace BoardLayer
{
    class BoardException : Exception
    {
        public BoardException(string messageException) : base(messageException)
        {
        }
    }
}
