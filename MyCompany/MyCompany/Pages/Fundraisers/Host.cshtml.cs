using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyCompany.Models;
using MyCompany.Pages.Employees;
using MyCompany.Services;

namespace MyCompany.Pages.Fundraisers
{
    public class HostModel : PageModel
    {
        private readonly FundraiserService _fundraiserService;
        private readonly FundraiserCategoryService _fundraiserCategoryService;

        public HostModel(FundraiserService fundraiserService, FundraiserCategoryService fundraiserCategoryService)
        {
            _fundraiserService = fundraiserService;
            _fundraiserCategoryService = fundraiserCategoryService;
        }

        [BindProperty]
        public FundraiserInfo MyFundraiser { get; set; } = new();

        [BindProperty]
        public IFormFile? Upload { get; set; }
        public static List<FundraiserCategory> CategoryList { get; set; } = new();

        public void OnGet()
        {
            CategoryList = _fundraiserCategoryService.GetAll();
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                FundraiserInfo? fundraiser = _fundraiserService.GetFundraiserById( MyFundraiser.FundraiserId);
                _fundraiserService.AddFundraiser(MyFundraiser);
                return Redirect("/Fundraisers");
            }
            return Page();
        }
    }
}
