using Microsoft.EntityFrameworkCore;
using EmployeeProject.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EmployeeProject.Data;
namespace EmployeeProject.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(t => t.HireDate)
             .HasConversion<DateOnlyConverter>();
              
        }
    }
}
