using Pitang.Kifome.Domain.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pitang.Kifome.Domain.Entities;

namespace Pitang.Kifome.Domain.Services.Implementation
{
    class UserService : IUserService
    {
        public bool Authenticate(string email, string password)
        {
            throw new NotImplementedException();
        }

        public void CreateUser(Person person)
        {
            throw new NotImplementedException();
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
