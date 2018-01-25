using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Pitang.Kifome.Domain.Contracts.Repositories;
using Pitang.Kifome.Domain.Entities;

namespace Pitang.Kifome.Infra.Repositories.Repository
{
    public class MealRepository : EfRepository<Meal, int>,IMealRepository
    {
        public MealRepository(DbContext context) : base(context)
        {
        }

        public Meal SelectConfiguredMealWithGarnishies()
        {
            throw new NotImplementedException();
        }

        public IList<Meal> SelectMealByMenuId(int menuId)
        {
            var result = from meal in this.Table
                         where meal.MenuId == menuId
                         select meal;
            return result.ToList();
        }
    }
}
