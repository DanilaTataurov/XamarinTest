using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Extras.CommonServiceLocator;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using AutoMapper;
using CommonServiceLocator;
using Microsoft.Owin;
using Owin;
using XamarinTest.BLL.Common;
using XamarinTest.Web;

[assembly: OwinStartup(typeof(Startup))]

namespace XamarinTest.Web {
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
            ConfigureApp(app);
        }

        private void ConfigureApp(IAppBuilder app) {
            var configuration = new HttpConfiguration();
            configuration.MapHttpAttributeRoutes();
            var container = ConfigureDI(configuration);

            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(configuration);
            app.UseWebApi(configuration);

            app.UseAutofacMvc();
        }

        private ILifetimeScope ConfigureDI(HttpConfiguration configuration) {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterModule(new ServiceModule());
            builder.RegisterInstance<IMapper>(new Mapper(Mapping.Configuration.Create()));
            var container = builder.Build();

            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(container));
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            return container;
        }
    }
}
