using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.Kifome.Application.Entities
{
    public class OrderInputDTO
    {
        [Required]
        public int SellerId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int WithdrawalId { get; set; }
    }
}
