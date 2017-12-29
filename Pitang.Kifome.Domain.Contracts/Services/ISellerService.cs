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
        void RegisterGarnish(string name, string description);
        void RegisterMeal(string name, string description, float price, List<DayOfWeek> days, List<Garnish> garnishies);
        void RegisterMenu(List<Meal> meals, DateTime initialHour, DateTime finalHour, int limitOfMeals);
        void RegisterDelivery(string local, DateTime initialHour, DateTime finalHour);
        void AcceptRequest(Order order);
    }
}
