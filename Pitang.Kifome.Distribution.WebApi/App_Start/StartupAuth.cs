using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Pitang.Kifome.Distribution.WebApi.Providers;
using System;
using System.Web.Http;

[assembly: OwinStartup(typeof(Pitang.Kifome.Distribution.WebApi.Startup))]
namespace Pitang.Kifome.Distribution.WebApi
{
    public class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            ConfigureOAuth(app);

            WebApiConfig.Register(config);
           
            app.UseWebApi(config);
        }

        public static void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider()
            };

            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }
    }
}