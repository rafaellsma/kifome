using Pitang.Kifome.Domain.Contracts.Repositories;
using Pitang.Kifome.Domain.Contracts.Services;
using Pitang.Kifome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.Kifome.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public bool Authenticate(string email, string password)
        {
            Person user = this.userRepository.SelectByEmail(email);
            bool authenticate = false;
            if (user != null)
            {
                authenticate = user.Password == password;
            }
            return authenticate;
        }

        public void CreateUser(Person person)
        {
            userRepository.Insert(person);
        }

        public void MakeComment(Person person, Conversation conversation, string mensage)
        {
            throw new NotImplementedException();
        }

        public List<Order> OrdersFromUser(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
