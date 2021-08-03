using Autofac;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CooperSystem.WebApi
{
    public class Module : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(Startup).Assembly)
                   .AsSelf()
                .InstancePerLifetimeScope()
                .AsImplementedInterfaces();

            builder.RegisterType<string>().As<string>();
            var controllersTypesInAssembly = typeof(Startup).Assembly.GetExportedTypes()
           .Where(type => typeof(ControllerBase).IsAssignableFrom(type)).ToArray();

            builder.RegisterTypes(controllersTypesInAssembly).PropertiesAutowired();
        }
    }
}
