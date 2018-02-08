using Pitang.Kifome.Application.Contracts.Services;
using Pitang.Kifome.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Pitang.Kifome.Distribution.WebApi.Controllers
{
    [RoutePrefix("api")]
    public class MenuController : ApiController
    {
        public readonly ISellerAppService sellerAppService;

        public MenuController(ISellerAppService sellerAppService)
        {
            this.sellerAppService = sellerAppService;
        }

        [AcceptVerbs("Post")]
        [Route("menu")]
        public void CreateMenu(MenuInputDTO menu)
        {
            sellerAppService.RegisterMenu(menu);
        }

        [AcceptVerbs("Put")]
        [Route("menu")]
        public void UpdateMenu(MenuUpdateInputDTO menu)
        {
            sellerAppService.UpdateMenu(menu);
        }

        [AcceptVerbs("Get")]
        [Route("menu/{id}")]
        public MenuOutputDTO GetMenuBySellerId(int id)
        {
            return sellerAppService.GetMenuBySellerId(id);
        }
    }
}