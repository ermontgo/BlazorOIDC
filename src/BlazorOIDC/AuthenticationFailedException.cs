using System;
using System.Runtime.Serialization;

namespace BlazorOIDC
{
    [Serializable]
    public class AuthenticationFailedException : Exception
    {
        public AuthenticationFailedException()
        {
        }

        public AuthenticationFailedException(string message) : base(message)
        {
        }

        public AuthenticationFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AuthenticationFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}