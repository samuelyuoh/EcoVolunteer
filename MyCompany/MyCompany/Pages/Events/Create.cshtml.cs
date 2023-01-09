using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyCompany.Models;
using MyCompany.Services;

namespace MyCompany.Pages.Events
{
    public class CreateModel : PageModel
    {

        private readonly EventService _eventService;
        private readonly OrganiserService _organiserService;
        private readonly SessionService _sessionService;
        private IWebHostEnvironment _environment;
        public CreateModel(EventService eventService,
        OrganiserService organiserService, SessionService sessionService, IWebHostEnvironment environment)
        {
            _eventService = eventService;
            _organiserService = organiserService;
            _sessionService = sessionService;
            _environment = environment;
        }

        [BindProperty]
        public Event MyEvent { get; set; } = new();
        [BindProperty]
        public Organiser MyOrganiser { get; set; } = new();
        [BindProperty]
        public Session MySession { get; set; } = new();
        public void OnGet()
        {
        }
    }
}
