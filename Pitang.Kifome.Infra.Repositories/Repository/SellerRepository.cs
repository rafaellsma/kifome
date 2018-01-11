using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using Pitang.Kifome.Domain.Contracts.Repositories;
using Pitang.Kifome.Domain.Entities;

namespace Pitang.Kifome.Infra.Repositories.Repository
{
    public class SellerRepository : UserRepository<Seller>, ISellerRepository
    {
        public SellerRepository(DbContext context) : base(context)
        {
        }

        public List<Seller> SelectByName(string name)
        {
            var result = from seller in this.Table
                         where seller.Name == name
                         select seller;
            return result.ToList();
        }

        public List<Seller> SelectByPrice(float price)
        {
            var result = from seller in this.Table
                join menu in Context.Set<Menu>() on seller.Id equals menu.Seller.Id
                join meal in Context.Set<Meal>() on menu.Id equals meal.Menu.Id
                where meal.Price <= price
                select seller;
            return result.ToList();
        }

        public List<Seller> SelectByRate(int rate)
        {
            var result = from seller in this.Table
                         where seller.Rate == rate
                         select seller;
            return result.ToList();
        }
    }
}
