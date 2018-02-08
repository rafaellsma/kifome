using Pitang.Kifome.Application.Contracts.Services;
using Pitang.Kifome.Application.Entities;
using Pitang.Kifome.Application.Entities.Garnish;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Pitang.Kifome.Distribution.WebApi.Controllers
{
    [RoutePrefix("api")]
    public class GarnishesController : ApiController
    {
        private readonly ISellerAppService sellerAppService;
        private readonly IUserAppService userAppService;

        public GarnishesController(ISellerAppService sellerAppService, IUserAppService userAppService)
        {
            this.sellerAppService = sellerAppService;
            this.userAppService = userAppService;
        }

        [Authorize]
        [HttpPost]
        [Route("garnishes")]
        public void CreateGarnish(GarnishInputDTO garnish)
        {
            sellerAppService.RegisterGarnish(new GarnishWithSellerDTO()
            {
                Name = garnish.Name,
                Description = garnish.Description,
                SellerId = CurrentUserId()
            });
        }

        [Authorize]
        [HttpGet]
        [Route("garnishes")]
        public IList<GarnishOutputDTO> GetGarnishes()
        {
            return userAppService.GetGarnishes();
        }

        [HttpGet]
        [Route("garnishes/{id:int}")]
        public GarnishOutputDTO GarnishById(int id)
        {
            return userAppService.GetGarnishByID(id);
        }

        [HttpPut]
        [Route("garnishes/{id:int}")]
        public void UpdateGarnish([FromUri]int id, [FromBody]GarnishInputDTO garnishBody)
        {
            sellerAppService.UpdateGarnish(new GarnishUpdateDTO()
            {
                Id = id,
                Name = garnishBody.Name,
                Description = garnishBody.Description
            });
        }

        [HttpDelete]
        [Route("garnishes/{id:int}")]
        public void DeleteGarnish(int id)
        {
            sellerAppService.DeleteGarnish(id);
        }

        private int CurrentUserId()
        {
            var identity = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            int id = 0;

            foreach (var claim in claims)
            {
                if(claim.Type == "id")
                {
                    id = int.Parse(claim.Value);
                }
            }

            return id;
        }
    }
}
