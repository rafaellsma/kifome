﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pitang.Kifome.Application.Contracts.Services;
using Pitang.Kifome.Application.Entities;
using Pitang.Kifome.Domain.Contracts.Services;
using Pitang.Kifome.Domain.Entities;

namespace Pitang.Kifome.Application.Services.Implementation
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerService customerService;

        public CustomerAppService(ICustomerService customerServiceInstance)
        {
            this.customerService = customerServiceInstance;
        }

        public void DeleteOrder(int orderId)
        {
            this.customerService.CancelOrder(orderId);
        }

        public OrderOutputDTO GetOrderById(int orderId)
        {
            Order order = this.customerService.GetOrderById(orderId);
            IList<ConfiguredMealInputDTO> configuredMeal = new List<ConfiguredMealInputDTO>();
            ConfiguredMealInputDTO configMeal = null;
            if (order.ConfiguredMeals != null)
            {
                IList<GarnishOutputDTO> garnishies = new List<GarnishOutputDTO>();
                GarnishOutputDTO garnish = null;
                foreach (var cm in order.ConfiguredMeals)
                {
                    configMeal = new ConfiguredMealInputDTO();
                    foreach (var g in cm.Meal.Garnishies)
                    {
                        garnish = new GarnishOutputDTO()
                        {
                            Id = g.Id,
                            Name = g.Name,
                            Description = g.Description
                        };
                        garnishies.Add(garnish);
                    }
                    
                    configMeal.Meal = new MealOutputDTO
                    {
                        Id = cm.Meal.Id,
                        Days = cm.Meal.Days,
                        Description = cm.Meal.Description,
                        Garnishies = garnishies,
                        Name = cm.Meal.Name,
                        Price = cm.Meal.Price
                    };
                    configuredMeal.Add(configMeal);
                }
            }
            OrderOutputDTO orderDTO = new OrderOutputDTO
            {
                Id = order.Id,
                Seller = new UserOutputDTO
                {
                    Id = order.Seller.Id,
                    Name = order.Seller.Name,
                    Email = order.Seller.Email
                },
                Customer = new UserOutputDTO
                {
                    Id = order.Seller.Id,
                    Name = order.Seller.Name,
                    Email = order.Seller.Email
                },
                ConfiguredMeals = configuredMeal,
                Status = (OrderStatusEnumDTO)order.Status,
                Withdrawal = new WithdrawalInputDTO
                {
                    CEP = order.Withdrawal.CEP,
                    FinalHour = Convert.ToString(order.Withdrawal.FinalHour),
                    InitialHour = Convert.ToString(order.Withdrawal.InitialHour),
                    Latitude = order.Withdrawal.Latitude,
                    Longitude = order.Withdrawal.Longitude,
                    Number = order.Withdrawal.Number,
                    SellerId = order.Withdrawal.Seller.Id,
                    Street = order.Withdrawal.Street
                }
            };
            return orderDTO;
        }

        public void MakeOrder(OrderInputDTO order)
        {
            IList<ConfiguredMeal> configuredMeals = new List<ConfiguredMeal>();
            ConfiguredMeal configMeal = null;
            if (order.ConfiguredMeals != null)
            {
                foreach (var cm in order.ConfiguredMeals)
                {
                    configMeal = new ConfiguredMeal();
                    configMeal.MealId = cm.Meal.Id;
                    configMeal.OrderId = cm.Order.Id;
                }
                configuredMeals.Add(configMeal);
            }

            this.customerService.MakeOrder(new Order
            {
                Seller = new User {
                    Id = order.Seller.Id,
                    Name = order.Seller.Name,
                    Email =  order.Seller.Email
                },
                Customer = new User
                {
                    Id = order.Customer.Id,
                    Name = order.Customer.Name,
                    Email = order.Customer.Email
                },
                ConfiguredMeals = configuredMeals,
                Status = (OrderStatusEnum)order.Status,
                Withdrawal = new Withdrawal
                {
                    InitialHour = Convert.ToDateTime(order.Withdrawal.InitialHour),
                    FinalHour = Convert.ToDateTime(order.Withdrawal.FinalHour),
                    SellerId = order.Withdrawal.SellerId,
                    CEP = order.Withdrawal.CEP,
                    Number = order.Withdrawal.Number,
                    Street = order.Withdrawal.Street
                }               
            });
        }

        public UserOutputDTO SearchSellerByLocal(double latitude, double longitude)
        {
            throw new NotImplementedException();
        }

        public UserOutputDTO SearchSellerByName(string name)
        {
            throw new NotImplementedException();
        }

        public UserOutputDTO SearchSellerByPrice(float price)
        {
            throw new NotImplementedException();
        }

        public void SellerEvaluation(float rate)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(OrderInputDTO order)
        {
            IList<ConfiguredMeal> configuredMeals = new List<ConfiguredMeal>();
            ConfiguredMeal configMeal = null;
            if (order.ConfiguredMeals != null)
            {
                foreach (var cm in order.ConfiguredMeals)
                {
                    configMeal = new ConfiguredMeal();
                    configMeal.MealId = cm.Meal.Id;
                    configMeal.OrderId = cm.Order.Id;
                }
                configuredMeals.Add(configMeal);
            }

            this.customerService.EditOrder(new Order
            {
                Seller = new User
                {
                    Id = order.Seller.Id,
                    Name = order.Seller.Name,
                    Email = order.Seller.Email
                },
                Customer = new User
                {
                    Id = order.Customer.Id,
                    Name = order.Customer.Name,
                    Email = order.Customer.Email
                },
                ConfiguredMeals = configuredMeals,
                Status = (OrderStatusEnum)order.Status,
                Withdrawal = new Withdrawal
                {
                    InitialHour = Convert.ToDateTime(order.Withdrawal.InitialHour),
                    FinalHour = Convert.ToDateTime(order.Withdrawal.FinalHour),
                    SellerId = order.Withdrawal.SellerId,
                    CEP = order.Withdrawal.CEP,
                    Number = order.Withdrawal.Number,
                    Street = order.Withdrawal.Street
                }
            });
        }
    }
}