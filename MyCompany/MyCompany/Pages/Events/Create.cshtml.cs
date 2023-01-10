using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyCompany.Models;
using MyCompany.Services;
using System.ComponentModel.DataAnnotations;

namespace MyCompany.Pages.Events
{
    public class CreateModel : PageModel
    {

        private readonly EventService _eventService;
        private readonly OrganiserService _organiserService;
        private readonly SessionService _sessionService;
        private readonly UserService _userService;
        private IWebHostEnvironment _environment;
        public CreateModel(EventService eventService,
        OrganiserService organiserService, SessionService sessionService, UserService userService, IWebHostEnvironment environment)
        {
            _eventService = eventService;
            _organiserService = organiserService;
            _sessionService = sessionService;
            _userService = userService;
            _environment = environment;
        }

        [BindProperty]
        public Event MyEvent { get; set; } = new();
        [BindProperty]
        public Organiser MyOrganiser { get; set; } = new();
        [BindProperty]
        public Session MySession { get; set; } = new();
        [BindProperty]
        [Required, RegularExpression(@"^[STFG]\d{7}[A-Z]$", ErrorMessage = "Invalid NRIC.")]
        public string NRIC { get; set; } = string.Empty;
        public void OnGet()
        {
        }
    }
}
