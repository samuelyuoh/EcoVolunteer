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
        [Display(Name = "Event Photo")]
        public IFormFile? Upload { get; set; }
        [BindProperty]
        [Required, RegularExpression(@"^[STFG]\d{7}[A-Z]$", ErrorMessage = "Invalid NRIC.")]
        public string NRIC { get; set; } = string.Empty;

        public Organiser MyOrganiser { get; set; } = new();
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                TempData["FlashMessage.Type"] = "success";
                TempData["FlashMessage.Text"] = string.Format("Event {0} is added", ModelState.IsValid);
                if (Upload != null)
                {
                    if (Upload.Length > 2 * 1024 * 1024)
                    {
                        ModelState.AddModelError("Upload",
                        "File size cannot exceed 2MB.");
                        return Page();
                    }
                    var uploadsFolder = "Uploads/Events";
                    var imageFile = Guid.NewGuid() + Path.GetExtension(Upload.FileName);
                    var imagePath = Path.Combine(_environment.ContentRootPath,
                    "wwwroot", uploadsFolder, imageFile);
                    using var fileStream = new FileStream(imagePath,
                    FileMode.Create);
                    await Upload.CopyToAsync(fileStream);
                    MyEvent.ImageUrl = string.Format("/{0}/{1}", uploadsFolder,
                    imageFile);

                    
                }
                // save NRIC to user model

                // create Organiser model, with user as main organiser, assume now that user id is 1

                MyOrganiser.OrganiserRole = "Main";
                MyOrganiser.UserId = "1";

                //save event model into the DB and save event id into myOrganiser
                _eventService.AddEvent(MyEvent);
                MyOrganiser.EventId = MyEvent.EventId;
                // save organiser model into DB
                _organiserService.AddOrganiser(MyOrganiser);
                //redirect to viewmyevents
                TempData["FlashMessage.Type"] = "success";
                TempData["FlashMessage.Text"] = string.Format("Event {0} is added", MyEvent.EventName);

                return Redirect("/Events/viewmyevents");
            }

            return Page();
        }
    }
}
