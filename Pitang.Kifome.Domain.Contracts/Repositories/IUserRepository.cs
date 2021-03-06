﻿using Pitang.Kifome.Domain.Entities;
 using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Text;
 using System.Threading.Tasks;
 
 namespace Pitang.Kifome.Domain.Contracts.Repositories
 {
    
    public interface IUserRepository : IRepository<User, int>
    {
         User SelectByEmail(string email);

        IList<User> SelectAllSellers();
    }
 }