using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pitang.Kifome.Domain.Entities
{
    public class Customer : User
    {
        public IList<Order> OrdersHistory { get; set; }
    }
}