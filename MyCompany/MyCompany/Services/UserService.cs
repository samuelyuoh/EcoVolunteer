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
			return _context.AspNetUsers.OrderBy(m => m.Id).ToList();	
		}
		public User? GetUserByNRIC(string nric)
		{
			User? user = _context.AspNetUsers.FirstOrDefault(
			x => x.NRIC.Equals(nric));
			return user;
		}
		public void AddUser(User user)
		{
			_context.AspNetUsers.Add(user);
			_context.SaveChanges();
		}
		public void UpdateUser(User user)
		{
			_context.AspNetUsers.Update(user);
			_context.SaveChanges();
		}
	}
}
