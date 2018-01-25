using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.Kifome.Application.Entities
{
    public class MenuOutputDTO
    {
        public int LimitOfMeals { get; set; }
        public string InitialTimeToOrder { get; set; }
        public string FinalTimeToOrder { get; set; }
        public IList<string> MealsNames { get; set; }
        public string SellerName { get; set; }
    }
}
