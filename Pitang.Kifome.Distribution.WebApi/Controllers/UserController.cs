using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Pitang.Kifome.Application.Contracts.Services;
using Pitang.Kifome.Application.Entities;
using Pitang.Kifome.Application.Entities.User;

namespace Pitang.Kifome.Distribution.WebApi.Controllers
{
    [RoutePrefix("api")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        public readonly IUserAppService userAppService;
        public readonly ISellerAppService sellerAppService;
        public readonly ICustomerAppService customerAppService;

        public UserController(IUserAppService userAppService, ISellerAppService sellerAppService, ICustomerAppService customerAppService)
        {
            this.userAppService = userAppService;
            this.sellerAppService = sellerAppService;
            this.customerAppService = customerAppService;
        }

        [AcceptVerbs("Post")]
        [Route("user")]
        public void CreateUser(UserInputDTO user)
        {
            this.userAppService.RegisterUser(user);
        }

        [AcceptVerbs("Get")]
        [Route("user")]
        public IList<UserOutputDTO> GetAllUsers()
        {
            return this.userAppService.GetUsers();
        }

        [AcceptVerbs("Get")]
        [Route("user/{id}")]
        public UserOutputDTO GetUserById(int Id)
        {
            return this.userAppService.GetUserById(Id);
        }

        [AcceptVerbs("Put")]
        [Route("user")]
        public void UpdateUser(UserUpdateInputDTO user)
        {
            this.userAppService.UpdateUser(user);
        }

        [AcceptVerbs("Delete")]
        [Route("user/{id}")]
        public void DeleteUser(int Id)
        {
            this.userAppService.DeleteUser(Id);
        }

        [AcceptVerbs("Get")]
        [Route("user/{id}/withdrawal")]
        public IList<WithdrawalOutputDTO> GetWithdrawalsBySellerId(int id)
        {
            return sellerAppService.GetWithdrawalsBySellerId(id);
        }

        [AcceptVerbs("Get")]
        [Route("user/{id}/menu")]
        public MenuOutputDTO GetMenuBySellerId(int id)
        {
            return sellerAppService.GetMenuBySellerId(id);
        }

        [AcceptVerbs("Get")]
        [Route("sellers")]
        public IList<SellerOutputDTO> GetSellers()
        {
            return customerAppService.GetAllSellers();
        }
    }
}