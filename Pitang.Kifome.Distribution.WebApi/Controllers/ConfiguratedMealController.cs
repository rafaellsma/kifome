using Pitang.Kifome.Application.Contracts.Services;
using Pitang.Kifome.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Pitang.Kifome.Distribution.WebApi.Controllers
{
    [RoutePrefix("api")]
    public class ConfiguratedMealController : ApiController
    {
        public readonly ICustomerAppService customerAppService;

        public ConfiguratedMealController(ICustomerAppService customerAppService)
        {
            this.customerAppService = customerAppService;
        }

        [AcceptVerbs("Post")]
        [Route("configurated")]
        public void MakeConfiguratedMeal(ConfiguredMealInputDTO configuratedMeal)
        {
            this.customerAppService.MakeConfiguratedMeal(configuratedMeal);
        }
    }
}