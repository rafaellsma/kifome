using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using Pitang.Kifome.Domain.Contracts.Repositories;
using Pitang.Kifome.Domain.Entities;

namespace Pitang.Kifome.Infra.Repositories.Repository
{
    public class SellerRepository : UserRepository<Seller, int>, ISellerRepository
    {
        public SellerRepository(DbContext context) : base(context)
        {
        }

        public List<Seller> SelectByRate(int rate)
        {
            var result = from seller in this.Table
                         where seller.Rate == rate
                         select seller;
            return result.ToList();
        }
    }
}
