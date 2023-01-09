using System.ComponentModel.DataAnnotations;

namespace MyCompany.Models
{
    public class Organiser
    {
        [Key]
        public int OrganiserId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public int EventId { get; set; }

        [Required]
        // can be main organiser or co-organiser
        public string OrganiserRole { get; set; }

        public Event? Event { get; set; }

        public User? User { get; set; }
    }
}
