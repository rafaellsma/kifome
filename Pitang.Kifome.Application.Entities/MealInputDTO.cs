﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.Kifome.Application.Entities
{
    public class MealInputDTO
    {
        [Required]
        public String Name { get; set; }
        [Required]
        public String Description { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public int MenuId { get; set; }
        //Optional
        //public IList<GarnishInputDTO> Garnishies { get; set; }
        [Required]
        public DayOfWeek Days { get; set; }

    }
}

//public string Name { get; set; }
//public string Description { get; set; }
//public float Price { get; set; }
//public Menu Menu { get; set; }
//public IList<Garnish> Garnishies { get; set; }
//public IList<ConfiguredMeal> ConfiguredMeals { get; set; }
//public DayOfWeek Days { get; set; }