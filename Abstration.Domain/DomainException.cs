using System;
using System.Text;

namespace eGP.Abstration.Domain
{
    /// <summary>
    /// Common Exception for domail level exceptions.
    /// </summary>
   public class DomainException: Exception
    {
        public DomainException()
        {
            
        }
        public DomainException(string message)
            : base(message)
        { }

        public DomainException(string message, Exception innerException)
            : base(message, innerException)
        { }


    }

    
}
