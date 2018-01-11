using Pitang.Kifome.Domain.Contracts.Repositories;
using Pitang.Kifome.Domain.Entities;
using Pitang.Kifome.Infra.Repositories.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.Kifome.Infra.Repositories.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext context;
        private bool disposed;
        private IRepository<Garnish, int> garnishRepository;

        public IRepository<Garnish, int> GarnishRepository
        {
            get
            {
                if (this.garnishRepository == null)
                {
                    this.garnishRepository = new GarnishRepository(context);
                }
                return this.garnishRepository;
            }
        }
        public UnitOfWork()
        {
            this.context = new Context();
            this.disposed = false;
        }
        private void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            if (disposing)
            {
                context.Dispose();
            }
        }
        public void Dispose()
        {
            Dispose(true);
        }
    }
}
