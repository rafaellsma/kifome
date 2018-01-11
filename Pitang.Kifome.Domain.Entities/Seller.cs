using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pitang.Kifome.Domain.Entities
{
    public class Seller : User
    {
        public int Rate { get; set; }
        public Menu Menu { get; set; }
        public IList<Order> Orders { get; set; }
        public IList<Delivery> Deliveries { get; set; }
    }
}