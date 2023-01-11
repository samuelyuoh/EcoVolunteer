using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCompany.Models
{
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventId { get; set; }

        [Required]
        [Display(Name = "Event Name")]
        public string EventName { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.DateTime)]
        [Column(TypeName = "date")]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Column(TypeName = "date")]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Column(TypeName = "date")]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Event Location")]
        // can be physical location or online
        public string Location { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Total Openings")]
        public int Capacity { get; set; }

        [Required]
        // adhoc or regular
        public string Category { get; set; } = string.Empty;
 
        [DataType(DataType.ImageUrl)]
        public string? ImageUrl { get; set; } = string.Empty;

        [Required]
        // type of event (beach cleaning etc)
        public string Type { get; set; } = string.Empty;

        // set range
        [Display(Name = "Minimum Age")]
        public int? MinAge { get; set; }

        [DataType(DataType.ImageUrl)]
        public string? GuideUrl { get; set; } = string.Empty;

        [Required]
        // 1 public + approved, 2 public + pending,  3 private + approved, 4 private + pending, 5 disapproved, 6 deleted
        public int Status { get; set; } = 4;

        [Display(Name = "Organisation Name")]
        public string? OrganisationName { get; set; } = string.Empty;

        public List<Organiser> Organisers { get; set; } = new();

        public List<Session> Sessions { get; set; } = new();

        /*[ForeignKey("User")]
        public int UserId { get; set; }

        //public User? User { get; set; }*/
    }
}
