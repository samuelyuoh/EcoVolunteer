using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Identity;

namespace MyCompany.Models
{
	public class User : IdentityUser
	{

		[Required, Range(0, 120)]
		public int Age { get; set; } = 0;

		[Required, RegularExpression(@"^[STFG]\d{7}[A-Z]$", ErrorMessage = "Invalid NRIC.")]
		public string NRIC { get; set; } = string.Empty;

		[Required]
		public Boolean Admin_Role { get; set; } = false;

		[Required, MaxLength(100)]
		public string Address { get; set; } = string.Empty;

		[Required, RegularExpression(@"^\d{6}$", ErrorMessage = "Invalid Postal.")]
		[DataType(DataType.PostalCode)]
		public int Postal { get; set; }

		[Required, RegularExpression(@"^(6|8|9)\d{7}$", ErrorMessage = "Invalid Phone number.")]
		[DataType(DataType.PhoneNumber)]
		public int Phone { get; set; }

		[Required(ErrorMessage = "Password is required.")]
		[DataType(DataType.Password)]
		public string Password { get; set; } = string.Empty;
		[Required(ErrorMessage = "Confirmation Password is required.")]
		[Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
		[NotMapped]
		public string CfmPassword { get; set; } = string.Empty;

		[MaxLength(50)]
		[DataType(DataType.ImageUrl)]
		public string? ImageURL { get; set; } = string.Empty;

		[Required]
		[DataType(DataType.DateTime)]
		public DateTime Date_Joined { get; set; } = DateTime.Now;

		[Required]
		public Boolean Ban_Status { get; set; } = false;

		[Required]
		public int Credits { get; set; } = 0;
	}
}
