using Pitang.Kifome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.Kifome.Domain.Contracts.Services
{
    public interface IUserService<T, TId>
        where T : class, IBaseEntity<TId>, new()
        where TId : IComparable<TId>, IEquatable<TId>
    {
        bool Authenticate(string email, string password);
        void CreateUser(T user);
        void MakeComment(T user, Order order, string mensage);
    }
}
