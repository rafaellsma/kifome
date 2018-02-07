using System.ComponentModel.DataAnnotations;

namespace Pitang.Kifome.Application.Entities.Garnish
{
    public class GarnishWithSellerDTO : GarnishInputDTO
    {
        [Required]
        public int SellerId { get; set; }
    }
}
