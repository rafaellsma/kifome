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

        public void AcceptRequest(Order order)
        {
            throw new NotImplementedException();
        }

        public void RegisterDelivery(string local, DateTime initialHour, DateTime finalHour)
        {
            throw new NotImplementedException();
        }

        public void RegisterGarnish(string name, string description)
        {
            Garnish garnish = new Garnish()
            {
                Name = name,
                Description = description
            };
            unitOfWork.GarnishRepository.Insert(garnish);
        }

        public void RegisterMeal(string name, string description, float price, List<DayOfWeek> days, List<Garnish> garnishies)
        {
            throw new NotImplementedException();
        }

        public void RegisterMenu(List<Meal> meals, DateTime initialHour, DateTime finalHour, int limitOfMeals)
        {
            Menu menu = new Menu()
            {
                Meals = meals,
                InitialHour = initialHour,
                FinalHour = finalHour,
                LimitOfMeals = limitOfMeals
            };
            unitOfWork.MenuRepository.Insert(menu);
        }

        public IList<Garnish> GetGarnishes()
        {
            return unitOfWork.GarnishRepository.SelectAll();
        }
    }
}
