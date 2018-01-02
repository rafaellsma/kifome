using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pitang.Kifome.Domain.Entities
{
    public class Comment : BaseEntity<int>
    {
        public Person Person { get; set; }
        public string Message { get; set; }

        public Comment(Person person, string message)
        {
            this.Person = person;
            this.Message = message;
        }
    }
}