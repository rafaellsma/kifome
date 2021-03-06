﻿using Pitang.Kifome.Domain.Contracts.Repositories;
using Pitang.Kifome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.Kifome.Infra.Repositories.Repository
{
    public class EfRepository<T, TId> : IRepository<T, TId>
        where T : class, IBaseEntity<TId>, new()
        where TId : IComparable<TId>, IEquatable<TId>
    {
        protected DbContext Context { get; }
        protected DbSet<T> Table => Context.Set<T>();

        public EfRepository(DbContext context)
        {
            this.Context = context;
        }

        public void Delete(T entity)
        {
            this.Context.Set<T>().Remove(entity);
            this.Context.SaveChanges();
        }

        public void Insert(T entity)
        {
            this.Context.Set<T>().Add(entity);
            this.Context.SaveChanges();
        }

        public T SelectById(TId id, params Expression<Func<T, object>>[] includes)
        {
            var result = from entity in Context.Set<T>()
                         where entity.Id.Equals(id)
                         select entity;

            foreach (var include in includes)
            {
                result = result.Include(include);
            }
            return result.SingleOrDefault();
        }

        public List<T> SelectAll(params Expression<Func<T, object>>[] includes)
        {
            var result = from entity in Context.Set<T>()
                         select entity;

            foreach(var include in includes)
            {
                result = result.Include(include);
            }

            return result.ToList();
        }

        public void Update(T entity)
        {
            var local = (from entry in Context.Set<T>()
                         where entry.Id.Equals(entity.Id)
                         select entry).SingleOrDefault();

            Context.Entry(local).State = EntityState.Detached;
            Context.Set<T>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            this.Context.SaveChanges();
        }

    }
}
