using System;
using System.Collections.Generic;
using Pitang.Kifome.Domain.Contracts.Repositories;
using Pitang.Kifome.Domain.Entities;

namespace Pitang.Kifome.Infra.Repositories.Repository
{
    public class UserRepository : IUserRepository
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(User entity)
        {
            throw new NotImplementedException();
        }

        public User Select(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> SelectAll()
        {
            throw new NotImplementedException();
        }
        public User SelectByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
