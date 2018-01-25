using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Pitang.Kifome.Application.Contracts.Services;
using Pitang.Kifome.Application.Entities;
using Pitang.Kifome.Domain.Contracts.Services;
using Pitang.Kifome.Domain.Entities;

namespace Pitang.Kifome.Application.Services.Implementation
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UserAppService(IUserService userServiceInstance, IMapper mapper)
        {
            this.userService = userServiceInstance;
            this.mapper = mapper;
        }
        
        public UserOutputDTO Authentication(LoginAuthenticationDTO login)
        {
            User user = this.userService.Authenticate(login.Email, login.Password);
            if (user != null)
            {
                UserOutputDTO userOutput = new UserOutputDTO()
                {
                    Name = user.Name,
                    Email = user.Email,
                    Id = user.Id
                };
                return userOutput;
            }
            return null;
        }

        public void DeleteUser(int Id)
        {
            this.userService.DeleteUser(Id);
        }

        public IList<UserOutputDTO> GetUsers()
        {
            IList<UserOutputDTO> usersOut = new List<UserOutputDTO>();

            IList<User> users = this.userService.GetUsers();

            foreach (var u in users)
            {
                UserOutputDTO user = new UserOutputDTO()
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email
                };
                usersOut.Add(user);
            }

            return usersOut;
        }

        public UserOutputDTO GetUserById(int Id)
        {
            User user = this.userService.GetUserById(Id);
            UserOutputDTO userOUT = new UserOutputDTO()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
            return userOUT;
        }

        public void RegisterUser(UserInputDTO user)
        {
            userService.CreateUser(new User
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password
            });
        }

        public void UpdateUser(UserUpdateInputDTO user)
        {
            this.userService.UpdateUser(new User
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                Rate = user.Rate
            });
        }

        #region Garnish
        public IList<GarnishOutputDTO> GetGarnishes()
        {
            var garnishes = userService.GetGarnishes();
            return mapper.Map<GarnishOutputDTO[]>(garnishes);

        }

        public GarnishOutputDTO GetGarnishByID(int id)
        {
            var garnish = userService.GetGarnishById(id);
            return mapper.Map<GarnishOutputDTO>(garnish);
        }
        #endregion
    }
}
