using Pitang.Kifome.Domain.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pitang.Kifome.Domain.Contracts.Repositories;
using Pitang.Kifome.Domain.Entities;

namespace Pitang.Kifome.Domain.Services.Implementation
{
    public class CustomerService : UserService<Customer>, ICustomerService
    {
        private readonly IOrderRepository orderRepository;
        private readonly ISellerRepository sellerRepository;

        public CustomerService(IUserRepository<Customer, int> userRepository, 
            IOrderRepository orderRepository,
            ISellerRepository sellerRepository) 
            : base(userRepository, orderRepository)
        {
            this.orderRepository = orderRepository;
            this.sellerRepository = sellerRepository;
        }

        public void CancelOrder(Order order)
        {
            order.Status = OrderStatusEnum.Canceled;
            orderRepository.Update(order);
        }

        public void EditOrder(Order order)
        {
            orderRepository.Update(order);
        }

        public Order MakeOrder(Seller seller, Customer customer, List<Meal> meals, Delivery delivery)
        {
            Order order = new Order()
            {
                Seller = seller,
                Customer = customer,
                Meals = meals,
                Delivery = delivery,
                Status = OrderStatusEnum.Waiting
            };
            orderRepository.Insert(order);
            return orderRepository.SelectById(order.Id);
        }

        public List<Order> OrdersFromUser(int id)
        {
            return orderRepository.SelectAllByCustomerId(id);
        }

        public List<Seller> SearchSellerByLocal(double latitude, double longitude)
        {
            throw new NotImplementedException();
        }

        public List<Seller> SearchSellerByName(string name)
        {
            return sellerRepository.SelectByName(name);
        }

        public List<Seller> SearchSellerByPrice(float price)
        {
            return sellerRepository.SelectByPrice(price);
        }

        public List<Seller> SearchSellerByRate(int rate)
        {
            return sellerRepository.SelectByRate(rate);
        }

        public void SellerEvaluation(Seller seller, int rate)
        {
            seller.Rate = rate;
            sellerRepository.Update(seller);
        }
    }
}
