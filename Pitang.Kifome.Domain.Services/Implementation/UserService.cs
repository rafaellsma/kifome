﻿using Pitang.Kifome.Domain.Contracts.Repositories;
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

        public User Authenticate(string email, string password)
        {
            User user = this.userRepository.SelectByEmail(email);
            if (user != null)
            {
                return user;
            }
            return null;
        }

        public void CreateUser(User user)
        {
            userRepository.Insert(user);
        }

        public void MakeComment(User user, Order order, string mensage)
        {
            Comment comment = new Comment(user, order, mensage);
            order.Comments.Add(comment);
            orderRepository.Update(order);
        }

        public List<Order> OrdersFromUser(User user)
        {
            return orderRepository.SelectAllByUser(user);
        }

    }
}
