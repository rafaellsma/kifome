using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.Kifome.Application.Entities.ConfiguratedMeal
{
    public class ConfiguratedMealOutputDTO
    {
        public int OrderId { get; set; }
        public string MealName { get; set; }
        public IList<string> GarnishesNames { get; set; }
    }
}
