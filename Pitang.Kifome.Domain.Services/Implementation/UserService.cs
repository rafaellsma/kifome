using Pitang.Kifome.Domain.Contracts.Repositories;
using Pitang.Kifome.Domain.Contracts.Services;
using Pitang.Kifome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.Kifome.Domain.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public User Authenticate(string email, string password)
        {
            User user = this.unitOfWork.UserRepository.SelectByEmail(email);
            if (user != null)
            {
                return user;
            }
            return null;
        }

        public void CreateUser(string name, string email, string password)
        {
            User user = new User()
            {
                Name = name,
                Email = email,
                Password = password
            };
            this.unitOfWork.UserRepository.Insert(user);
        }

        public void MakeComment(User user, Order order, string mensage)
        {
            throw new NotImplementedException();
        }

        public List<Order> OrdersFromUser(User user)
        {
            throw new NotImplementedException();
        }

    }
}
