using Pitang.Kifome.Domain.Contracts.Repositories;
using Pitang.Kifome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.Kifome.Infra.Repositories.Repository
{
    public class UserRepository<T, TId> : EfRepository<T, TId>, IUserRepository<T, TId>
        where T : User, IBaseEntity<TId>, new()
        where TId : IComparable<TId>, IEquatable<TId>
    {
        public UserRepository(DbContext context) : base(context)
        {

        }
        public T SelectByEmail(string email)
        {
            var result = from user in this.Table
                         where user.Email == email
                         select user;
            return result.SingleOrDefault();
        }
    }
}
