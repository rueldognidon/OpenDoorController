using System;
using System.Collections.Generic;
using System.Text;

namespace OpenDoorController.Factories
{
    public class PageNotYetImplementedException : Exception
    {
        public PageNotYetImplementedException()
        {
        }

        public PageNotYetImplementedException(string message) : base(message)
        {
        }

        public PageNotYetImplementedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
