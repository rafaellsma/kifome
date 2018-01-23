using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.Kifome.Application.Entities
{
    public class WithdrawalUpdateInputDTO
    {
        [Required]
        public int Id { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string CEP { get; set; }
        public string InitailHour { get; set; }
        public string FinalHour { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int SellerId { get; set; }
    }
}
