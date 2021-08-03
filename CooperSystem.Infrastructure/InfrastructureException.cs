using System;
using System.Collections.Generic;
using System.Text;

namespace CooperSystem.Infrastructure.Data
{
    public class InfrastructureException : Exception
    {
        internal InfrastructureException(string businessMessage)
               : base(businessMessage)
        {
        }
    }
}
