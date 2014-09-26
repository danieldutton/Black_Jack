using System;

namespace BlackJack.Utility.Exceptions
{
    public class ResourceHandleException : Exception
    {
        public ResourceHandleException(string message, Exception innerException)
            :base(message, innerException)
        {            
        }
    }
}
