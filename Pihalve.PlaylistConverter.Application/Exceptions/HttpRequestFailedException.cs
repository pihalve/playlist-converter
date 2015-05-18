using System;
using System.Runtime.Serialization;

namespace Pihalve.PlaylistConverter.Application.Exceptions
{
    [Serializable]
    public class HttpRequestFailedException : Exception
    {
        public HttpRequestFailedException()
        {
        }

        public HttpRequestFailedException(string message) : base(message)
        {
        }

        public HttpRequestFailedException(string message, Exception inner) : base(message, inner)
        {
        }

        protected HttpRequestFailedException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
