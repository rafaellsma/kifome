using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pitang.Kifome.Domain.Entities
{
    public class User : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public double Rate { get; set; }
        public IList<Withdrawal> Withdrawals { get; set; }
        public IList<Order> ReceivedOrders { get; set; }
        public IList<Order> MadeOrders { get; set; }
        public virtual Menu Menu { get; set; }
        public virtual IList<Garnish> Garnishes { get; set; }
    }
}