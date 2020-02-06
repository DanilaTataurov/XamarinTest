using System.Data.Entity;
using Autofac;
using XamarinTest.DAL.Repositories;
using XamarinTest.Domain.Interfaces;

namespace XamarinTest.DAL.Common {
    public class RepositoryModule : Module {
        protected override void Load(ContainerBuilder builder) {
            builder.RegisterGeneric(typeof(EntityRepository<>)).InstancePerLifetimeScope();

            builder.RegisterType<Context.TestContext>().AsSelf().As(typeof(DbContext)).InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
