using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace CooperSystem.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureAppConfiguration((builderContext, config) =>
                {
                    IHostingEnvironment env = (IHostingEnvironment)builderContext.HostingEnvironment;

                    if (env.IsStaging())
                    {
                        config.AddJsonFile("autofacCooperSystem.json");
                    }

                    config.AddEnvironmentVariables();
                })
                .ConfigureServices(services => services.AddAutofac());
    }
}
