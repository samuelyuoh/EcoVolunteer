using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCompany.Models
{
    public class CartItem
    {
        [Key]
        public int CartItemId { get; set; }
        [ForeignKey("Cart")]
        public int CartId { get; set; }
        //[Required, ForeignKey("Product")]
        [Required]
        public int ProductId { get; set; } = 1;
        [Required]
        public int Quantity { get; set; } = 1;



    }
}
