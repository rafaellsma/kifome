using System.ComponentModel.DataAnnotations;

namespace Pitang.Kifome.Application.Entities.Comment
{
    public class CommentInputFromBodyDTO
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
