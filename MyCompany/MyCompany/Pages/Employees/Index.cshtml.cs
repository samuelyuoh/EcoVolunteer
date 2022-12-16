using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyCompany.Models;
using MyCompany.Services;

namespace MyCompany.Pages.Employees
{
    public class IndexModel : PageModel
    {
        // define the service
        private readonly EmployeeService _employeeService;
        // inject the service
        public IndexModel(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        // define the property
        public List<Employee> EmployeeList { get; set; } = new();
        // call the service
        public void OnGet()
        {
            EmployeeList = _employeeService.GetAll();
        }
    }
}
