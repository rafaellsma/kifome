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
    public class UserRepository : EfRepository<User, int>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {

        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(User entity)
        {
            throw new NotImplementedException();
        }

        public User SelectByEmail(string email)
        {
            var result = from user in this.Table
                         where user.Email == email
                         select user;
            return result.SingleOrDefault();
        }

        public User SelectById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }

        List<User> IRepository<User, int>.SelectAll()
        {
            throw new NotImplementedException();
        }

        User IUserRepository.SelectByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
