using System;
using System.Collections.Generic;
using System.Data.Entity;
using Pitang.Kifome.Domain.Contracts.Repositories;
using Pitang.Kifome.Domain.Entities;
using Pitang.Kifome.Infra.Repositories.Mapping;

namespace Pitang.Kifome.Infra.Repositories.Repository
{
    public class GarnishRepository : EfRepository<Garnish, int>, IGarnishRepository
    {
        public GarnishRepository(DbContext context) : base(context)
        {
        }
    }
}
