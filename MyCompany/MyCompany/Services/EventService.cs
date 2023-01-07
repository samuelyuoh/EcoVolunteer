using MyCompany.Models;

namespace MyCompany.Services
{
    public class EventService
    {
        private readonly MyDbContext _context;
        public EventService(MyDbContext context)
        {
            _context = context;
        }
        public List<Event> GetAll()
        {
            _context.Database.EnsureCreated();
            return _context.Events.OrderBy(m => m.EventId).ToList();
        }
        public Event? GetEventById(int id)
        {
            Event? Event1 = _context.Events.FirstOrDefault(
            x => x.EventId.Equals(id));
            return Event1;
        }
        public void AddEvent(Event Event1)
        {
            _context.Events.Add(Event1);
            _context.SaveChanges();
        }
        public void UpdateEvent(Event Event1)
        {
            _context.Events.Update(Event1);
            _context.SaveChanges();
        }
    }
}
