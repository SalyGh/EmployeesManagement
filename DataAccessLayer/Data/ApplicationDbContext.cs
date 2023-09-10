using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace EmployeeProject.Data
{
    using EmployeeProject.Models;
    using EmployeeProject.Configuration;
	public class ApplicationDbContext : IdentityDbContext<AppUser>
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ): base(options) { }
            
        public DbSet<Employee> Employees { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.ApplyConfiguration(new EmployeeConfiguration()); // we are calling the configuration file inside the onModelCreating method
        //}
    }
}
