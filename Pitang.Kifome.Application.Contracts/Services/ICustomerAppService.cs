using Pitang.Kifome.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.Kifome.Application.Contracts.Services
{
    public interface ICustomerAppService
    {
        void MakeOrder(OrderInputDTO order);
        void UpdateOrder(OrderInputDTO order);
        void DeleteOrder(int orderId);
        OrderOutputDTO GetOrderById(int orderId);
        UserOutputDTO SearchSellerByLocal(double latitude, double longitude);
        UserOutputDTO SearchSellerByName(string name);
        UserOutputDTO SearchSellerByPrice(float price);
        void SellerEvaluation(float rate);

        //IList<OrderOutputDTO> GetOrders();
        IList<OrderOutputDTO> GetOrders();
    }
}
