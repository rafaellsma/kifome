﻿using Pitang.Kifome.Application.Contracts.Services;
using Pitang.Kifome.Application.Entities;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Pitang.Kifome.Distribution.WebApi.Controllers
{
    [RoutePrefix("api")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class GarnishesController : ApiController
    {
        private readonly ISellerAppService sellerAppService;
        private readonly IUserAppService userAppService;

        public GarnishesController(ISellerAppService sellerAppService, IUserAppService userAppService)
        {
            this.sellerAppService = sellerAppService;
            this.userAppService = userAppService;
        }

        [HttpPost]
        [Route("garnishes")]
        public void CreateGarnish(GarnishInputDTO garnish)
        {
            sellerAppService.RegisterGarnish(garnish);
        }

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
    }
}
