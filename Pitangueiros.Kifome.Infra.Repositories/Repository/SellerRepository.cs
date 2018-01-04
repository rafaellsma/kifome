using Pitang.Kifome.Domain.Contracts.Repositories;
using Pitang.Kifome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitangueiros.Kifome.Infra.Repositories.Repository
{
    public class SellerRepository : ISellerRepository
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Seller entity)
        {
            throw new NotImplementedException();
        }

        public void InsertMenu(List<Meal> meals, DateTime initialHour, DateTime finalHour, int limitOfMeals)
        {
            throw new NotImplementedException();
        }

        public Seller Select(int id)
        {
            throw new NotImplementedException();
        }

        public List<Seller> SelectAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Seller entity)
        {
            throw new NotImplementedException();
        }
    }
}
