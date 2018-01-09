using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pitang.Kifome.Domain.Entities
{
    public class Garnish : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Meal> Meals { get; set; }

        public Garnish(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }
    }
}