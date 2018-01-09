using System;
using System.Collections.Generic;
using Pitang.Kifome.Domain.Contracts.Repositories;
using Pitang.Kifome.Domain.Entities;

namespace Pitang.Kifome.Infra.Repositories.Repository
{
    public class DeliveryRepository : IDeliveryRepository
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Delivery entity)
        {
            throw new NotImplementedException();
        }

        public Delivery Select(int id)
        {
            throw new NotImplementedException();
        }

        public List<Delivery> SelectAll()
        {
            throw new NotImplementedException();
        }

        public Delivery SelectBySellerId(int sellerId)
        {
            throw new NotImplementedException();
        }

        public void Update(Delivery entity)
        {
            throw new NotImplementedException();
        }
    }
}
