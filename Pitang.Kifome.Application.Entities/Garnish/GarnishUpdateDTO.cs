using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.Kifome.Application.Entities
{
    public class GarnishUpdateDTO : GarnishInputDTO
    {
        [Required]
        public int Id;
    }
}
