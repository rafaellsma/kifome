using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pitang.Kifome.Domain.Entities
{
    public class Meal
    {
        public Order Order { get; set; }

        public Menu Menu { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        public int Price { get; set; }

        public DayOfWeek Day { get; set; }

    }
}