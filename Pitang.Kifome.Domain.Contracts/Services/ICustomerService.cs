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
        Order MakeOrder(Seller seller, Customer customer, List<Meal> meals, Delivery delivery);
        List<Seller> SearchSellerByPrice(float price);
        List<Seller> SearchSellerByName(string name);
        List<Seller> SearchSellerByLocal(double latitude, double longitude);
        List<Seller> SearchSellerByRate(int rate);
        void SellerEvaluation(Seller seller,int rate);
        void CancelOrder(Order order);
        void EditOrder(Order order);
        List<Order> OrdersFromUser(int id);
    }
}
