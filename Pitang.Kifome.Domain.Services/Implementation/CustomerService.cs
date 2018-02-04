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
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork unitOfWork;
        public CustomerService(IUnitOfWork unitOfWorkInstance)
        {
            this.unitOfWork = unitOfWorkInstance;
        }
        public void CancelOrder(int orderId)
        {
            var order = this.unitOfWork.OrderRepository.SelectById(orderId);
            if(order != null)
            {
                this.unitOfWork.OrderRepository.Delete(order);
            }
        }

        public void EditOrder(Order order)
        {
            this.unitOfWork.OrderRepository.Update(order);
        }

        public Order GetOrderById(int Id)
        {
            return this.unitOfWork.OrderRepository.SelectById(Id, c => c.Customer, s => s.Seller, w => w.Withdrawal, co => co.ConfiguredMeals.Select(m => m.Meal), co => co.ConfiguredMeals.Select(g => g.SelectedGarnishes));
        }

        public IList<Order> GetOrders()
        {
            return this.unitOfWork.OrderRepository.SelectAll(c => c.Customer, s => s.Seller, w => w.Withdrawal, co => co.ConfiguredMeals.Select(m => m.Meal), co => co.ConfiguredMeals.Select(g => g.SelectedGarnishes));
        }

        public void MakeOrder(Order order)
        {
            this.unitOfWork.OrderRepository.Insert(order);
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

        public void SellerEvaluation(float rate)
        {
            throw new NotImplementedException();
        }
    }
}
