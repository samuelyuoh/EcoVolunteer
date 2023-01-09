using MyCompany.Models;

namespace MyCompany.Services
{
	public class UserService
	{
		private readonly MyDbContext _context;
		public UserService(MyDbContext context)
		{
			_context = context;
		}
		public List<User> GetAll()
		{
			return _context.Users.OrderBy(m => m.UserId).ToList();	
		}
		public User? GetUserByEmail(string email)
		{
			User? user = _context.Users.FirstOrDefault(
			x => x.Email.Equals(email));
			return user;
		}
		public void AddUser(User user)
		{
			_context.Users.Add(user);
			_context.SaveChanges();
		}
		public void UpdateUser(User user)
		{
			_context.Users.Update(user);
			_context.SaveChanges();
		}
	}
}
