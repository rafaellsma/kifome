﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.Kifome.Application.Entities
{
    public class MealOutputDTO : MealDTO
    {
        public IList<string> GarnishiesName { get; set; }
    }
}
