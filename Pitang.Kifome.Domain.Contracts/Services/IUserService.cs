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
        void CreateUser(User user);
        void MakeComment(Comment comment);
        IList<Comment> GetCommentsFromOrder(int orderId);
        IList<Order> OrdersFromUser(int userId);
        List<User> GetUsers();
        void UpdateUser(User user);
        User GetUserById(int Id);
        void DeleteUser(int Id);
        IList<Garnish> GetGarnishes();
        Garnish GetGarnishById(int id);

    }
}
