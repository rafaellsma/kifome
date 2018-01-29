using Pitang.Kifome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.Kifome.Domain.Contracts.Repositories
{
    public interface IOrderRepository : IRepository<Order, int>
    {
        List<Order> SelectAllBySellerId(int id);
        List<Order> SelectAllByCustomerId(int id);
        Order SelectOrderById(int Id);
    }
}
