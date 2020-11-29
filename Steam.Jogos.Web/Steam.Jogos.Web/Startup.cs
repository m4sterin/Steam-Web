using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(Steam.Jogos.Web.Startup))]

namespace Steam.Jogos.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Para obter mais informações sobre como configurar seu aplicativo, visite https://go.microsoft.com/fwlink/?LinkID=316888
            IAppBuilder appBuilder = app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/usuario/Login")
            });
        }
    }
}
