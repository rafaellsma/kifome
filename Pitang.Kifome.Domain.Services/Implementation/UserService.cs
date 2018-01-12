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
    public class UserService<T> : IUserService<T, int>
        where T : User, IBaseEntity<int>, new()
    {
        private readonly IUserRepository<T, int> userRepository;
        private readonly IOrderRepository orderRepository;

        public UserService(IUserRepository<T, int> userRepository, IOrderRepository orderRepository)
        {
            this.userRepository = userRepository;
            this.orderRepository = orderRepository;
        }

        public bool Authenticate(string email, string password)
        {
            var user = this.userRepository.SelectByEmail(email);
            bool autentication = false;
            if (user != null)
            {
                autentication = user.Password == password;
            }
            return autentication;
        }

        public void CreateUser(T user)
        {
            userRepository.Insert(user);
        }

        public void MakeComment(T user, Order order, string mensage)
        {
            Comment comment = new Comment()
            {
                User = user,
                Order = order,
                Message = mensage
            };
            order.Comments.Add(comment);
            orderRepository.Update(order);
        }
    }
}
