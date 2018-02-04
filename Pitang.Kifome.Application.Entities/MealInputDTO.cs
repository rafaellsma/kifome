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
        public double Price { get; set; }
        [Required]
        public int MenuId { get; set; }
        [Required]
        public IList<int> GarnishiesId { get; set; }
        [Required]
        public DayOfWeek Days { get; set; }

    }
}
