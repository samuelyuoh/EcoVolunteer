using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyCompany.Models;
using MyCompany.Services;

namespace MyCompany.Pages.Users
{
    public class LoginModel : PageModel
    {
		private readonly UserService _userService;
		private IWebHostEnvironment _environment;
		private readonly SignInManager<IdentityUser> signInManager;
		public LoginModel(UserService userService, IWebHostEnvironment environment, SignInManager<IdentityUser> signInManager)
		{
			_userService = userService;
			_environment = environment;
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
				User? user = _userService.GetUserByEmail(MyUser.Email);
				if (user != null && user.Password == MyUser.Password)
				{
					TempData["FlashMessage.Type"] = "success";
					TempData["FlashMessage.Text"] = string.Format("Successful Login");
                    var identityResult = await signInManager.SignInAsync(user, false);
                    if (identityResult.Succeeded)
                    {
                        return RedirectToPage("Index");
                    }
                    return Redirect("/");
                }
				TempData["FlashMessage.Type"] = "danger";
				TempData["FlashMessage.Text"] = string.Format("Username or Password incorrect");
                return Page();
            }
			return Page();
		}
	}
}
}
