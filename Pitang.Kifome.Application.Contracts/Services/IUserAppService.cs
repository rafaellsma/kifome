using Pitang.Kifome.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.Kifome.Application.Contracts.Services
{
    public interface IUserAppService
    {
        UserOutputDTO Authentication(LoginAuthenticationDTO login);
        String RegisterUser(UserInputDTO user);
    }
}
