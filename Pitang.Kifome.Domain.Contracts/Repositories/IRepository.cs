using Pitang.Kifome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.Kifome.Domain.Contracts.Repositories
{
    public interface IRepository<T, TId>
        where T : class, IBaseEntity<TId>
        where TId : IComparable<TId>, IEquatable<TId>
    {
        void Insert(T entity);
        void Update(T entity);
        T SelectById(TId id, params Expression<Func<T, object>>[] includes);
        List<T> SelectAll(params Expression<Func<T, object>>[] includes);
        void Delete(T entity);
    }
}
