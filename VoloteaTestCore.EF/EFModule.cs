using Autofac;
using Microsoft.EntityFrameworkCore;

namespace VoloteaTestCore.EF
{
    public class EFModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterModule(new RepositoryModule());
            builder.RegisterType(typeof(PeopleDbContext))
                .As(typeof(DbContext))
                .InstancePerLifetimeScope();
        }

    }
}
