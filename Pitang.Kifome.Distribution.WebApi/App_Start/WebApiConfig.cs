using Pitang.Kifome.Crosscuting.IoC;
using Pitang.Kifome.Distribution.WebApi.Filters;
using Pitang.Kifome.Distribution.WebApi.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace Pitang.Kifome.Distribution.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors();

            config.MapHttpAttributeRoutes();

            config.Services.Replace(typeof(IHttpControllerActivator), new ApiControllerActivator());

            config.Filters.Add(new BeforeActionValidationFilter());

            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
