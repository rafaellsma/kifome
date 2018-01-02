﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pitang.Kifome.Domain.Entities
{
    public class Comment : BaseEntity<int>
    {
        public Conversation Conversation { get; set; }
        public Person Person { get; set; }
        public string Message { get; set; }
    }
}