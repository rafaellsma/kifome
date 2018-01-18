﻿using Pitang.Kifome.Application.Contracts.Services;
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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MenuController : ApiController
    {
        public readonly ISellerAppService sellerAppService;

        public MenuController(ISellerAppService sellerAppService)
        {
            this.sellerAppService = sellerAppService;
        }

        [AcceptVerbs("Post")]
        [Route("Menu")]
        public void CreateMenu(MenuInputDTO menu)
        {
            sellerAppService.RegisterMenu(menu);
        }
    }
}