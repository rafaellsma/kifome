using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Pitang.Kifome.Domain.Contracts.Repositories;
using Pitang.Kifome.Domain.Entities;

namespace Pitang.Kifome.Infra.Repositories.Repository
{
    public class MenuRepository : EfRepository<Menu, int>,IMenuRepository
    {
        public MenuRepository(DbContext context) : base(context)
        {
        }
    }
}
