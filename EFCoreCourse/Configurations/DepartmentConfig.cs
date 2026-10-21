using EFCoreCourse.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreCourse.Configurations
{
    internal class DepartmentConfig : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> D)
        {
            D.ToTable("Departments", "Sales");
            D.HasKey(D => D.DeptId);
            D.Property(D => D.DeptId).UseIdentityColumn(10, 10);

            D.Property(D => D.DeptName)
              .HasColumnName("DepartmentName")
              .HasColumnType("varchar")
              .HasMaxLength(50)
              .IsRequired(false)
              .HasDefaultValue("HR");

            D.Property(D => D.DateOfCreation)
            .HasDefaultValueSql("GETDATE()"); // Get Current DateTime When Row | Record Inserted
                                              //.HasComputedColumnSql("GetDate()"); // Calculated By SQL Server Every Time You Query DateOfCreation
                                              //.HasDefaultValue(DateTime.Now); // Use DateTime.Now -> Time Migration 

            D.Ignore(D => D.Serial); // Not Mapped 

            #region Manage Relationship 
            D.HasOne(E => E.Manager)
                     .WithOne(D => D.ManagedDepartment)
                     .HasForeignKey<Department>(D => D.DeptManagerId)
                     .OnDelete(DeleteBehavior.Restrict);


            #endregion

            #region Data Seeding 


            D.HasData(
                new Department() { DeptId = 1, DeptName = "IT", DateOfCreation = new DateTime(2026, 10, 1) },
                new Department() { DeptId = 2, DeptName = "Sales", DateOfCreation = new DateTime(2026, 05, 15) },
                new Department() { DeptId = 3, DeptName = "HR", DateOfCreation = new DateTime(2026, 02, 20) }
                );

            #endregion

        }
    }
}