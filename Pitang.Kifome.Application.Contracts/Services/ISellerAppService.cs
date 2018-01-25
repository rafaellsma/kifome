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
        #region Garnish
        void RegisterGarnish(GarnishInputDTO garnish);
        void UpdateGarnish(GarnishInputDTO garnish);
        void DeleteGarnish(int id);
        #endregion
        #region Withdrawal
        void RegisterWithdrawal(WithdrawalInputDTO withdrawal);
        IList<WithdrawalOutputDTO> GetWithdrawals();
        IList<WithdrawalOutputDTO> GetWithdrawalsBySellerId(int id);
        WithdrawalOutputDTO GetWithdrawalById(int id);
        void UpdateWithdrawal(WithdrawalUpdateInputDTO withdrawal);
        void DeleteWithdrawal(int id);
        #endregion
        #region Meal
        void RegisterMeal(MealInputDTO meal);
        IList<MealOutputDTO> GetMeals();
        MealOutputDTO GetMealById(int Id);
        IList<MealOutputDTO> GetMealByFilters(MealFiltersDTO mealFilters);
        void UpdateMeal(MealInputDTO meal);
        void DeleteMeal(int Id);
        #endregion
        #region Menu
        void RegisterMenu(MenuInputDTO menu);
        MenuOutputDTO GetMenuBySellerId(int id);
        void UpdateMenu(MenuUpdateInputDTO menu);
        #endregion

    }
}
