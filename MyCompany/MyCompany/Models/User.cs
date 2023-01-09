using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MyCompany.Models
{
	public class User
	{
		[Required]
		[Key]
		public string UserId { get; set; } = Guid.NewGuid().ToString();
		[Required, MaxLength(50)]
		public string Name { get; set; } = string.Empty;

		[Required, Range(0, 120)]
		public int Age { get; set; } = 0;

        [Required, RegularExpression(@"^[STFG]\d{7}[A-Z]$", ErrorMessage = "Invalid NRIC.")]
        public string NRIC { get; set; } = string.Empty;

        [Required]
		public Boolean Admin_Role { get; set; } = false;

		[Required, MaxLength(100)]
		public string Address { get; set; } = string.Empty;

		[Required, RegularExpression(@"^\d{6}$", ErrorMessage = "Invalid Postal.")]
		public int Postal { get; set; }

		[Required, RegularExpression(@"^(6|8|9)\d{7}$", ErrorMessage = "Invalid Phone number.")]
		public int Phone { get; set; }

		[Required]
        public string Email { get; set; } = string.Empty;

		[Required(ErrorMessage = "Password is required.")]
		public string Password { get; set; } = string.Empty;
		[Required(ErrorMessage = "Confirmation Password is required.")]
		[Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
		[NotMapped]
		public string CfmPassword { get; set; } = string.Empty;

		[MaxLength(50)]
		public string? ImageURL { get; set; } = string.Empty;

		[Required]
		public DateTime Date_Joined { get; set; } = DateTime.Now;

		[Required]
		public Boolean Ban_Status { get; set; } = false;

		[Required]
		public int Credits { get; set; } = 0;
	}
}
