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
        public List<Order> Orders { get; set; }
        public List<Delivery> Deliveries { get; set; }

        //public Seller(string name, string email, string password)
        //{
        //    this.Name = name;
        //    this.Email = email;
        //    this.Password = password;
        //}
    }
}