﻿using Pitang.Kifome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.Kifome.Domain.Contracts.Repositories
{
    public interface IConfiguredMealRepository : IRepository<ConfiguredMeal, int>
    {
        IList<ConfiguredMeal> SelectConfiguredMealByOrderId(int orderId, params Expression<Func<ConfiguredMeal, object>>[] includes);
    }
}
