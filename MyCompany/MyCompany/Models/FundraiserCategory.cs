using System.ComponentModel.DataAnnotations;
namespace MyCompany.Models
{
    public class FundraiserCategory
    {
        [Key]
        [Required, MinLength(2), MaxLength(8)]
        public string CategoryId { get; set; } = string.Empty;
        [Required, MaxLength(30)]
        public string Name { get; set; } = string.Empty;

        public List<FundraiserInfo>? Fundraisers { get; set; }
    }
}
