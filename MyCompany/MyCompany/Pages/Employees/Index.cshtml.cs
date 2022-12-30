using Microsoft.AspNetCore.Cors.Infrastructure;
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
        private readonly CartService _cartService;
        // inject the service
        public IndexModel(EmployeeService employeeService, CartService cartService)
        {
            _cartService = cartService;
            _employeeService = employeeService;
        }
        // define the property
        [BindProperty]
        public Cart MyCart { get; set; } = new();

        public List<Employee> EmployeeList { get; set; } = new();
        // call the service
        public void OnGet()
        {
            EmployeeList = _employeeService.GetAll();
        }
        public IActionResult OnPostAsync(string button)
        {
            if (ModelState.IsValid)
            {
                if (button.ToLower() == "test")
                {
                    MyCart.UserId = 1;
                    MyCart.Total = 0;
                    _cartService.CreateCart(MyCart);
                    TempData["FlashMessage.Type"] = "success";
                    TempData["FlashMessage.text"] = string.Format("Cart for User {0} is added", MyCart.UserId);
                    return Redirect("/Employees");
                }else if (button.ToLower() == "add to cart")
                {
                    _cartService.AddToCart(1);
                    TempData["FlashMessage.Type"] = "success";
                    TempData["FlashMessage.text"] = string.Format("added to cart");
                }else if(button.ToLower() == "remove all items")
                {
                    _cartService.removeAllItems(1);
                    TempData["FlashMessage.Type"] = "error";
                    TempData["FlashMessage.text"] = string.Format("deleted item in cart");
                }

            }
            return Page();
        }
    }
}
