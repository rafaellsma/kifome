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
    }
}