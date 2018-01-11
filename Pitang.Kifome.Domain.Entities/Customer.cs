using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pitang.Kifome.Domain.Entities
{
    public class Customer : User
    {
        public List<Order> OrdersHistory { get; set; }

        //public Customer(string name, string email, string password)
        //{
        //    this.Name = name;
        //    this.Email = email;
        //    this.Password = password;
        //}
    }
}