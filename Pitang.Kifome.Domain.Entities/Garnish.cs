﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pitang.Kifome.Domain.Entities
{
    public class Garnish : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<Meal> Meals { get; set; }
        public IList<ConfiguredMeal> ConfiguredMeals { get; set; }
        public User Seller { get; set; }
        public int SellerId { get; set; }
    }
}