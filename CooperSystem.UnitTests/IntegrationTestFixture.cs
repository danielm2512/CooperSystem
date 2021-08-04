using CooperSystem.Domain.Repositories;
using CooperSystem.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CooperSystem.UnitTests
{
    public class IntegrationTestFixture
    {

        public IntegrationTestFixture()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<ICarroRepository, CarroRepository>();
            serviceCollection.AddTransient<IMarcaRepository, MarcaRepository>();

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }
        public ServiceProvider ServiceProvider { get; private set; }
    }
}

