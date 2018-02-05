using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Pitang.Kifome.Application.Contracts.Services;
using Pitang.Kifome.Application.Entities;
using Pitang.Kifome.Crosscuting.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Pitang.Kifome.Distribution.WebApi.Providers
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IUserAppService userAppService;
        public SimpleAuthorizationServerProvider()
        {
            this.userAppService = IocManager.Instance.IocContainer.Resolve<IUserAppService>();
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            IFormCollection parameters = await context.Request.ReadFormAsync();

            string email = parameters.Get("email");
            string password = parameters.Get("password");

            var user = userAppService.Authentication(new LoginAuthenticationDTO()
            {
                Email = email,
                Password = password
            });

            if (user == null)
            {
                context.SetError("invalid_grant", "The user email or password is incorrect.");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", email));
            identity.AddClaim(new Claim("role", "user"));

            context.Validated(identity);
        }
    }
}