using Pitang.Kifome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.Kifome.Domain.Contracts.Services
{
    public interface ISellerService
    {
        #region Garnish
        void RegisterGarnish(Garnish garnish);
        IList<Garnish> GetGarnishes();
        #endregion
        #region Meal
        void RegisterMeal(Meal meal);
        IList<Meal> GetMeals();
        IList<Meal> GetMealsByMenuId(int id); 
        Meal GetMealById(int Id);
        Meal GetMealByFilters();
        void UpdateMeal(Meal meal);
        void DeleteMeal(int Id);
        #endregion
        #region Menu
        void RegisterMenu(Menu menu);
        Menu GetMenuBySellerId(int id);
        void UpdateMenu(Menu menu);
        #endregion
        #region Withdrawal
        void RegisterWithdrawal(Withdrawal withdrawal);
        IList<Withdrawal> GetWithdrawals();
        IList<Withdrawal> GetWithdrawalsBySellerId(int id);
        Withdrawal GetWithdrawalById(int id);
        void UpdateWithdrawal(Withdrawal withdrawal);
        void DeleteWithdrawal(int id);
        #endregion
        #region Order
        void AcceptRequest(Order order);
        #endregion
    }
}
