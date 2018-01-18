using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Pitang.Kifome.Application.Contracts.Services;
using Pitang.Kifome.Application.Entities;

namespace Pitang.Kifome.Distribution.WebApi.Controllers
{
    [RoutePrefix("api/withdrawal")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class WithdrawalController : ApiController
    {
        public readonly ISellerAppService sellerAppService;

        public WithdrawalController(ISellerAppService sellerAppService)
        {
            this.sellerAppService = sellerAppService;
        }

        public void CreateWithdrawal(WithdrawalInputDTO withdrawal)
        {
            sellerAppService.RegisterWithdrawal(withdrawal);
        }
    }
}