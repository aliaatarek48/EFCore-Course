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
    internal class EmployeeProjectConfig : IEntityTypeConfiguration<EmployeeProject>
    {
        public void Configure(EntityTypeBuilder<EmployeeProject> builder)
        {
            builder.HasKey(EP => EP.EmpId);

            builder.HasOne(EP => EP.Employee)
                   .WithOne(E => E.EmployeeProject)
                   .HasForeignKey<EmployeeProject>(EP => EP.EmpId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(EP => EP.Project)
                   .WithMany(P => P.ProjectEmployees)
                   .HasForeignKey(EP => EP.ProId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
