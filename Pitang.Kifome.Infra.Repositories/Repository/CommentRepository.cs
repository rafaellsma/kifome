using System;
using System.Collections.Generic;
using System.Data.Entity;
using Pitang.Kifome.Domain.Contracts.Repositories;
using Pitang.Kifome.Domain.Entities;

namespace Pitang.Kifome.Infra.Repositories.Repository
{
    public class CommentRepository : EfRepository<Comment,int>,ICommentRepository
    {
        public CommentRepository(DbContext context) : base(context)
        {
        }
    }
}
