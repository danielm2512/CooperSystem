using System;
using System.Collections.Generic;
using System.Text;

namespace CooperSystem.Infrastructure.Exceptions
{
    internal sealed class NotFoundException : ApplicationException
    {
        internal NotFoundException(string message)
            : base(message)
        { }
    }
}
