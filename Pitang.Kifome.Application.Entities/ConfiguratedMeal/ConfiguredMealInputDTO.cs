using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.Kifome.Application.Entities
{
    public class ConfiguredMealInputDTO
    {
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int MealId { get; set; }
        [Required]
        public IList<int> GarnishesId { get; set; }
    }
}
