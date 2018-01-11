using Pitang.Kifome.Domain.Contracts.Repositories;
using Pitang.Kifome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.Kifome.Infra.Repositories.Repository
{
    public class UserRepository : EfRepository<User, int>, IUserRepository<User, int>
    {
        public UserRepository(DbContext context) : base(context)
        {

        }
        public User SelectByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
