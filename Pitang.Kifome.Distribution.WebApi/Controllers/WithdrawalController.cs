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
    [RoutePrefix("api")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class WithdrawalController : ApiController
    {
        public readonly ISellerAppService sellerAppService;

        public WithdrawalController(ISellerAppService sellerAppService)
        {
            this.sellerAppService = sellerAppService;
        }

        [AcceptVerbs("Post")]
        [Route("withdrawal")]
        public void CreateWithdrawal(WithdrawalInputDTO withdrawal)
        {
            sellerAppService.RegisterWithdrawal(withdrawal);
        }

        [AcceptVerbs("Get")]
        [Route("withdrawal")]
        public IList<WithdrawalOutputDTO> GetWithdrawals()
        {
            return sellerAppService.GetWithdrawals();
        }

        [AcceptVerbs("Get")]
        [Route("withdrawal/{id}")]
        public WithdrawalOutputDTO GetWithdrawalById(int id)
        {
            return sellerAppService.GetWithdrawalById(id);
        }

        [AcceptVerbs("Put")]
        [Route("withdrawal")]
        public void UpdateWithdrawal(WithdrawalUpdateInputDTO withdrawal)
        {
            sellerAppService.UpdateWithdrawal(withdrawal);
        }

        [AcceptVerbs("Delete")]
        [Route("withdrawal/{id}")]
        public void DeleteWithdrawal(int id)
        {
            sellerAppService.DeleteWithdrawal(id);
        }
    }
}