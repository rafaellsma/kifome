using System;
using System.Collections.Generic;
using AutoMapper;
using Pitang.Kifome.Application.Contracts.Services;
using Pitang.Kifome.Application.Entities;
using Pitang.Kifome.Application.Entities.ConfiguratedMeal;
using Pitang.Kifome.Application.Entities.User;
using Pitang.Kifome.Domain.Contracts.Services;
using Pitang.Kifome.Domain.Entities;

namespace Pitang.Kifome.Application.Services.Implementation
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerService customerService;
        private readonly ISellerService sellerService;
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public CustomerAppService(ICustomerService customerServiceInstance, ISellerService sellerServiceInstance, IUserService userServiceInstance, IMapper mapper)
        {
            this.customerService = customerServiceInstance;
            this.sellerService = sellerServiceInstance;
            this.userService = userServiceInstance;
            this.mapper = mapper;
        }

        #region Order
        public void DeleteOrder(int orderId)
        {
            this.customerService.CancelOrder(orderId);
        }

        public OrderOutputDTO GetOrderById(int orderId)
        {
            Order order = this.customerService.GetOrderById(orderId);
            IList<ConfiguratedMealDTO> configuredMeal = new List<ConfiguratedMealDTO>();
            if (order.ConfiguredMeals != null)
            {
                IList<string> garnishiesNames = new List<string>();
                foreach (var cm in order.ConfiguredMeals)
                {
                    ConfiguratedMealDTO configMeal = new ConfiguratedMealDTO();
                    if (order.ConfiguredMeals != null)
                    {
                        if (cm.SelectedGarnishes != null)
                        {
                            foreach (var g in cm.SelectedGarnishes)
                            {
                                garnishiesNames.Add(g.Name);
                            }
                        }

                        configMeal.Meal = new MealOutputDTO
                        {
                            Id = cm.Meal.Id,
                            Days = cm.Meal.Days,
                            Description = cm.Meal.Description,
                            GarnishiesName = garnishiesNames,
                            Name = cm.Meal.Name,
                            Price = cm.Meal.Price
                        };
                        configuredMeal.Add(configMeal);
                    }
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
                    Id = order.Customer.Id,
                    Name = order.Customer.Name,
                    Email = order.Customer.Email
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

        public IList<OrderOutputDTO> GetOrders()
        {
            var orders = this.customerService.GetOrders();
            IList<OrderOutputDTO> ordersDTO = new List<OrderOutputDTO>();
            foreach (var order in orders)
            {
                IList<ConfiguratedMealDTO> configuredMeal = new List<ConfiguratedMealDTO>();
                if (order.ConfiguredMeals != null)
                {
                    IList<string> garnishiesNames = new List<string>();
                    foreach (var cm in order.ConfiguredMeals)
                    {
                        ConfiguratedMealDTO configMeal = new ConfiguratedMealDTO();
                        if (order.ConfiguredMeals != null)
                        {
                            if (cm.SelectedGarnishes != null)
                            {
                                foreach (var g in cm.SelectedGarnishes)
                                {
                                    garnishiesNames.Add(g.Name);
                                }
                            }

                            configMeal.Meal = new MealOutputDTO
                            {
                                Id = cm.Meal.Id,
                                Days = cm.Meal.Days,
                                Description = cm.Meal.Description,
                                GarnishiesName = garnishiesNames,
                                Name = cm.Meal.Name,
                                Price = cm.Meal.Price
                            };
                            configuredMeal.Add(configMeal);
                        }
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
                        Id = order.Customer.Id,
                        Name = order.Customer.Name,
                        Email = order.Customer.Email
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

                ordersDTO.Add(orderDTO);
            }

            return ordersDTO;
        }

        public void MakeOrder(OrderInputDTO order)
        {
            var customer = this.userService.GetUserById(order.CustomerId);
            var seller = this.userService.GetUserById(order.SellerId);
            var withdrawal = this.sellerService.GetWithdrawalById(order.WithdrawalId);

            this.customerService.MakeOrder(new Order
            {
                Customer = customer,
                Seller = seller,
                Withdrawal = withdrawal,
                Status = 0
            });
        }

        public void UpdateOrder(OrderUpdateInputDTO order)
        {
            var customer = this.userService.GetUserById(order.CustomerId);
            var seller = this.userService.GetUserById(order.SellerId);
            var withdrawal = this.sellerService.GetWithdrawalById(order.WithdrawalId);

            this.customerService.EditOrder(new Order
            {
                Id = order.Id,
                Customer = customer,
                Seller = seller,
                Withdrawal = withdrawal,
                Status = (OrderStatusEnum)order.OrderStatus
            });
        }
        #endregion

        #region Seller
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

        public IList<SellerOutputDTO> GetAllSellers()
        {
            IList<User> sellers = new List<User>();
            sellers = customerService.GetSellers();
            IList<SellerOutputDTO> sellersDTO = mapper.Map<SellerOutputDTO[]>(sellers);
            return sellersDTO;
        }
        #endregion

        #region ConfiguratedMeal
        public void MakeConfiguratedMeal(ConfiguredMealInputDTO configuredMeal)
        {
            IList<Garnish> garnishies = new List<Garnish>();
            if (configuredMeal.GarnishesId != null)
            {
                foreach (var g in configuredMeal.GarnishesId)
                {
                    garnishies.Add(userService.GetGarnishById(g));
                }
            }

            Meal meal = sellerService.GetMealById(configuredMeal.MealId);
            Order order = customerService.GetOrderById(configuredMeal.OrderId);

            customerService.MakeConfiguratedMeal(new ConfiguredMeal
            {
                Meal = meal,
                Order = order,
                SelectedGarnishes = garnishies
            });
        }

        public IList<ConfiguratedMealOutputDTO> GetConfiguratedMealsByOrderId(int orderId)
        {
            IList<ConfiguratedMealOutputDTO> configuratedMealOutputDtos = new List<ConfiguratedMealOutputDTO>();
            IList<ConfiguredMeal> configuredMeals = customerService.GetConfiguredMealByOrderId(orderId);
            foreach (var cm in configuredMeals )
            {
                ConfiguratedMealOutputDTO cmDTO = new ConfiguratedMealOutputDTO
                {
                    OrderId = cm.OrderId,
                    MealName = sellerService.GetMealById(cm.MealId).Name,
                    GarnishesNames = new List<string>()
                };
                foreach (var sg in cm.SelectedGarnishes)
                {
                    cmDTO.GarnishesNames.Add(sg.Name);
                }
                configuratedMealOutputDtos.Add(cmDTO);
            }

            return configuratedMealOutputDtos;
        }
        #endregion
    }
}
