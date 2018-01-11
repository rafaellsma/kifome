using Pitang.Kifome.Application.Entities;
using System;

namespace Pitang.Kifome.Application.Contracts.Services
{
    public interface IUserAppService
    {
        UserOutputDTO Authentication(LoginAuthenticationDTO login);
        String RegisterUser(UserInputDTO user);
    }
}
