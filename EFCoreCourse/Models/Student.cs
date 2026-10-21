using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreCourse.Models
{
    internal class Student
    {
        public int StudentId { get; set; } // PK
        public string? SName { get; set; }

        // Navigation Property [Many]
        [InverseProperty(nameof(StudentCourse.Student))]
        public ICollection<StudentCourse> StdCourse { get; set; } = new HashSet<StudentCourse>();
    }
}
