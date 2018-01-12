using Pitang.Kifome.Domain.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pitang.Kifome.Domain.Entities;

namespace Pitang.Kifome.Domain.Services.Implementation
{
    public class SellerService : ISellerService
    {
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
            throw new NotImplementedException();
        }

        public void RegisterMeal(string name, string description, float price, List<DayOfWeek> days, List<Garnish> garnishies)
        {
            throw new NotImplementedException();
        }

        public void RegisterMenu(List<Meal> meals, DateTime initialHour, DateTime finalHour, int limitOfMeals)
        {
            throw new NotImplementedException();
        }
    }
}
