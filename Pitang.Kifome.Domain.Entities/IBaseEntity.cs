using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.Kifome.Domain.Entities
{
    public interface IBaseEntity<TId>
        where TId:IComparable<TId>, IEquatable<TId>
    {
        TId Id { get; set; }
    }
}
