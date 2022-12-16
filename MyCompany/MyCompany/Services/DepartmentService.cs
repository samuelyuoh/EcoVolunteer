using MyCompany.Models;
namespace MyCompany.Services
{
    public class DepartmentService
    {
        private readonly MyDbContext _dbContext;
        public DepartmentService(MyDbContext myDBContext)
        {
            _dbContext = myDBContext;
        }
        public List<Department> GetAll()
        {
            //to sort the list by lambda expression
            return _dbContext.Departments.OrderBy(d => d.Name).ToList();
        }
        public Department? GetDepartmentById(string id)
        {
            // FirstOrDefault could be null
            Department? department = _dbContext.Departments.FirstOrDefault(
            x => x.DepartmentId.Equals(id));
            return department;
        }
    }
}
