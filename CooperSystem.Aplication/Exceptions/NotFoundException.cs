using Autofac.Core.Activators.Reflection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CooperSystem.Application.Exceptions
{
    public sealed class NotFoundException : DefaultConstructorFinder
    {
        public NotFoundException()
: base(type => type.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
        {
        }
    }
}
