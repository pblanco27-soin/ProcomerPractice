using EmployeeManagement.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagement.Infrastructure.Persistence.Configurations;

public class DepartmentRecordConfiguration : IEntityTypeConfiguration<DepartmentRecord>
{
    public void Configure(EntityTypeBuilder<DepartmentRecord> builder)
    {
        builder.ToTable("Departments");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasData(
            new DepartmentRecord { Id = 1, Name = "TI" },
            new DepartmentRecord { Id = 2, Name = "Finanzas" },
            new DepartmentRecord { Id = 3, Name = "Operaciones" }
        );
    }
}