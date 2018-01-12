using Pitang.Kifome.Application.Contracts.Services;
using Pitang.Kifome.Application.Entities;
using System.Web.Http;

namespace Pitang.Kifome.Distribution.WebApi.Controllers
{
    [RoutePrefix("api/garnish")]
    public class GarnishesController : ApiController
    {
        public readonly ISellerAppService sellerAppService;

        public GarnishesController(ISellerAppService sellerAppService)
        {
            this.sellerAppService = sellerAppService;
        }

        [AcceptVerbs("post")]
        public void CreateGarnish(GarnishInputDTO garnish)
        {
            sellerAppService.RegisterGarnish(garnish);
        }

        [AcceptVerbs("get")]
        public IHttpActionResult GetGarnishes()
        {
            return Ok(sellerAppService.GetGarnishes());
        }
    }
}
