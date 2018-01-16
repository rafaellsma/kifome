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
            if (user != null && user.Password == password)
            {
                return user;
            }
            return null;
        }

        public void CreateUser(User user)
        {
            this.unitOfWork.UserRepository.Insert(user);
        }

        public void MakeComment(Comment comment)
        {
            throw new NotImplementedException();
        }

        public List<Order> OrdersFromUser(int userId)
        {
            throw new NotImplementedException();
        }

    }
}
