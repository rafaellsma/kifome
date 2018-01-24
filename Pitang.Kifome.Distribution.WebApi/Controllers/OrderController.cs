﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Pitang.Kifome.Application.Contracts.Services;
using Pitang.Kifome.Application.Entities;

namespace Pitang.Kifome.Distribution.WebApi.Controllers
{
    [RoutePrefix("api")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class OrderController : ApiController
    {
        private readonly ICustomerAppService customerAppService;
        public OrderController(ICustomerAppService customerAppServiceInstance)
        {
            this.customerAppService = customerAppServiceInstance;
        }
        [AcceptVerbs("Get")]
        [Route("order")]
        public OrderOutputDTO GetOrderById(int Id)
        {
            return this.customerAppService.GetOrderById(Id);
        }
        [AcceptVerbs("Post")]
        [Route("order")]
        public void MakeOrder(OrderInputDTO order)
        {
            this.customerAppService.MakeOrder(order);
        }
       
    }
}