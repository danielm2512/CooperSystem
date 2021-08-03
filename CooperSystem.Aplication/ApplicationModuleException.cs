using System;

namespace CooperSystem.Aplication
{
    public class ApplicationModuleException : Exception
    {
        public ApplicationModuleException(string businessMessage)
               : base(businessMessage)
        {
        }
    }
}
