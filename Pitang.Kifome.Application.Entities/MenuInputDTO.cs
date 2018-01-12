using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.Kifome.Application.Entities
{
    public class MenuInputDTO
    {
        [Required]
        public int LimitOfMeals { get; set; }
        [Required]
        public DateTime InitialTimeToOrder { get; set; }
        [Required]
        public DateTime FinalTimeToOrder { get; set; }
    }
}
