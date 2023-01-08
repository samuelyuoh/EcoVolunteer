using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyCompany.Models;
using MyCompany.Services;

namespace MyCompany.Pages.Fundraisers
{
    public class ViewModel : PageModel
    {
        private readonly FundraiserService _fundraiserService;
        private readonly FundraiserCategoryService _fundraiserCategoryService;
        public ViewModel(FundraiserService fundraiserService, FundraiserCategoryService fundraiserCategoryService)
        {
            _fundraiserService = fundraiserService;
            _fundraiserCategoryService = fundraiserCategoryService;
        }
        public FundraiserInfo MyFundraiser { get; set; } = new();
        public IActionResult OnGet(string id)
        {
            FundraiserInfo? fundraiser = _fundraiserService.GetFundraiserById(id);
            if (fundraiser != null)
            {
                MyFundraiser = fundraiser;
                MyFundraiser.fundraiserCategory = _fundraiserCategoryService.GetCategoryById(fundraiser.CategoryId);
                return Page();
            }
            else
            {
                return Redirect("/Fundraisers");
            }
        }
    }
}
