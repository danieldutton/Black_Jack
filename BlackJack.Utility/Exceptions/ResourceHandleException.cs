using System;

namespace BlackJack.Utility.Exceptions
{
    public class ResourceHandleException : Exception
    {
        public ResourceHandleException()
        {
        }

        public ResourceHandleException(string message)
            :base(message)
        {           
        }

        public ResourceHandleException(string message, Exception innerException)
            :base(message, innerException)
        {            
        }
    }
}
