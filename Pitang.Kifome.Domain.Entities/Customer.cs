﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pitang.Kifome.Domain.Entities
{
    public class Customer : Person
    {
        public List<Order> Orders { get; set; }
    }
}