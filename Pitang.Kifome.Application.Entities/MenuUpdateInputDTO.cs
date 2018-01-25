using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.Kifome.Application.Entities
{
    public class MenuUpdateInputDTO
    {
        public int LimitOfMeals { get; set; }
        public string InitialTimeToOrder { get; set; }
        public string FinalTimeToOrder { get; set; }
        [Required]
        public int SellerId { get; set; }
    }
}
