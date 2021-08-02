using System;
using Microsoft.Owin;
using Microsoft.Owin.Infrastructure;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace Chat.Portal
{
    public class OwinCookieConfig
    {
        public static void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(options: new CookieAuthenticationOptions
            {
                AuthenticationType = nameof(Chat),
                AuthenticationMode = AuthenticationMode.Active,
                CookieName = nameof(Chat),
                CookieHttpOnly = true,
                CookiePath = "/",
                ExpireTimeSpan = TimeSpan.FromDays(7),
                CookieManager = new CookieManager(),
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider()
                {
                    OnResponseSignIn = ctx =>
                    {
                        ctx.Properties.IsPersistent = true;
                    }
                }
            });
        }
    }
}