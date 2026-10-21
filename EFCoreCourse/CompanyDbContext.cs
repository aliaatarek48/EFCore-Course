using EFCoreCourse.Configurations;
using EFCoreCourse.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreCourse
{
    internal class CompanyDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = .; Database = CompanyDb; Trusted_Connection = true; TrustServerCertificate =true");
            //optionsBuilder.UseLazyLoadingProxies(x => x.IgnoreNonVirtualNavigations());

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Employee With Fluent API
            //modelBuilder.Entity<Employee>().ToTable("EmployeesTable");
            //modelBuilder.Entity<Employee>().HasKey(E => E.EmpId);

            //modelBuilder.Entity<Employee>().Property(E => E.EmpId).UseIdentityColumn(10, 10); // EF Core 5

            //modelBuilder.Entity<Employee>().Property(E => E.EmpName)
            //    .HasColumnName("EmployeeName")
            //    .HasColumnType("varchar")
            //    .HasMaxLength(50); // EmployeeName Varchar(50)

            //modelBuilder.Entity<Employee>().Property(E => E.Salary).HasPrecision(10, 2);

            //modelBuilder.Entity<Employee>().ToTable(T => T.HasCheckConstraint("Check_Employee_Age_Range", "[Age] Between 22 And 40"));

            //modelBuilder.Entity<Employee>().Property(E => E.Email).IsRequired();

            //modelBuilder.Entity<Employee>().ToTable(T => T.HasCheckConstraint("Check_Employee_Email", "[Email] Like '%@%.%'"));

            //modelBuilder.Entity<Employee>().Ignore(E => E.UserName);
            //modelBuilder.Entity<Employee>().Property<DateTime>("CreatedAt").HasDefaultValueSql("GETDATE()"); // Shadow Property

            #endregion

            #region Department With Fluent API
            //modelBuilder.Entity<Department>(D =>
            //{
            //    D.ToTable("Departments", "Sales");
            //    D.HasKey(D => D.DeptId);
            //    D.Property(D => D.DeptId).UseIdentityColumn(10, 10);

            //    D.Property(D => D.DeptName)
            //      .HasColumnName("DepartmentName")
            //      .HasColumnType("varchar")
            //      .HasMaxLength(50)
            //      .IsRequired(false)
            //      .HasDefaultValue("HR");

            //    D.Property(D => D.DateOfCreation)
            //    .HasDefaultValueSql("GETDATE()"); // Get Current DateTime When Row | Record Inserted
            //                                      //.HasComputedColumnSql("GetDate()"); // Calculated By SQL Server Every Time You Query DateOfCreation
            //                                      //.HasDefaultValue(DateTime.Now); // Use DateTime.Now -> Time Migration 

            //    D.Ignore(D => D.Serial); // Not Mapped 
            //});

            #endregion

            modelBuilder.ApplyConfiguration<Department>(new DepartmentConfig());
            modelBuilder.ApplyConfiguration<Employee>(new EmployeeConfig());
            modelBuilder.ApplyConfiguration<EmployeeProject>(new EmployeeProjectConfig());
            modelBuilder.ApplyConfiguration<StudentCourse>(new StudentCourseConfig());

        }

        #region DbContexts
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        #endregion
    }
}
