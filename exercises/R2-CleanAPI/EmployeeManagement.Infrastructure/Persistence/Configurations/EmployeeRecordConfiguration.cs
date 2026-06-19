using EmployeeManagement.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagement.Infrastructure.Persistence.Configurations;

public class EmployeeRecordConfiguration : IEntityTypeConfiguration<EmployeeRecord>
{
    public void Configure(EntityTypeBuilder<EmployeeRecord> builder)
    {
        builder.ToTable("Employees");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.FullName)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(x => x.MonthlySalary)
            .HasColumnType("decimal(18,2)");

        builder.Property(x => x.AnnualBonus)
            .HasColumnType("decimal(18,2)");

        builder.Property(x => x.HireDate)
            .IsRequired();

        builder.HasOne(x => x.Department)
            .WithMany(x => x.Employees)
            .HasForeignKey(x => x.DepartmentId);
    }
}