using HRM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRM.DAL.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            //var navigation = builder.Metadata.FindNavigation(nameof(Department.Users));
            //navigation?.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder
                .ToTable("Departments")
                .HasKey(x => x.Id);
        }
    }
}
