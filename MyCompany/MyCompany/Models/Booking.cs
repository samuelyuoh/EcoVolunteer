using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCompany.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        [Required]
        public int SessionId { get; set; } = 0;

        [Required, ForeignKey("User")]
        public string UserId { get; set; }

        [Required]
        public int EventId { get; set; } = 0;

        public Event? Event { get; set; }

        public User? User { get; set; }
       
        //public Session? Session { get; set; } 


    }
}
