using Pitang.Kifome.Application.Contracts.Services;
using Pitang.Kifome.Application.Entities.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Pitang.Kifome.Distribution.WebApi.Controllers
{
    [RoutePrefix("api")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CommentController : ApiController
    {
        private readonly IUserAppService userAppService;

        public CommentController(IUserAppService userAppService)
        {
            this.userAppService = userAppService;
        }

        [HttpPost]
        [Route("order/{orderId:int}/comments")]
        public void CreateComment(int orderId, [FromBody] CommentInputFromBodyDTO commentInputDTO)
        {
            var comment = new CommentInputDTO()
            {
                OrderId = orderId,
                Message = commentInputDTO.Message,
                UserId = commentInputDTO.UserId
            };

            userAppService.MakeComment(comment);
        }

        [HttpGet]
        [Route("order/{orderId:int}/comments")]
        public IList<CommentOutputDTO> GetAllCommentsFromOrder(int orderId)
        {
            return userAppService.ShowAllCommentsFromOrder(orderId);
        }
    }
}