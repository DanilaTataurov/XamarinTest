using Autofac;
using XamarinTest.BLL.Services;
using XamarinTest.BLL.Services.Base;
using XamarinTest.DAL.Common;
using XamarinTest.Domain.Interfaces.Services;

namespace XamarinTest.BLL.Common {
    public class ServiceModule : Module {
        protected override void Load(ContainerBuilder builder) {
            builder.RegisterModule(new RepositoryModule());
            builder.RegisterGeneric(typeof(BaseService<>)).AsSelf();

            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<ImageService>().As<IImageService>().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
