﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pitang.Kifome.Application.Contracts.Services;
using Pitang.Kifome.Application.Entities;
using Pitang.Kifome.Domain.Contracts.Services;
using Pitang.Kifome.Domain.Entities;

namespace Pitang.Kifome.Application.Services.Implementation
{
    public class UserAppService : IUserAppService
    {
        private IUserService userService { get; set; }

        public UserAppService(IUserService userServiceInstance)
        {
            this.userService = userServiceInstance;
        }
        
        public UserOutputDTO Authentication(LoginAuthenticationDTO login)
        {
            return this.userService.Authenticate(login.Email, login.Password).MapTo<UserOutputDTO>();
        }

        public string RegisterUser(UserInputDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
