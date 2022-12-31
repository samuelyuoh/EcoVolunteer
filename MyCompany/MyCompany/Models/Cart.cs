using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCompany.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        [Required, Column(TypeName = "decimal(7,2)")]
        public decimal Total { get; set; } = 0;

        //temporary user db
        [ForeignKey("Employee")]
        public int UserId { get; set; } = 0;
    }
}
