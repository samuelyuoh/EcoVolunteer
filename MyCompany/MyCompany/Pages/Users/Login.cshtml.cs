using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyCompany.Models;
using MyCompany.Services;
using System.Security.Claims;

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
		public LUser MyUser { get; set; } = new();
		[BindProperty]
		public IFormFile? Upload { get; set; }
		public static List<User> UserList { get; set; } = new();
		public void OnGet()
		{
		}

		public async Task<IActionResult> OnPostAsync()
		{
			//check employeeID
			User? user = _userService.GetUserByEmail(MyUser.NRIC);
			if (user != null && user.Password == MyUser.Password)
			{
				TempData["FlashMessage.Type"] = "success";
				TempData["FlashMessage.Text"] = string.Format("Successful Login");
				signInManager.PasswordSignInAsync(user, user.Password, false, false);
                //var claims = new List<Claim> {
				//	new Claim(ClaimTypes.NameIdentifier, user.Id),
				//	new Claim(ClaimTypes.Name, user.UserName)
				//	};
                //var i = new ClaimsIdentity(claims, "MyCookieAuth");
                //ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(i);
                //await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);
                return Redirect("/");
			}
			TempData["FlashMessage.Type"] = "danger";
			TempData["FlashMessage.Text"] = string.Format("Username or Password incorrect"+user.ToString());
            return Page();
			//TempData["FlashMessage.Type"] = "danger";
			//TempData["FlashMessage.Text"] = string.Format(ModelState.Values.SelectMany(v => v.Errors).ToString());
			//return Page();
		}
	}
}
