using System;
using System.Collections.Generic;
using System.Data.Entity;
using Pitang.Kifome.Domain.Contracts.Repositories;
using Pitang.Kifome.Domain.Entities;

namespace Pitang.Kifome.Infra.Repositories.Repository
{
    public class MealRepository : EfRepository<Meal, int>,IMealRepository
    {
        public MealRepository(DbContext context) : base(context)
        {
        }
    }
}
