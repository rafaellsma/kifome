using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Pitang.Kifome.Domain.Contracts.Repositories;
using Pitang.Kifome.Domain.Entities;

namespace Pitang.Kifome.Infra.Repositories.Repository
{
    public class DeliveryRepository : EfRepository<Delivery, int>, IDeliveryRepository
    {
        public DeliveryRepository(DbContext context) : base(context)
        {
        }

        public List<Delivery> SelectBySellerId(int sellerId)
        {
            var result = from delivery in this.Table
                         where delivery.Seller.Id == sellerId
                         select delivery;
            return result.ToList();
        }
    }
}
