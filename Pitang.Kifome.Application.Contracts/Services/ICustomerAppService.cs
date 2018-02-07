using Pitang.Kifome.Application.Entities;
using System.Collections.Generic;
using Pitang.Kifome.Application.Entities.ConfiguratedMeal;
using Pitang.Kifome.Application.Entities.User;

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
        IList<SellerOutputDTO> GetAllSellers();
        #endregion

        #region ConfiguratedMeal
        void MakeConfiguratedMeal(ConfiguredMealInputDTO configuredMeal);
        IList<ConfiguratedMealOutputDTO> GetConfiguratedMealsByOrderId(int orderId);
        #endregion
    }
}
