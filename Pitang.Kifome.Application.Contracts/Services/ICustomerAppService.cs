using Pitang.Kifome.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pitang.Kifome.Application.Entities.ConfiguratedMeal;

namespace Pitang.Kifome.Application.Contracts.Services
{
    public interface ICustomerAppService
    {
        #region Order
        void MakeOrder(OrderInputDTO order);
        void UpdateOrder(OrderUpdateInputDTO order);
        void DeleteOrder(int orderId);
        OrderOutputDTO GetOrderById(int orderId);
        IList<OrderOutputDTO> GetOrders();
        #endregion

        #region Seller
        UserOutputDTO SearchSellerByLocal(double latitude, double longitude);
        UserOutputDTO SearchSellerByName(string name);
        UserOutputDTO SearchSellerByPrice(float price);
        void SellerEvaluation(float rate);
        #endregion

        #region ConfiguratedMeal
        void MakeConfiguratedMeal(ConfiguredMealInputDTO configuredMeal);
        IList<ConfiguratedMealOutputDTO> GetConfiguratedMealsByOrderId(int orderId);
        #endregion
    }
}
