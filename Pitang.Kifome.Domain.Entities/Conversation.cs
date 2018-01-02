using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pitang.Kifome.Domain.Entities
{
    public class Conversation : BaseEntity<int>
    {
        public List<Comment> Comments { get; set; }
    }
}