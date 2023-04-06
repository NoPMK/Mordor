using System.Runtime.Serialization;

namespace Mordor_Backend.Exceptions
{
    [Serializable]
    public class OrkNotFoundException : Exception
    {
        public OrkNotFoundException()
        {
        }

        public OrkNotFoundException(string? message) : base(message)
        {
        }

        public OrkNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected OrkNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}