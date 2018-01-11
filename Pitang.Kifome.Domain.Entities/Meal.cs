using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pitang.Kifome.Domain.Entities
{
    public class Meal : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public Menu Menu { get; set; }
        public IList<Garnish> Garnishies { get; set; }
        public IList<Order> Orders { get; set; }
        public DayOfWeek Days { get; set; }
    }
}