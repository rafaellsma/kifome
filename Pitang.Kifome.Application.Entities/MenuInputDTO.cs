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
        public string InitialTimeToOrder { get; set; }
        [Required]
        public string FinalTimeToOrder { get; set; }
        [Required]
        public int SellerId { get; set; }
    }
}
