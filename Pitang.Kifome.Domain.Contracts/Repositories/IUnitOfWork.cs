﻿using Pitang.Kifome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.Kifome.Domain.Contracts.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Garnish, int> GarnishRepository { get; }
    }
}