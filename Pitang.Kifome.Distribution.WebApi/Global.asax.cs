using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Pitangueiros.Kifome.Crosscuting.IoC;
using Pitang.Kifome.Domain.Services.IoC;
using Pitangueiros.Kifome.Infra.Repositories.IoC;
using Pitang.Kifome.Application.Services.IoC;

namespace Pitang.Kifome.Distribution.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            IocManager.Instance.IocContainer
                .Install(new DomainServicesInstaller())
                .Install(new RepositoryInstaller());
                //.Install(new ApplicationServiceInstaller());


            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
