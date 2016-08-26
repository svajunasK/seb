using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ChamgeCurrency.Contracts
{
    [Serializable]
    internal class ValidationException : Exception
    {
        public IList<ValidationErrorInfo> errorMessages { get; private set; }

        public ValidationException()
        {
        }

        public ValidationException(string message) : base(message)
        {
        }

        public ValidationException(IList<ValidationErrorInfo> errorMessages)
        {
            this.errorMessages = errorMessages;
        }

        public ValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}