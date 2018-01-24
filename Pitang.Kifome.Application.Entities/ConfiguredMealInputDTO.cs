using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.Kifome.Application.Entities
{
    public class ConfiguredMealInputDTO
    {
        //public int OrderId { get; set; }
        public OrderInputDTO Order { get; set; }
        //public int MealId { get; set; }
        public MealOutputDTO Meal { get; set; }
        //public IList<GarnishInputDTO> SelectedGarnishes { get; set; }
    }
}
