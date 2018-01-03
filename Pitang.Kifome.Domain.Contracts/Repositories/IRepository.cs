﻿using Pitang.Kifome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.Kifome.Domain.Contracts.Repositories
{
    public interface IRepository<T, TId>
        where T : class, IBaseEntity<TId>, new()
        where TId : IComparable<TId>, IEquatable<TId>
    {
        void Insert(T entity);
        void Update(T entity);
        T Select(TId id);
        List<T> SelectAll();
        void Delete(TId id);
    }
}