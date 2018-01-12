using Pitang.Kifome.Domain.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pitang.Kifome.Domain.Entities;

namespace Pitang.Kifome.Domain.Services.Implementation
{
    public class CustomerService : ICustomerService
    {
        public void CancelOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public void EditOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public Order MakeOrder(User seller, List<Meal> meals, Delivery local)
        {
            throw new NotImplementedException();
        }

        public User SearchSellerByLocal(double latitude, double longitude)
        {
            throw new NotImplementedException();
        }

        public User SearchSellerByName(string name)
        {
            throw new NotImplementedException();
        }

        public User SearchSellerByPrice(float price)
        {
            throw new NotImplementedException();
        }

        public void SellerEvaluation(int rate)
        {
            throw new NotImplementedException();
        }
    }
}
