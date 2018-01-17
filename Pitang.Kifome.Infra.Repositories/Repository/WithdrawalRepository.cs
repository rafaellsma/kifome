using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Pitang.Kifome.Domain.Contracts.Repositories;
using Pitang.Kifome.Domain.Entities;

namespace Pitang.Kifome.Infra.Repositories.Repository
{
    public class WithdrawalRepository : EfRepository<Withdrawal, int>, IWithdrawalRepository
    {
        public WithdrawalRepository(DbContext context) : base(context)
        {
        }

        public List<Withdrawal> SelectBySellerId(int sellerId)
        {
            var result = from withdrawal in this.Table
                         where withdrawal.Seller.Id == sellerId
                         select withdrawal;
            return result.ToList();
        }
    }
}
