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
    public class SellerService : UserService<Seller>, ISellerService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IDeliveryRepository deliveryRepository;
        private readonly IMealRepository mealRepository;
        private readonly IMenuRepository menuRepository;

        public SellerService(IUserRepository<Seller, int> userRepository, 
            IOrderRepository orderRepository, 
            IDeliveryRepository deliveryRepository, 
            IMealRepository mealRepository, 
            IMenuRepository menuRepository) 
            : base(userRepository, orderRepository)
        {
            this.orderRepository = orderRepository;
            this.deliveryRepository = deliveryRepository;
            this.mealRepository = mealRepository;
            this.menuRepository = menuRepository;
        }

        public void AcceptRequest(Order order)
        {
            order.Status = OrderStatusEnum.Accepted;
            orderRepository.Insert(order);
        }

        public List<Order> OrdersFromSeller(int id)
        {
            return orderRepository.SelectAllBySellerId(id);
        }

        public void RegisterDelivery(string local, double latitude, double longitude, DateTime initialHour, DateTime finalHour)
        {
            Delivery delivery = new Delivery()
            {
                Local = local,
                Latitude = latitude,
                Longitude = longitude,
                InitialHour = initialHour,
                FinalHour = finalHour
            };
            deliveryRepository.Insert(delivery);
        }

        public void RegisterGarnish(string name, string description)
        {
            throw new NotImplementedException();
        }

        public void RegisterMeal(string name, string description, float price, DayOfWeek days, List<Garnish> garnishies)
        {
            Meal meal = new Meal()
            {
                Name = name,
                Description = description,
                Price = price,
                Days = days,
                Garnishies = garnishies
            };
            mealRepository.Insert(meal);
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
            menuRepository.Insert(menu);
        }
    }
}
