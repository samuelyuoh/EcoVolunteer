using System.ComponentModel.DataAnnotations;

namespace MyCompany.Models
{
    public class Session
    {
        [Key]
        public int SessionId { get; set; }

        [Required]
        public string Timing { get; set; } = string.Empty;

        [Required]
        public int Capacity { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int EventId { get; set; }

        public Event? Event { get; set; }

        public User? User { get; set; }
    }
}
