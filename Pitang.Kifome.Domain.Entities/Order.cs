using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pitang.Kifome.Domain.Entities
{
    public class Order : BaseEntity<int>
    {
        public Seller Seller { get; set; }
        public Customer Customer { get; set; }
        public Delivery Delivery { get; set; }
        public List<Meal> Meals { get; set; }
        public OrderStatusEnum Status { get; set; }
        public List<Comment> Comments { get; set; }

        public Order(Seller seller, Customer customer, Delivery delivery, List<Meal> meals)
        {
            this.Seller = seller;
            this.Customer = customer;
            this.Delivery = delivery;
            this.Meals = meals;
        }
    }
}