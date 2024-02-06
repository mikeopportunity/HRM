using HRM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRM.DAL.Configurations
{
    public class EmployeerConfiguration : IEntityTypeConfiguration<Employeer>
    {
        public void Configure(EntityTypeBuilder<Employeer> builder)
        {
           builder
                .ToTable("Employees")
                .HasKey(x => x.Id);
        }
    }
}
