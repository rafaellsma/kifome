using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pitang.Kifome.Domain.Entities
{
    public class Order : BaseEntity<int>
    {
        public User Seller { get; set; }
        public User Customer { get; set; }
        public Withdrawal Withdrawal { get; set; }
        public IList<ConfiguredMeal> ConfiguredMeals { get; set; }
        public OrderStatusEnum Status { get; set; }
        public IList<Comment> Comments { get; set; }
    }
}