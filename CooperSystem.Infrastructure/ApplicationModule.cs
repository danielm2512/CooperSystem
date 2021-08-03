using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooperSystem.Infrastructure
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(Aplication.ApplicationModuleException).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
