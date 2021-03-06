﻿using Pitang.Kifome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.Kifome.Domain.Contracts.Services
{
    public interface ICustomerService
    {
        #region Order
        void MakeOrder(Order order);
        void CancelOrder(int orderId);
        void EditOrder(Order order);
        Order GetOrderById(int Id);
        IList<Order> GetOrders();
        #endregion

        #region Seller
        User SearchSellerByPrice(float price);
        User SearchSellerByName(string name);
        User SearchSellerByLocal(double latitude, double longitude);
        void SellerEvaluation(float rate);

        IList<User> GetSellers();
        #endregion

        #region ConfiguratedMeal
        void MakeConfiguratedMeal(ConfiguredMeal configuredMeal);
        IList<ConfiguredMeal> GetConfiguredMealByOrderId(int orderId);
        #endregion
    }
}
