using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyCompany.Services;
using MyCompany.Models;

namespace MyCompany.Pages.Employees
{
    public class testProductModel : PageModel
    {
        private readonly EmployeeService _employeeService;
        private readonly CartService _cartService;
        private IWebHostEnvironment _environment;
        public testProductModel(EmployeeService employeeService, 
            CartService cartService, 
            IWebHostEnvironment environment)
        {
            _employeeService = employeeService;
            _cartService = cartService;
            _environment = environment;
        }
        [BindProperty]
        public Cart MyCart { get; set; } = new();
        public IActionResult OnPostAsync()
        {
            if(ModelState.IsValid)
            {

                MyCart.UserId = 1;
                MyCart.Total = 0;
                _cartService.AddCart(MyCart);
                return Redirect("/Employees");
            }
            return Page();
        }
    }
}
