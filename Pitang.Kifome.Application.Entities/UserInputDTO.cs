using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.Kifome.Application.Entities
{
    public class UserInputDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [Range(6, 25, ErrorMessage = "A senha deve conter no minimo 6 caracteres e no máximo 25)")]
        public string Password { get; set; }
        public float Rate { get; set; }
        //public IList<Withdrawal> Withdrawals { get; set; }

    }
}
