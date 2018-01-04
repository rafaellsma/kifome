using Pitang.Kifome.Domain.Contracts.Repositories;
using Pitang.Kifome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitangueiros.Kifome.Infra.Repositories.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Order entity)
        {
            throw new NotImplementedException();
        }

        public Order Select(int id)
        {
            throw new NotImplementedException();
        }

        public List<Order> SelectAll()
        {
            throw new NotImplementedException();
        }

        public List<Order> SelectAllByUser(User user)
        {
            throw new NotImplementedException();
        }

        public void Update(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
