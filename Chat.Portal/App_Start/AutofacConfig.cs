using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Chat.BLL;

namespace Chat.Portal
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(Startup).Assembly);
            builder.RegisterType<RegistartionService>().As<IRegistrationService>();
            builder.RegisterType<IdentityService>().As<IIdentityService>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}