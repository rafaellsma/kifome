﻿using Pitang.Kifome.Application.Entities.ConfiguratedMeal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.Kifome.Application.Entities
{
    public class OrderOutputDTO
    {
        public int Id { get; set; }
        public UserOutputDTO Seller { get; set; }
        public UserOutputDTO Customer { get; set; }
        public WithdrawalInputDTO Withdrawal { get; set; }
        public IList<ConfiguratedMealDTO> ConfiguredMeals { get; set; }
        public OrderStatusEnumDTO Status { get; set; }
    }
}
