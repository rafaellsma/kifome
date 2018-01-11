using Pitang.Kifome.Application.Contracts.Services;
using Pitang.Kifome.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Pitang.Kifome.Distribution.WebApi.Controllers
{
    [RoutePrefix("api")]
    public class GarnishesController : ApiController
    {
        public readonly ISellerAppService sellerAppService;

        public GarnishesController(ISellerAppService sellerAppService)
        {
            this.sellerAppService = sellerAppService;
        }

        [AcceptVerbs("post")]
        [Route("garnish")]
        public void CreateGarnish(GarnishInputDTO garnish)
        {
            sellerAppService.RegisterGarnish(garnish);
        }
    }
}
