using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MyCompany.Models
{
	public class User
	{
        [Required, Key]
        public int UserId { get; set; }
		[Required, MaxLength(50)]
		[Display(Name = "User ID")]
		public string UserId { get; set; } = string.Empty;
		[Required, MaxLength(50)]
		public string Name { get; set; } = string.Empty;

		[Required, Range(0, 120)]
		public int Age { get; set; } = 0;

		[Required]
		public Boolean Admin_Role { get; set; } = false;

		[Required, MaxLength(100)]
		public string Address { get; set; } = string.Empty;

		[Required, StringLength(6)]
		public int Postal { get; set; } = 0;

		[Required, StringLength(8)]
        public string Phone { get; set; } = string.Empty;

		[Required]
        public string Email { get; set; } = string.Empty;

		[Required]
        public string password { get; set; } = string.Empty;

		[MaxLength(50)]
		public string? ImageURL { get; set; }

		[Required]
		public DateTime Date_Joined { get; set; } = DateTime.Now;

		[Required]
		public Boolean Ban_Status { get; set; } = false;

		[Required]
		public int Credits { get; set; } = 0;
	}
}
