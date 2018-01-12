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
    public class UserRepository<T> : EfRepository<T, int>, IUserRepository<T, int>
        where T : User, IBaseEntity<int>, new()
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
