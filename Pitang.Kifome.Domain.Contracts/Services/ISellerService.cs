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
        void RegisterGarnish(Garnish garnish);
        void RegisterMeal(Meal meal);
        void RegisterMenu(Menu menu);
        void RegisterDelivery(Delivery delivery);
        void AcceptRequest(Order order);
        IList<Garnish> GetGarnishes();
    }
}
