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

        public void DeleteUser(int Id)
        {
            User user = this.unitOfWork.UserRepository.SelectById(Id);
            this.unitOfWork.UserRepository.Delete(user);
        }

        public List<User> GetUsers()
        {
            return this.unitOfWork.UserRepository.SelectAll();
        }

        public User GetUserById(int Id)
        {
            return this.unitOfWork.UserRepository.SelectById(Id);
        }

        public IList<Order> OrdersFromUser(int userId)
        {
            var user = this.unitOfWork.UserRepository.SelectById(userId, u => u.MadeOrders, u => u.ReceivedOrders);
            var allOrders = user.ReceivedOrders.Concat(user.MadeOrders);
            return allOrders.ToList();
        }

        public void UpdateUser(User user)
        {
            this.unitOfWork.UserRepository.Update(user);
        }

        #region Garnish
        public IList<Garnish> GetGarnishes()
        {
            return unitOfWork.GarnishRepository.SelectAll(x => x.Meals);
        }

        public Garnish GetGarnishById(int id)
        {
            return unitOfWork.GarnishRepository.SelectById(id);
        }
        #endregion

        #region Comment
        public void MakeComment(Comment comment)
        {
            if (comment.Order != null)
            {
                this.unitOfWork.CommentRepository.Insert(comment);
            }
        }

        public IList<Comment> GetCommentsFromOrder(int orderId)
        {
            var order = this.unitOfWork.OrderRepository.SelectById(orderId, o => o.Comments);
            return order.Comments;
        }
        #endregion
    }
}
