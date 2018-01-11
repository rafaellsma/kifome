using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pitang.Kifome.Domain.Entities
{
    public class Comment : BaseEntity<int>
    {
        public User User { get; set; }
        public Order Order { get; set; }
        public string Message { get; set; }
    }
}