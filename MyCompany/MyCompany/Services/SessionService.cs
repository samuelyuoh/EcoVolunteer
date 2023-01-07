using MyCompany.Models;

namespace MyCompany.Services
{
    public class SessionService
    {
        private readonly MyDbContext _context;
        public SessionService(MyDbContext context)
        {
            _context = context;
        }
        public List<Session> GetAll()
        {
            _context.Database.EnsureCreated();
            return _context.Sessions.OrderBy(m => m.SessionId).ToList();
        }
        public Session? GetSessionById(int id)
        {
            Session? session = _context.Sessions.FirstOrDefault(
            x => x.SessionId.Equals(id));
            return session;
        }
        public void AddSession(Session session)
        {
            _context.Sessions.Add(session);
            _context.SaveChanges();
        }
        public void UpdateSession(Session session)
        {
            _context.Sessions.Update(session);
            _context.SaveChanges();
        }
    }
}
