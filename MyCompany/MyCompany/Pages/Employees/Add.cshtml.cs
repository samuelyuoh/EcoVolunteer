using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyCompany.Models;
using MyCompany.Services;

namespace MyCompany.Pages.Employees
{
    public class AddModel : PageModel
    {
        private readonly EmployeeService _employeeService;
        private readonly DepartmentService _departmentService;
        private IWebHostEnvironment _environment;
        public AddModel(EmployeeService employeeService,
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
        
        public void OnGet()
        {
            DepartmentList = _departmentService.GetAll();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                //check employeeID
                Employee? employee = _employeeService.GetEmployeeById(MyEmployee.EmployeeId);
                if (employee != null)
                {
                    TempData["FlashMessage.Type"] = "danger";
                    TempData["FlashMessage.Text"] = string.Format(
                    "Employee ID {0} alreay exists", MyEmployee.EmployeeId);
                    return Page();
                }
                //upload image
                if (Upload != null)
                {
                    if (Upload.Length > 2 * 1024 * 1024)
                    {
                        ModelState.AddModelError("Upload",
                        "File size cannot exceed 2MB.");
                        return Page();
                    }
                    var uploadsFolder = "uploads";
                    var imageFile = Guid.NewGuid() + Path.GetExtension(Upload.FileName);
                    var imagePath = Path.Combine(_environment.ContentRootPath,
                    "wwwroot", uploadsFolder, imageFile);
                    using var fileStream = new FileStream(imagePath,
                    FileMode.Create);
                    await Upload.CopyToAsync(fileStream);
                    MyEmployee.ImageURL = string.Format("/{0}/{1}", uploadsFolder,
                    imageFile);
                }
                _employeeService.AddEmployee(MyEmployee);

                TempData["FlashMessage.Type"] = "success";
                TempData["FlashMessage.Text"] = string.Format("Employee {0} is added",
                MyEmployee.Name);
                return Redirect("/Employees");
            }
            return Page();
        }               
    }
}