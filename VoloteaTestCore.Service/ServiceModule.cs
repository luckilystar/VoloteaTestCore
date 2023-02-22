using Autofac;
using System.Reflection;

namespace VoloteaTestCore.Service
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("VoloteaTestCore.Service"))
                   .Where(t => t.Name.EndsWith("Service"))
                   .AsImplementedInterfaces()
                  .InstancePerLifetimeScope();
        }
    }
}
