using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreCourse.Models
{
    internal class Project
    {
        public int Id { get; set; }

        public string PName { get; set; } = null!;

        public ICollection<EmployeeProject> ProjectEmployees { get; set; } = new HashSet<EmployeeProject>();

    }
}
