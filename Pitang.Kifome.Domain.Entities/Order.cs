﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pitang.Kifome.Domain.Entities
{
    public class Order
    {
        public Seller Seller { get; set; }
        public Customer Customer { get; set; }
        public Delivery Delivery { get; set; }
        public OrderStatus Status { get; set; }
    }
}