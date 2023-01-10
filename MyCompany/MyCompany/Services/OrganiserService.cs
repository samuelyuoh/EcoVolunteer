using MyCompany.Models;

namespace MyCompany.Services
{
    public class OrganiserService
    {
        private readonly MyDbContext _context;
        public OrganiserService(MyDbContext context)
        {
            _context = context;
        }
        public List<Organiser> GetAll()
        {
            _context.Database.EnsureCreated();
            return _context.Organisers.OrderBy(m => m.OrganiserId).ToList();
        }
        public Organiser? GetOrganiserById(int id)
        {
            Organiser? Organiser = _context.Organisers.FirstOrDefault(
            x => x.OrganiserId.Equals(id));
            return Organiser;
        }

        public List<Organiser> GetOrganiserByUserId(string id)
        {
            List<Organiser> Organiser = new();
           Organiser = _context.Organisers.OrderBy(m => m.OrganiserId).Where(o => o.UserId.Equals(id)).ToList();
            //Organiser? Organiser = _context.Organisers.FirstOrDefault(
            //x => x.OrganiserId.Equals(id));
            return Organiser;
        }

        public void AddOrganiser(Organiser Organiser)
        {
            _context.Organisers.Add(Organiser);
            _context.SaveChanges();
        }
        public void UpdateOrganiser(Organiser Organiser)
        {
            _context.Organisers.Update(Organiser);
            _context.SaveChanges();
        }
    }
}
