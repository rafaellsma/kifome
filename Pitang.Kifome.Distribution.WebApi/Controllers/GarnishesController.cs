using Pitang.Kifome.Application.Contracts.Services;
using Pitang.Kifome.Application.Entities;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Pitang.Kifome.Distribution.WebApi.Controllers
{
    [Route("api/garnishes")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class GarnishesController : ApiController
    {
        public readonly ISellerAppService sellerAppService;

        public GarnishesController(ISellerAppService sellerAppService)
        {
            this.sellerAppService = sellerAppService;
        }

        [HttpPost]
        public void CreateGarnish(GarnishInputDTO garnish)
        {
            sellerAppService.RegisterGarnish(garnish);
        }

        [HttpGet]
        public IList<GarnishOutputDTO> GetGarnishes()
        {
            return sellerAppService.GetGarnishes();
        }
    }
}
