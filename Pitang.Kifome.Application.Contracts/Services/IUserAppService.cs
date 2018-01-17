using Pitang.Kifome.Application.Entities;
using System;
using System.Collections.Generic;

namespace Pitang.Kifome.Application.Contracts.Services
{
    public interface IUserAppService
    {
        UserOutputDTO Authentication(LoginAuthenticationDTO login);
        void RegisterUser(UserInputDTO user);
        IList<UserOutputDTO> GetAllUsers();
        void UpdateUser(UserInputDTO user);
        UserOutputDTO GetUserById(int Id);
        void DeleteUser(int Id);
    }
}
