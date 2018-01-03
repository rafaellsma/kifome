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
        private readonly IUserRepository userRepository;
        private readonly IOrderRepository orderRepository;

        public UserService(IUserRepository userRepository, IOrderRepository orderRepository)
        {
            this.userRepository = userRepository;
            this.orderRepository = orderRepository;
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

        public void MakeComment(Person person, Order order, string mensage)
        {
            Comment comment = new Comment(person, mensage);
            order.Conversation.Comments.Add(comment);
        }

        public List<Order> OrdersFromUser(Person person)
        {
            return orderRepository.SelectAllByPerson(person);
        }
    }
}
