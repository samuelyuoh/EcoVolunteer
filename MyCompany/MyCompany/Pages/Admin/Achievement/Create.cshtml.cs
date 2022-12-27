using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyCompany.Services;
using MyCompany.Models;

namespace MyCompany.Pages.Admin.Achievement
{
    public class CreateModel : PageModel
    {
        private readonly AchievementService _achievementService;
        private IWebHostEnvironment _environment;
        public AddModel(AchievementService achievementService, IWebHostEnvironment environment)
        {
            _achievementService = achievementService;
            _environment = environment;
        }
        [BindProperty]
        public Achievement MyAchievement { get; set; } = new();
        public void OnGet()
        {
        }
    }
}
