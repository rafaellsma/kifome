﻿using Pitang.Kifome.Domain.Contracts.Services;
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

        public void AcceptRequest(Order order)
        {
            throw new NotImplementedException();
        }

        public void RegisterWithdrawal(Withdrawal withdrawal)
        {
            unitOfWork.WithdrawalRepository.Insert(withdrawal);
        }

        public void RegisterGarnish(Garnish garnish)
        {
            unitOfWork.GarnishRepository.Insert(garnish);
        }

        public void RegisterMeal(Meal meal)
        {
            unitOfWork.MealRepository.Insert(meal);
        }

        public void RegisterMenu(Menu menu)
        {
            unitOfWork.MenuRepository.Insert(menu);
        }

        public IList<Garnish> GetGarnishes()
        {
            return unitOfWork.GarnishRepository.SelectAll();
        }

        public IList<Meal> GetMeals()
        {
            return this.unitOfWork.MealRepository.SelectAll();
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
            this.unitOfWork.MealRepository.Update(meal);
        }

        public void DeleteMeal(int Id)
        {
            var meal = this.unitOfWork.MealRepository.SelectById(Id);
            if(meal != null)
            {
                this.unitOfWork.MealRepository.Delete(meal);
            }
        }
    }
}
