using Pitang.Kifome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.Kifome.Domain.Contracts.Services
{
    public interface ICustomerService
    {
        Order MakeOrder(User seller, List<Meal> meals, Delivery local);
        User SearchSellerByPrice(float price);
        User SearchSellerByName(string name);
        User SearchSellerByLocal(double latitude, double longitude);
        void SellerEvaluation(int rate);
        void CancelOrder(Order order);
        void EditOrder(Order order);
    }
}
