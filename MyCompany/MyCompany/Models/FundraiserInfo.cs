using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCompany.Models
{
    public class FundraiserInfo
    {
        //[Required, MinLength(1, ErrorMessage = "name cannot be empty")]
        //[display(name = "full name")]
        //public string fullname { get; set; } = string.empty;
        [Key]
        [Display(Name = "Fundraiser ID (Auto generated) ")]
        public string FundraiserId { get; set; } = Guid.NewGuid().ToString("N");

        [Required, MinLength(1, ErrorMessage = "Reason cannot be empty"), MaxLength(200, ErrorMessage = "Reason cannot be more than 200 characters long")]
        [Display(Name = "Reason for hosting fundraiser")]
        public string Reason { get; set; } = string.Empty;

        [Required, MinLength(1, ErrorMessage = "Fundraiser name cannot be empty"), MaxLength(30, ErrorMessage = "Fundraiser name cannot be more than 30 characters long")]
        [Display(Name = "Fundraiser name")]
        public string FundraiserName { get; set; } = string.Empty;

        //[Required, RegularExpression(@"^[STFG]\d{7}[A-Z]$", ErrorMessage = "Invalid NRIC."), MaxLength(9)]
        //public string NRIC { get; set; } = string.Empty;

        [Required, Range(1.00, 1000000.00, ErrorMessage = "Starting goal cannot be less than S$1.00 or more than S$100,000.00")]
        [Display(Name = "Staring goal (S$)")]
        [Column(TypeName = "decimal(7,2)")]
        public double StartingGoal { get; set; } = 1.00;

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start date")]
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; } = new DateTime(DateTime.Today.Date.Day);

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "End date")]
        public DateTime EndDate { get; set; } = new DateTime(DateTime.Today.Date.Day);

        [Required]
        [Display(Name = "Fundraiser category")]
        public string CategoryId { get; set; } = string.Empty;
        public FundraiserCategory? fundraiserCategory { get; set; }

        [Required, MaxLength(1000, ErrorMessage = "Description can only have a maximum of 1000 characters.")]
        [Display(Name = "Fundraiser description")]
        public string Description { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? ImageURL { get; set; }
    }
}
