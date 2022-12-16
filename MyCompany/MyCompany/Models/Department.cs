using System.ComponentModel.DataAnnotations;
namespace MyCompany.Models
{
    public class Department
    {
        [Required, MinLength(2), MaxLength(8)]
        public string DepartmentId { get; set; } = string.Empty;
        [Required, MaxLength(30)]
        public string Name { get; set; } = string.Empty;
        //To generate 1 to many relationship in db
        public List<Employee>? Employees { get; set; }
    }
}