using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreCourse.Models
{
    //[PrimaryKey(nameof(StdId) , nameof(CrsId))]
    // EF Core 7 [.Net 7 , .Net 6 ]
    internal class StudentCourse
    {
        [ForeignKey(nameof(Student))]
        public int StdId { get; set; }

        // Navigation Property [One]
        [InverseProperty(nameof(Student.StdCourse))]
        public Student Student { get; set; } = null!;

        [ForeignKey(nameof(Course))]
        public int CrsId { get; set; }
        public Course Course { get; set; } = null!;
        public int Grade { get; set; }
    }
}