using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pitang.Kifome.Domain.Entities
{
    public abstract class BaseEntity<TId> : IBaseEntity<TId>
        where TId : IComparable<TId>, IEquatable<TId>
    {
        public TId Id { get; set; }
    }
}