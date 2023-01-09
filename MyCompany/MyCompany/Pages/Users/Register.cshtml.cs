using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyCompany.Models;
using MyCompany.Services;

namespace MyCompany.Pages.Users
{
    public class RegisterModel : PageModel
    {
		private readonly UserService _userService;
		private IWebHostEnvironment _environment;
        private UserManager<IdentityUser> userManager { get; }
        private SignInManager<IdentityUser> signInManager { get; }
        public RegisterModel(UserService userService, IWebHostEnvironment environment, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
		{
			_userService = userService;
			_environment = environment;
            this.userManager = userManager;
			this.signInManager = signInManager;

        }
		[BindProperty]
		public User MyUser { get; set; } = new();
		[BindProperty]
		public IFormFile? Upload { get; set; }
		public static List<User> UserList { get; set; } = new();

		public void OnGet()
		{
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (ModelState.IsValid)
			{
				//check employeeID
				User? employee = _userService.GetUserByEmail(MyUser.Email);
				if (employee != null)
				{
					TempData["FlashMessage.Type"] = "danger";
					TempData["FlashMessage.Text"] = string.Format(
					"Email {0} alreay exists", MyUser.Email);
					return Page();
				}
				_userService.AddUser(MyUser);
                var user = new IdentityUser()
                {
                    
                };

                TempData["FlashMessage.Type"] = "success";
				TempData["FlashMessage.Text"] = string.Format("User {0} is added",
				MyUser.Name);
				return Redirect("/users/login");
			}
			return Page();
		}
	}
}
