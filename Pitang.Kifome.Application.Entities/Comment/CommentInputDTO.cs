using System.ComponentModel.DataAnnotations;

namespace Pitang.Kifome.Application.Entities.Comment
{
    public class CommentInputDTO : CommentInputFromBodyDTO
    {
        [Required]
        public int OrderId { get; set; }
    }
}