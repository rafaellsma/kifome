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
    public class SellerService : ISellerService
    {
        private readonly IUnitOfWork unitOfWork;

        public SellerService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AcceptRequest(Order order)
        {
            throw new NotImplementedException();
        }

        public void RegisterDelivery(Withdrawal delivery)
        {
            throw new NotImplementedException();
        }

        public void RegisterGarnish(Garnish garnish)
        {
            unitOfWork.GarnishRepository.Insert(garnish);
        }

        public void RegisterMeal(Meal meal)
        {
            throw new NotImplementedException();
        }

        public void RegisterMenu(Menu menu)
        {
            unitOfWork.MenuRepository.Insert(menu);
        }

        public IList<Garnish> GetGarnishes()
        {
            return unitOfWork.GarnishRepository.SelectAll();
        }
    }
}
