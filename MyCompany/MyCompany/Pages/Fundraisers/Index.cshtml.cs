using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyCompany.Models;
using MyCompany.Services;

namespace MyCompany.Pages.Fundraiser
{
    public class IndexModel : PageModel
    {
        private readonly FundraiserService _fundraiserService;
        public IndexModel(FundraiserService fundraiserService)
        {
            _fundraiserService = fundraiserService;
        }
        public List<FundraiserInfo> FundraiserList { get; set; } = new();
        public void OnGet()
        {
            FundraiserList = _fundraiserService.GetAll();
        }
    }
}
