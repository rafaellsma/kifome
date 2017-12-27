using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pitang.Kifome.Domain.Entities
{
    public class Menu
    {
        public Seller Seller { get; set; }

        public DateTime InitialHour { get; set; }

        public DateTime FinalHour { get; set; }

        public int LimitOfMeals { get; set; }
    }
}