using Pitang.Kifome.Domain.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pitang.Kifome.Domain.Entities;
using Pitang.Kifome.Domain.Contracts.Repositories;

namespace Pitang.Kifome.Domain.Services.Implementation
{
    public class SellerService : ISellerService
    {
        private readonly IUnitOfWork unitOfWork;

        public SellerService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        #region Order
        public void AcceptRequest(Order order)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Withdrawal
        public void RegisterWithdrawal(Withdrawal withdrawal)
        {
            unitOfWork.WithdrawalRepository.Insert(withdrawal);
        }

        public IList<Withdrawal> GetWithdrawals()
        {
            return unitOfWork.WithdrawalRepository.SelectAll();
        }

        public IList<Withdrawal> GetWithdrawalsBySellerId(int id)
        {
            return unitOfWork.WithdrawalRepository.SelectBySellerId(id);
        }

        public Withdrawal GetWithdrawalById(int id)
        {
            return unitOfWork.WithdrawalRepository.SelectById(id);
        }

        public void UpdateWithdrawal(Withdrawal withdrawal)
        {
            unitOfWork.WithdrawalRepository.Update(withdrawal);
        }

        public void DeleteWithdrawal(int id)
        {
            Withdrawal withdrawal = unitOfWork.WithdrawalRepository.SelectById(id);
            unitOfWork.WithdrawalRepository.Delete(withdrawal);
        }
        #endregion
        #region Garnish
        public void RegisterGarnish(Garnish garnish)
        {
            unitOfWork.GarnishRepository.Insert(garnish);
        }

        public IList<Garnish> GetGarnishes()
        {
            return unitOfWork.GarnishRepository.SelectAll();
        }
        #endregion
        #region Meal
        public void RegisterMeal(Meal meal)
        {
            unitOfWork.MealRepository.InsertMeal(meal);            
        }

        public IList<Meal> GetMeals()
        {
            return this.unitOfWork.MealRepository.SelectAll();
        }

        public IList<Meal> GetMealsByMenuId(int id)
        {
            return unitOfWork.MealRepository.SelectMealByMenuId(id);
        }

        public Meal GetMealById(int Id)
        {
            return this.unitOfWork.MealRepository.SelectById(Id);
        }

        public Meal GetMealByFilters()
        {
            throw new NotImplementedException();
        }

        public void UpdateMeal(Meal meal)
        {
            this.unitOfWork.MealRepository.UpdateMeal(meal);
        }

        public void DeleteMeal(int Id)
        {
            var meal = this.unitOfWork.MealRepository.SelectById(Id);
            if(meal != null)
            {
                this.unitOfWork.MealRepository.Delete(meal);
            }
        }
        #endregion
        #region Menu
        public void RegisterMenu(Menu menu)
        {
            unitOfWork.MenuRepository.Insert(menu);
        }

        public Menu GetMenuBySellerId(int id)
        {
            return unitOfWork.MenuRepository.SelectById(id);
        }

        public void UpdateMenu(Menu menu)
        {
            unitOfWork.MenuRepository.Update(menu);
        }
        #endregion
    }
}
