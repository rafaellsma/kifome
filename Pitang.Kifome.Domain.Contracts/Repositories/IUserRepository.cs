using Pitang.Kifome.Domain.Entities;
 using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Text;
 using System.Threading.Tasks;
 
 namespace Pitang.Kifome.Domain.Contracts.Repositories
 {
     public interface IUserRepository<T, TId> : IRepository<T, TId>
        where T : class, IBaseEntity<TId>, new()
        where TId : IComparable<TId>, IEquatable<TId>
     {
         T SelectByEmail(string email);
     }
 }