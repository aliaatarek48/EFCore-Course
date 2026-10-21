using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreCourse.Models
{
    internal class Employee
    {
        public int EmpId { get; set; }
        public string? EmpName { get; set; }
        public decimal Salary { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? Password { get; set; }
        public string UserName { get; }

        #region Manage Relationship 
        // Navigation Property [One]
        // Ef Core -> Employee May Be Manage One Department [Optional]

        [InverseProperty(nameof(Department.Manager))]
        public Department? ManagedDepartment { get; set; }
        #endregion

        public Address EmpAddress { get; set; } = null!;

        #region Work Relationship
        //Navigation Property [One]
        // Each Employee Must Be Work In One Department
        [InverseProperty(nameof(Department.Employees))]
        public Department EmployeeDepartment { get; set; } = null!;

        //[ForeignKey(nameof(EmployeeDepartment))]
        public int DepartmentId { get; set; }

        #endregion

        #region Works On Relationship 
        [InverseProperty(nameof(EmployeeProject.Employee))]
        public EmployeeProject? EmployeeProject { get; set; }
        #endregion

        #region Supervise Relationship 
        public int? SupervisorId { get; set; }
        public Employee? Supervisor { get; set; }
        #endregion
    }
}
