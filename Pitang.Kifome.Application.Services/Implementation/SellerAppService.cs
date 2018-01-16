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
    }
}
