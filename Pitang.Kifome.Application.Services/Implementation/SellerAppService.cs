using Pitang.Kifome.Application.Contracts.Services;
using Pitang.Kifome.Application.Entities;
using Pitang.Kifome.Domain.Contracts.Services;
using Pitang.Kifome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.Kifome.Application.Services.Implementation
{
    public class SellerAppService : ISellerAppService
    {
        private readonly ISellerService sellerService;
        public SellerAppService(ISellerService sellerService)
        {
            this.sellerService = sellerService;
        }

        public IList<GarnishOutputDTO> GetGarnishes()
        {
            var garnishes = sellerService.GetGarnishes();
            IList<GarnishOutputDTO> garnishesOutput = new List<GarnishOutputDTO>();
            foreach (var garnish in garnishes)
            {
                garnishesOutput.Add(new GarnishOutputDTO()
                {
                    Name = garnish.Name,
                    Description = garnish.Description
                });
            }
            return garnishesOutput;

        }

        public void RegisterGarnish(GarnishInputDTO garnish)
        {
            sellerService.RegisterGarnish(new Garnish
            {
                Name = garnish.Name,
                Description = garnish.Description
            });
        }

        public void RegisterMenu(MenuInputDTO menu)
        {
            sellerService.RegisterMenu(new Menu
            {
                LimitOfMeals = menu.LimitOfMeals,
                InitialHour = Convert.ToDateTime(menu.InitialTimeToOrder),
                FinalHour = Convert.ToDateTime(menu.FinalTimeToOrder),
                SellerId = menu.SellerId,
                Id = menu.SellerId
            });
        }

        public void RegisterWithdrawal(WithdrawalInputDTO withdrawal)
        {
            sellerService.RegisterWithdrawal(new Withdrawal
            {
                Street = withdrawal.Street,
                Number = withdrawal.Number,
                CEP = withdrawal.CEP,
                InitialHour = Convert.ToDateTime(withdrawal.InitailHour),
                FinalHour = Convert.ToDateTime(withdrawal.FinalHour),
                Latitude = withdrawal.Latitude,
                Longitude = withdrawal.Longitude,
                SellerId = withdrawal.SellerId
            });
        }
    }
}
