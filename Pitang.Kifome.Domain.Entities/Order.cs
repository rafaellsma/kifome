﻿using System;
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
        public IList<Meal> Meals { get; set; }
        public OrderStatusEnum Status { get; set; }
        public IList<Comment> Comments { get; set; }
    }
}