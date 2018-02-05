using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.Kifome.Application.Entities.Comment
{
    public class CommentOutputDTO
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
