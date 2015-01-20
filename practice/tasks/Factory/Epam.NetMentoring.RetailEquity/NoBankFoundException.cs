using System;
namespace Epam.NetMentoring.RetailEquity
{
   public class NoBankFoundException:ApplicationException
    {
        public NoBankFoundException()  
        {
        }
        public NoBankFoundException(string message) : base(message)
        {
        }
        public NoBankFoundException(string message,Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
