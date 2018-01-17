﻿using Pitang.Kifome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.Kifome.Domain.Contracts.Repositories
{
    public interface IWithdrawalRepository : IRepository<Withdrawal, int>
    {
        List<Withdrawal> SelectBySellerId(int sellerId);
    }
}
