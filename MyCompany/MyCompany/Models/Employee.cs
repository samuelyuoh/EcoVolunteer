using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCompany.Models
{
    public class Employee
    {
        [Required, MinLength(3, ErrorMessage = "Enter at least 3 characters."),
        MaxLength(8)]
        [Display(Name = "Employee ID")]
        public string EmployeeId { get; set; } = string.Empty;

        [Required, RegularExpression(@"^[STFG]\d{7}[A-Z]$",
        ErrorMessage = "Invalid NRIC."), MaxLength(9)]
        public string NRIC { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required, MaxLength(1)]
        public string Gender { get; set; } = string.Empty;

        //to save as date and not datetime
        [DataType(DataType.Date)]
        [Display(Name = "Birthday")]
        // so that the db know, as its not a string
        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; } = new DateTime(DateTime.Now.Year - 18, 1, 1);
        [Required]
        [Display(Name = "Department")]
        //string.empty is used to create a new column in db
        public string DepartmentId { get; set; } = string.Empty;

        public Department? Department { get; set; }

        [Range(2000, 15000)]
        // so that the db know, as its not a string
        [Column(TypeName = "decimal(7,2)")]
        public decimal Salary { get; set; }

        [MaxLength(50)]
        public string? ImageURL { get; set; }
    }
}
