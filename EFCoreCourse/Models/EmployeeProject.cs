using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreCourse.Models
{
    [PrimaryKey(nameof(EmpId), nameof(ProId))]
    internal class EmployeeProject
    {
        [ForeignKey(nameof(Employee))]
        public int EmpId { get; set; }
        public Employee Employee { get; set; } = null!;

        [ForeignKey(nameof(Project))]
        public int ProId { get; set; }
        public Project Project { get; set; } = null!;
    }
}