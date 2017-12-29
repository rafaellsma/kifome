using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pitang.Kifome.Domain.Entities
{
    public class Conversation
    {
        public Order Order { get; set; }
        public List<Comment> Comments { get; set; }
    }
}