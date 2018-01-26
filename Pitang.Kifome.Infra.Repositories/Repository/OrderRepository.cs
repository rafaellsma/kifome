using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Pitang.Kifome.Domain.Contracts.Repositories;
using Pitang.Kifome.Domain.Entities;

namespace Pitang.Kifome.Infra.Repositories.Repository
{
    public class OrderRepository : EfRepository<Order, int>, IOrderRepository
    {
        public OrderRepository(DbContext context) : base(context)
        {
        }

        public List<Order> SelectAllBySellerId(int id)
        {
            var result = from order in this.Table
                         where order.Seller.Id == id
                         select order;
            return result.ToList();
        }

        public List<Order> SelectAllByCustomerId(int id)
        {
            var result = from order in this.Table
                         where order.Customer.Id == id
                         select order;
            return result.ToList();
        }

        public Order SelectOrderById(int Id)
        {
            var result = (from order in Context.Set<Order>()
                          join s in Context.Set<User>() on order.Seller.Id equals s.Id
                          join c in Context.Set<User>() on order.Customer.Id equals c.Id
                          join w in Context.Set<Withdrawal>() on order.Withdrawal.Id equals w.Id
                          where order.Id == Id
                          select new
                          {
                              Id = order.Id,
                              Status = order.Status,
                              Withdrawal = w,
                              Customer = c,
                              Seller = s
                          }).SingleOrDefault();

            var resultCM = (from cm in Context.Set<ConfiguredMeal>()
                            join m in Context.Set<Meal>() on cm.MealId equals m.Id
                            where cm.OrderId == Id
                            select new
                            {
                                Id = cm.Id,
                                Orderid = cm.OrderId,
                                Meal = m
                            }).ToList();

           


            IList < ConfiguredMeal > configMeals = new List<ConfiguredMeal>();
            if (resultCM != null)
            {
                foreach (var item in resultCM)
                {
                    var resultgarnish = (from m in Context.Set<Meal>()
                                         where m.Garnishies.Any(g => g.Id == item.Meal.Id)
                                         select m).ToList();

                    ConfiguredMeal config = new ConfiguredMeal()
                    {
                        Id = item.Id,
                        Meal = new Meal
                        {
                            Id = item.Meal.Id,
                            Days = item.Meal.Days,
                            Description = item.Meal.Description,
                            Name = item.Meal.Name,
                            Price = item.Meal.Price
                        },
                        OrderId = item.Orderid
                    };
                    configMeals.Add(config);
                }
            }

            Order orderResult = new Order
            {
                Id = result.Id,
                Status = result.Status,
                Withdrawal = new Withdrawal
                {
                    Id = result.Withdrawal.Id,
                    CEP = result.Withdrawal.CEP,
                    FinalHour = result.Withdrawal.FinalHour,
                    InitialHour = result.Withdrawal.InitialHour,
                    Latitude = result.Withdrawal.Latitude,
                    Longitude = result.Withdrawal.Longitude,
                    Number = result.Withdrawal.Number,
                    Street = result.Withdrawal.Street,
                    Seller = new User
                    {
                        Id = result.Seller.Id,
                        Name = result.Seller.Name,
                        Email = result.Seller.Email
                    }
                },
                Seller = new User
                {
                    Id = result.Seller.Id,
                    Name = result.Seller.Name,
                    Email = result.Seller.Email
                },
                Customer = new User
                {
                    Id = result.Seller.Id,
                    Name = result.Seller.Name,
                    Email = result.Seller.Email
                },
                ConfiguredMeals = configMeals
            };

            return orderResult;
        }
    }
}
//public User Customer { get; set; }
//public Withdrawal Withdrawal { get; set; }
//public IList<ConfiguredMeal> ConfiguredMeals { get; set; }
//public OrderStatusEnum Status { get; set; }
//public IList<Comment> Comments { get; set; }