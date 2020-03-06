using System;
using System.Runtime.Serialization;

namespace FastGraph.IO
{
    public class FileInputException : Exception
    {
        public FileInputException(string message) : base(message)
        {
        }

        public FileInputException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FileInputException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
