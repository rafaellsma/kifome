using Pitang.Kifome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.Kifome.Domain.Contracts.Repositories
{
    public interface ISellerRepository : IUserRepository<Seller, int>
    {
        List<Seller> SelectByRate(int rate);
        List<Seller> SelectByPrice(float price);
        List<Seller> SelectByName(string name);
    }
}
