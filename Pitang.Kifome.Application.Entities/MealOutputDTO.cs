using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.Kifome.Application.Entities
{
    public class MealOutputDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public IList<GarnishOutputDTO> Garnishies { get; set; }
        public DayOfWeek Days { get; set; }
    }
}
