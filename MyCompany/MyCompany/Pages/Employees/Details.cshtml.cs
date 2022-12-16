using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyCompany.Models;
using MyCompany.Services;
namespace MyCompany.Pages.Employees
{
    public class DetailsModel : PageModel
    {
        private readonly EmployeeService _employeeService;
        private readonly DepartmentService _departmentService;
        private IWebHostEnvironment _environment;
        public DetailsModel(EmployeeService employeeService,
        DepartmentService departmentService, IWebHostEnvironment environment)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
            _environment = environment;
        }
        [BindProperty]
        public Employee MyEmployee { get; set; } = new();
        [BindProperty]
        public IFormFile? Upload { get; set; }
        public static List<Department> DepartmentList { get; set; } = new();

        public IActionResult OnGet(string id)
        {
            DepartmentList = _departmentService.GetAll();
            Employee? employee = _employeeService.GetEmployeeById(id);
            if (employee != null)
            {
                MyEmployee = employee;
                MyEmployee.Department = _departmentService.GetDepartmentById(
                employee.DepartmentId);
                return Page();
            }
            else
            {
                TempData["FlashMessage.Type"] = "danger";
                TempData["FlashMessage.Text"] = string.Format(
                "Employee ID {0} not found", id);
                return Redirect("/Employees");
            }
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _employeeService.UpdateEmployee(MyEmployee);
                TempData["FlashMessage.Type"] = "success";
                TempData["FlashMessage.Text"] = string.Format(
                "Employee {0} is updated", MyEmployee.Name);
            }
            var uploadsFolder = "uploads";
            if (MyEmployee.ImageURL != null)
            {
                var oldImageFile = Path.GetFileName(MyEmployee.ImageURL);
                var oldImagePath = Path.Combine(
                _environment.ContentRootPath, "wwwroot", uploadsFolder, oldImageFile);
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
            }
            return Page();
        }
    }
}
