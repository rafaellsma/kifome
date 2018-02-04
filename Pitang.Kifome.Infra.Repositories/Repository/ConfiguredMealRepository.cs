using Pitang.Kifome.Domain.Contracts.Repositories;
using Pitang.Kifome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.Kifome.Infra.Repositories.Repository
{
    public class ConfiguredMealRepository : EfRepository<ConfiguredMeal, int>, IConfiguredMealRepository
    {
        public ConfiguredMealRepository(DbContext context) : base(context)
        {
        }

        public IList<ConfiguredMeal> SelectConfiguredMealByOrderId(int orderId, params Expression<Func<ConfiguredMeal, object>>[] includes)
        {
            var result = from configurated in this.Table
                         where configurated.OrderId == orderId
                         select configurated;

            foreach (var include in includes)
            {
                result = result.Include(include);
            }

            return result.ToList();
        }
    }
}
