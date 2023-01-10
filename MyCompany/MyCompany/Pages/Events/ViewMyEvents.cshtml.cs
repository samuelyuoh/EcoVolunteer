using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyCompany.Models;
using MyCompany.Services;

namespace MyCompany.Pages.Events
{
    public class ViewMyEventsModel : PageModel
    {
        private readonly EventService _eventService;
        private readonly OrganiserService _organiserService;
        private readonly SessionService _sessionService;
        private readonly UserService _userService;
        private IWebHostEnvironment _environment;

        public List<Event> eventList = new();
        public List<Organiser> organiserList = new();
        public ViewMyEventsModel(EventService eventService,
        OrganiserService organiserService, SessionService sessionService, UserService userService, IWebHostEnvironment environment)
        {
            _eventService = eventService;
            _organiserService = organiserService;
            _sessionService = sessionService;
            _userService = userService;
            _environment = environment;
        }
        public IActionResult OnGet()
        {

            

            organiserList = _organiserService.GetOrganiserByUserId("0");
            if (organiserList.Count > 0)
            {
                foreach (var o in organiserList)
                {
                    eventList.Add(_eventService.GetEventById(o.EventId));
                }
            }
            

            return Page();
        }
    }
}
