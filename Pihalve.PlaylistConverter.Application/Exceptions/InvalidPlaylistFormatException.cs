using System;
using System.Runtime.Serialization;

namespace Pihalve.PlaylistConverter.Application.Exceptions
{
    [Serializable]
    public class InvalidPlaylistFormatException : Exception
    {
        public InvalidPlaylistFormatException()
        {
        }

        public InvalidPlaylistFormatException(string message) : base(message)
        {
        }

        public InvalidPlaylistFormatException(string message, Exception inner) : base(message, inner)
        {
        }

        protected InvalidPlaylistFormatException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
