﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Pitang.Kifome.Application.Contracts.Services;
using Pitang.Kifome.Application.Entities;
using Pitang.Kifome.Application.Entities.Comment;
using Pitang.Kifome.Domain.Contracts.Services;
using Pitang.Kifome.Domain.Entities;

namespace Pitang.Kifome.Application.Services.Implementation
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;
        private readonly ISellerService sellerService;
        private readonly ICustomerService customerService;

        public UserAppService(IUserService userServiceInstance, ISellerService sellerService, IMapper mapper, ICustomerService customerService)
        {
            this.userService = userServiceInstance;
            this.mapper = mapper;
            this.sellerService = sellerService;
            this.customerService = customerService;
        }
        
        public UserOutputDTO Authentication(LoginAuthenticationDTO login)
        {
            User user = this.userService.Authenticate(login.Email, login.Password);
            if (user != null)
            {
                UserOutputDTO userOutput = new UserOutputDTO()
                {
                    Name = user.Name,
                    Email = user.Email,
                    Id = user.Id
                };
                return userOutput;
            }
            return null;
        }

        public void DeleteUser(int Id)
        {
            this.userService.DeleteUser(Id);
        }

        public IList<UserOutputDTO> GetUsers()
        {
            IList<UserOutputDTO> usersOut = new List<UserOutputDTO>();

            IList<User> users = this.userService.GetUsers();

            foreach (var u in users)
            {
                UserOutputDTO user = new UserOutputDTO()
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email
                };
                usersOut.Add(user);
            }

            return usersOut;
        }

        public UserOutputDTO GetUserById(int Id)
        {
            User user = this.userService.GetUserById(Id);
            UserOutputDTO userOUT = new UserOutputDTO()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
            return userOUT;
        }

        public void RegisterUser(UserInputDTO user)
        {
            userService.CreateUser(new User
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password
            });
        }

        public void UpdateUser(UserUpdateInputDTO user)
        {
            IList<Withdrawal> withdrawals = sellerService.GetWithdrawalsBySellerId(user.Id);
            Menu menu = sellerService.GetMenuBySellerId(user.Id);
            this.userService.UpdateUser(new User
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                Password = user.Password,
                Rate = user.Rate,
                Withdrawals = withdrawals,
                Menu = menu
            });
        }

        #region Garnish
        public IList<GarnishOutputDTO> GetGarnishes()
        {
            var garnishes = userService.GetGarnishes();
            return mapper.Map<GarnishOutputDTO[]>(garnishes);

        }

        public GarnishOutputDTO GetGarnishByID(int id)
        {
            var garnish = userService.GetGarnishById(id);
            return mapper.Map<GarnishOutputDTO>(garnish);
        }
        #endregion

        #region Comment

        public void MakeComment(CommentInputDTO commentInputDTO)
        {
            var user = userService.GetUserById(commentInputDTO.UserId);
            var order = userService.OrdersFromUser(user.Id).FirstOrDefault(o => o.Id == commentInputDTO.OrderId);

            var comment = mapper.Map<Comment>(commentInputDTO);
            comment.User = user;
            comment.Order = order;
            userService.MakeComment(comment);
        }

        public IList<CommentOutputDTO> ShowAllCommentsFromOrder(int orderId)
        {
            return mapper.Map<CommentOutputDTO[]>(userService.GetCommentsFromOrder(orderId));
        }

        #endregion
    }
}
