using System;
using System.Runtime.Serialization;

namespace LivePhish.Wrapper.Exceptions
{
    /// <summary>
    /// Base class for all LivePhish.Wrapper eceptions
    /// </summary>
    public abstract class LivePhishException : Exception
    {
        #region Constructors

        protected LivePhishException()
        {
            
        }

        protected LivePhishException(string message) : base(message)
        {
            
        }

        protected LivePhishException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            
        }

        protected LivePhishException(string message, Exception innerException) : base(message, innerException)
        {
            
        }

        #endregion
    }
}
