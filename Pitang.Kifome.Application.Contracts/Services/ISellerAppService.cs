using Pitang.Kifome.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.Kifome.Application.Contracts.Services
{
    public interface ISellerAppService
    {
        void RegisterGarnish(GarnishInputDTO garnish);
        IList<GarnishOutputDTO> GetGarnishes();
        void RegisterWithdrawal(WithdrawalInputDTO withdrawal);
        void RegisterMeal(MealInputDTO meal);
        IList<MealOutputDTO> GetMeals();
        MealOutputDTO GetMealById(int Id);
        IList<MealOutputDTO> GetMealByFilters(MealFiltersDTO mealFilters);
        void UpdateMeal(MealInputDTO meal);
        void DeleteMeal(int Id);
        void RegisterMenu(MenuInputDTO menu);

    }
}
