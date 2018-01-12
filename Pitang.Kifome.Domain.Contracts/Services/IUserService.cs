using Pitang.Kifome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.Kifome.Domain.Contracts.Services
{
    public interface IUserService
    {
        User Authenticate(string email, string password);
        void CreateUser(string name, string email, string password);
        void MakeComment(User user, Order order, string mensage);
        List<Order> OrdersFromUser(User user);
    }
}
