using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooperSystem.Infrastructure.Data
{
    public class Module : Autofac.Module
    {
        public string ConnectionString { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(InfrastructureException).Assembly)
                .Where(type => type.Namespace.Contains("Repositories"))
                .WithParameter("connectionString", ConnectionString)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
