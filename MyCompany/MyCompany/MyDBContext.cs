using Microsoft.EntityFrameworkCore;
using MyCompany.Models;
namespace MyCompany
{
    public class MyDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        //constructor
        public MyDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = _configuration.GetConnectionString("MyConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
        //DbSet = table in db
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Cart> Carts { get; set; }
    }
}