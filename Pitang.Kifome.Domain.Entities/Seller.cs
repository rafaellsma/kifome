using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pitang.Kifome.Domain.Entities
{
    public class Seller : Person
    {
        public int Rate { get; set; }
        public List<Order> Orders { get; set; }

        public List<Delivery> Deliveries { get; set; }
    }
}