using MyCompany.Models;

namespace MyCompany.Services
{
    public class AchievementService
    {
        private readonly MyDbContext _context;
        public AchievementService(MyDbContext context)
        {
            _context = context;
        }
        public List<Achievement> GetAll()
        {
            return _context.Achievements.OrderBy(m => m.AchievementId).ToList();
        }
        public Achievement? GetAchievementById(string id)
        {
            Achievement? achievement = _context.Achievements.FirstOrDefault(
            x => x.AchievementId.Equals(id));
            return achievement;
        }
        public void AddAchievement(Achievement achievement)
        {
            _context.Achievements.Add(achievement);
            _context.SaveChanges();
        }
    }
}
