using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Owin;
using Microsoft.Owin.Security.Cookies;

[assembly: OwinStartup(typeof(Web.Portal.Startup))]
namespace Web.Portal
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
             //For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            // .net core 一套似乎没用？
            //app.UseCookieAuthentication(new CookieAuthenticationOptions
            //{
            //    AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active,
            //    AuthenticationType = "OwinFormAuth",
            //    CookieSecure=CookieSecureOption.Always,
            //    LoginPath = new PathString("/Login"),
            //    CookieName = "Web.HEVO",
            //    CookieHttpOnly = true,
            //    ExpireTimeSpan = TimeSpan.FromDays(2),
            //    CookiePath = "/Account",
            //    SlidingExpiration=true,
            //    Provider = new FormsAuthenticationProvider()
            //    {

            //    }
            //});
            //app.SetDefaultSignInAsAuthenticationType("OwinFormAuth");

            app.MapSignalR();

        }

    }
}
