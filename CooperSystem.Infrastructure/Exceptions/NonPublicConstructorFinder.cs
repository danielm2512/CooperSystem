using Autofac.Core.Activators.Reflection;
using System.Reflection;

namespace CooperSystem.Infrastructure.Exceptions
{

    public interface ITest
    {
    }

    public sealed class TestClass : ITest
    {
        internal TestClass()
        {
        }
    }
    public class NonPublicConstructorFinder : DefaultConstructorFinder
    {
        public NonPublicConstructorFinder()
    : base(type => type.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
        {
        }

    }
}
