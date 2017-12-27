using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pitang.Kifome.Domain.Entities
{
    public class Garnish
    {
        public Meal Meal { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }
    }
}