﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Pitang.Kifome.Application.Contracts.Services;
using Pitang.Kifome.Application.Entities;
using Pitang.Kifome.Crosscuting.IoC;
using Pitang.Kifome.Application.Services.Implementation;

namespace Pitang.Kifome.Distribution.WebApi.Controllers
{
    public class UserController : ApiController
    {
        public readonly IUserAppService userAppService;
        public UserController()
        {
            this.userAppService = IocManager.Instance.IocContainer.Resolve<UserAppService>();
            //this.userAppService = IocManager.Instance.IocContainer.Resolve<IUserAppService>();
        }

        [HttpPost]
        public UserOutputDTO LoginAuthentication(LoginAuthenticationDTO login)
        {
            return this.userAppService.Authentication(login);
        }

    }
}