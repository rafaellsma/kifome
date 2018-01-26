using Pitang.Kifome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.Kifome.Domain.Contracts.Repositories
{
    public interface IMealRepository : IRepository<Meal, int>
    {
        Meal SelectConfiguredMealWithGarnishies();
        IList<Meal> SelectMealByMenuId(int menuId);
        void InsertMeal(Meal meal);
        void UpdateMeal(Meal meal);
    }
}
