using Pitang.Kifome.Application.Contracts.Services;
using Pitang.Kifome.Application.Entities;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Pitang.Kifome.Distribution.WebApi.Controllers
{
    [RoutePrefix("api/garnish")]
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class GarnishesController : ApiController
    {
        #region Constructor

        public readonly ISellerAppService sellerAppService;

        public GarnishesController(ISellerAppService sellerAppService)
        {
            this.sellerAppService = sellerAppService;
        }

        #endregion

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
