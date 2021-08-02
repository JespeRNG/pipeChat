using System.Web.Routing;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Chat.Portal.Startup))]
namespace Chat.Portal
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            AutofacConfig.ConfigureContainer();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            OwinCookieConfig.Configuration(app);
        }
    }
}