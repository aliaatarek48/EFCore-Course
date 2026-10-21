using EFCoreCourse.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreCourse.Configurations
{
    internal class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("EmployeesTable");
            builder.HasKey(E => E.EmpId);

            builder.Property(E => E.EmpId).UseIdentityColumn(10, 10); // EF Core 5

            builder.Property(E => E.EmpName)
                .HasColumnName("EmployeeName")
                .HasColumnType("varchar")
                .HasMaxLength(50); // EmployeeName Varchar(50)

            builder.Property(E => E.Salary).HasPrecision(10, 2);

            builder.ToTable(T => T.HasCheckConstraint("Check_Employee_Age_Range", "[Age] Between 22 And 40"));

            builder.Property(E => E.Email).IsRequired();

            builder.ToTable(T => T.HasCheckConstraint("Check_Employee_Email", "[Email] Like '%@%.%'"));

            builder.Ignore(E => E.UserName);
            builder.Property<DateTime>("CreatedAt").HasDefaultValueSql("GETDATE()"); // Shadow Property

            builder.ComplexProperty(E => E.EmpAddress);// EF Core 8
                                                       // 1-1 Mandatory

            #region Work Relationship
            builder.HasOne(E => E.EmployeeDepartment)
                   .WithMany(D => D.Employees)
                   .HasForeignKey(E => E.DepartmentId)
                   .IsRequired() // Make Relation Required [FK Not Allow NULL]
                   .OnDelete(DeleteBehavior.Restrict);
            #endregion
        }
    }
}
