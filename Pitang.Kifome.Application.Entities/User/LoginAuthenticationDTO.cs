using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pitang.Kifome.Application.Entities
{
    public class LoginAuthenticationDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(25, MinimumLength = 6, ErrorMessage = "A senha deve conter no minimo 6 caracteres e no máximo 25)")]
        public string Password { get; set; }

    }
}
