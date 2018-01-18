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
    [RoutePrefix("api/user")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        public readonly IUserAppService userAppService;

        public UserController(IUserAppService userAppService)
        {
            this.userAppService = userAppService;
        }

        [AcceptVerbs("post")]
        [Route("CreateUser")]
        public void CreateUser(UserInputDTO user)
        {
            this.userAppService.RegisterUser(user);
        }

        [AcceptVerbs("Get")]
        [Route("GetAllUsers")]
        public IList<UserOutputDTO> GetAllUsers()
        {
            return this.userAppService.GetAllUsers();
        }

        [AcceptVerbs("Get")]
        [Route("GetUserById")]
        public UserOutputDTO GetUserById(int Id)
        {
            return this.userAppService.GetUserById(Id);
        }

        [AcceptVerbs("Put")]
        [Route("UpdateUser")]
        public void UpdateUser(UserUpdateInputDTO user)
        {
            this.userAppService.UpdateUser(user);
        }

        [AcceptVerbs("Delete")]
        [Route("DeleteUser")]
        public void DeleteUser(int Id)
        {
            this.userAppService.DeleteUser(Id);
        }
    }
}