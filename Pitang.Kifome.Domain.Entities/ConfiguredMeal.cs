﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.Kifome.Domain.Entities
{
    public class ConfiguredMeal : BaseEntity<int>
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int MealId { get; set; }
        public Meal Meal { get; set; }
        public IList<Garnish> SelectedGarnishes { get; set; }
    }
}
