using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Pitang.Kifome.Domain.Contracts.Repositories;
using Pitang.Kifome.Domain.Entities;

namespace Pitang.Kifome.Infra.Repositories.Repository
{
    public class CustomerRepository : EfRepository<Customer, int>, ICustomerRepository
    {
        public CustomerRepository(DbContext context) : base(context)
        {
        }

        public User SelectByEmail(string email)
        {
            var result = from customer in this.Table
                         where customer.Email == email
                         select customer;
            return result.SingleOrDefault();
        }
    }
}
