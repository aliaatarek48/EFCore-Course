using Azure;
using EFCoreCourse.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace EFCoreCourse
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using CompanyDbContext dbContext = new CompanyDbContext();

            #region Session 03
            #region CRUD Operations - Query Object Model

            //Department department01 = new Department()
            //{
            //    DeptName = "IT"
            //};
            //dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            //Console.WriteLine(dbContext.Entry(department01).State); // Detached
            //Console.WriteLine(department01.DeptId); // 0

            #region Add New Row In Table Departments In Database
            //dbContext.Departments.Add(department01);
            ////dbContext.Set<Department>().Add(department01);
            ////dbContext.Add(department01);
            ////dbContext.Entry(department01).State = EntityState.Added;
            //Console.WriteLine("After Adding In DbSet ");
            //Console.WriteLine(dbContext.Entry(department01).State); // Added
            //Console.WriteLine($"department01 Id : {department01.DeptId}"); // 0
            //await dbContext.SaveChangesAsync();
            //Console.WriteLine("After Save Changes");
            //Console.WriteLine(dbContext.Entry(department01).State); // UnChanged
            //Console.WriteLine($"department01 Id : {department01.DeptId}"); // 20

            #endregion

            #region Retrieve Data From Database 

            //var department = await dbContext.Set<Department>().AsNoTracking().FirstOrDefaultAsync(E => E.DeptName == "IT");
            //if (department is not null)
            //{
            //    Console.WriteLine(dbContext.Entry(department).State);// Detached
            //    Console.WriteLine($"{department.DeptId} - {department.DeptName}");
            //}


            //department = await dbContext.Departments.FirstOrDefaultAsync(E => E.DeptName == "IT");

            //if (department is not null)
            //{
            //    Console.WriteLine(dbContext.Entry(department).State);// UnChanged
            //    Console.WriteLine($"{department.DeptId} - {department.DeptName}");
            //}

            #endregion

            #region Modify Data In Database 

            #region Connected scenario

            //var department = await dbContext.Departments.FirstOrDefaultAsync(E => E.DeptId == 10);
            //if (department is not null)
            //{
            //    Console.WriteLine($"Department State = {dbContext.Entry(department).State}"); // Unchanged
            //    Console.WriteLine($"{department.DeptId} - {department.DeptName}"); // 10 - IT
            //    department.DeptName = "Sales";

            //    Console.WriteLine("After Changing Name ");
            //    Console.WriteLine($"Department State = {dbContext.Entry(department).State}"); // Modified
            //    Console.WriteLine($"{department.DeptId} - {department.DeptName}"); // 10 - Sales
            //    await dbContext.SaveChangesAsync();
            //    Console.WriteLine("After SaveChanges()");
            //    Console.WriteLine($"Department State = {dbContext.Entry(department).State}"); // Unchanged
            //    Console.WriteLine($"{department.DeptId} - {department.DeptName}"); // 10 - Sales
            //}

            #endregion

            #region Disconnected scenario

            //var department = new Department() { DeptId = 10, DeptName = "HR", DateOfCreation = new DateTime(2026, 10, 21) };
            //Console.WriteLine($"Department State = {dbContext.Entry(department).State}"); // Detached
            //dbContext.Update(department);
            //Console.WriteLine($"Department State = {dbContext.Entry(department).State}"); // Modified
            //dbContext.SaveChanges();
            //Console.WriteLine($"Department State = {dbContext.Entry(department).State}"); // Unchanged
            #endregion

            #region AsNoTracking 
            //var department = dbContext.Departments.AsNoTracking().FirstOrDefault(E => E.DeptId == 10);
            //if (department is not null)
            //{
            //    Console.WriteLine($"Department State = {dbContext.Entry(department).State}"); // Detached
            //    Console.WriteLine($"{department.DeptId} - {department.DeptName}"); // 10 - Sales
            //    department.DeptName = "IT";

            //    Console.WriteLine("After Changing Name ");
            //    Console.WriteLine($"Department State = {dbContext.Entry(department).State}"); // Detached
            //    Console.WriteLine($"{department.DeptId} - {department.DeptName}"); // 10 - IT
            //    await dbContext.SaveChangesAsync();
            //    Console.WriteLine("After SaveChanges()");
            //    Console.WriteLine($"Department State = {dbContext.Entry(department).State}"); // Detached
            //    Console.WriteLine($"{department.DeptId} - {department.DeptName}"); // 10 - IT
            //    // Object -> DeptName Changed , InDatabase Nothing happened
            //}
            #endregion

            #endregion

            #region Remove Data from Database 

            #region Connected scenario
            //var department = dbContext.Departments.FirstOrDefault(E => E.DeptId == 10);
            //if (department is not null)
            //{
            //    Console.WriteLine($"department State = {dbContext.Entry(department).State}"); // Unchanged


            //    dbContext.Departments.Remove(department);
            //    //dbContext.Set<Department>().Remove(department);
            //    //dbContext.Remove(department);
            //    //dbContext.Entry(department).State = EntityState.Deleted;


            //    Console.WriteLine("After Removing department From Dbset");
            //    Console.WriteLine($"department State = {dbContext.Entry(department).State}"); // Deleted

            //await dbContext.SaveChangesAsync();
            //    Console.WriteLine("After SaveChanges()");
            //    Console.WriteLine($"department State = {dbContext.Entry(department).State}"); // Detached
            //} 
            #endregion

            #region Disconnected scenario
            //var department = new Department() { DeptId = 40 };
            //Console.WriteLine($"department State = {dbContext.Entry(department).State}"); // Detached
            //dbContext.Remove(department);
            //Console.WriteLine($"department State = {dbContext.Entry(department).State}"); // Deleted
            //await dbContext.SaveChangesAsync();
            //Console.WriteLine($"department State = {dbContext.Entry(department).State}"); // Detached 
            #endregion

            #endregion

            #region Bulk Operations
            // insert data into Employees Table 

            //var employees = dbContext.Employees.Where(e => e.Salary >= 5000).ToList();

            ////foreach (var employee in employees)
            ////{
            ////    employee.Salary *= 1.2m;
            ////}
            ////dbContext.SaveChanges();


            //await dbContext.Employees.Where(e => e.Salary >= 5000)
            //      .ExecuteUpdateAsync(e => e.SetProperty(emp => emp.Salary, emp => emp.Salary * 1.2m));
            #endregion

            #endregion

            #region Data Seeding 

            //if (!await dbContext.Set<Project>().AnyAsync())
            //{
            //    dbContext.Set<Project>().AddRange(
            //        new Project { PName = "P01" },
            //        new Project { PName = "P02" },
            //        new Project { PName = "P03" }
            //    );

            //    //// Data From File
            //    List<Project> Customers =
            //    [
            //        new Project { PName = "P01" },
            //        new Project { PName = "P02" },
            //        new Project { PName = "P03" }
            //    ];

            //    dbContext.AddRange(Customers);

            //    await dbContext.SaveChangesAsync();

            //    Console.WriteLine("Project Data Seeded");
            //}

            #endregion

            #endregion

            #region Session 04

            #region Loading Related Data

            #region Problem 
            //var employee = await dbContext.Employees.FirstOrDefaultAsync(x => x.EmpId == 20);

            //if (employee != null)
            //{
            //    Console.WriteLine($"Employee Id : {employee.EmpId}"); // 20
            //    Console.WriteLine($"Employee Name : {employee.EmpName}"); // Ahmed
            //    Console.WriteLine($"Employee Department Id : {employee.DepartmentId}"); // 50
            //    Console.WriteLine($"Employee Department Id : {employee.EmployeeDepartment.DeptId}"); // Exception
            //    Console.WriteLine($"Employee Department Name : {employee.EmployeeDepartment.DeptName}"); // Exception
            //}
            #endregion

            #region Solutions

            #region Projection 
            //var employee = await dbContext.Employees.Select(E => new
            //{
            //    EmployeeId = E.EmpId,
            //    EmployeeName = E.EmpName,
            //    DepartmentId = E.DepartmentId,
            //    DepartmentName = E.EmployeeDepartment.DeptName
            //}).FirstOrDefaultAsync(x => x.EmployeeId == 20);

            //if (employee != null)
            //{
            //    Console.WriteLine($"Employee Id : {employee.EmployeeId}"); // 20
            //    Console.WriteLine($"Employee Name : {employee.EmployeeName}"); // Ahmed
            //    Console.WriteLine($"Employee Department Id : {employee.DepartmentId}"); // 50
            //    Console.WriteLine($"Employee Department Id : {employee.DepartmentName}"); // IT
            //}

            //// SQL Generated 

            ///*
            // SELECT TOP(1) [e].[EmpId] AS [EmployeeId], [e].[EmployeeName], [e].[DepartmentId], [d].[DepartmentName]
            // FROM [EmployeesTable] AS [e]
            // INNER JOIN [Sales].[Departments] AS [d] ON [e].[DepartmentId] = [d].[DeptId]
            // WHERE [e].[EmpId] = 20
            // */
            #endregion

            #region Eager Loading 

            #region Include()
            //var employee = await dbContext.Employees.Include(x => x.EmployeeDepartment).FirstOrDefaultAsync(x => x.EmpId == 10);
            //if (employee != null)
            //{
            //    Console.WriteLine($"Employee Id : {employee.EmpId}"); // 20
            //    Console.WriteLine($"Employee Name : {employee.EmpName}"); // Ahmed
            //    Console.WriteLine($"Employee Department Id : {employee.DepartmentId}"); // 50
            //    Console.WriteLine($"Employee Department Id : {employee.EmployeeDepartment.DeptId}"); // 50
            //    Console.WriteLine($"Employee Department Name : {employee.EmployeeDepartment.DeptName}"); // HR
            //}
            ///*
            // SELECT TOP(1) [e].[EmpId], [e].[Age], [e].[CreatedAt], [e].[DepartmentId], [e].[Email], [e].[EmployeeName], [e].[Password], [e].[PhoneNumber], [e].[Salary], [e].[SupervisorId], [e].[EmpAddress_City], [e].[EmpAddress_Country], [e].[EmpAddress_Street], [d].[DeptId], [d].[DateOfCreation], [d].[DeptManagerId], [d].[DepartmentName]
            // FROM [EmployeesTable] AS [e]
            // INNER JOIN [Sales].[Departments] AS [d] ON [e].[DepartmentId] = [d].[DeptId]
            // WHERE [e].[EmpId] = 10
            // */

            //var employee = await dbContext.Employees.Include(x => x.EmployeeDepartment).Include(x => x.ManagedDepartment).FirstOrDefaultAsync(x => x.EmpId == 10);
            //if (employee != null)
            //{
            //    Console.WriteLine($"Employee Name : {employee.EmpName}"); // Ahmed
            //    Console.WriteLine($"Employee Department Name : {employee.EmployeeDepartment.DeptName}"); // HR
            //    Console.WriteLine($"Employee Managed Department Name : {employee.ManagedDepartment?.DeptName ?? "Not a Manager"}");
            //}
            ///*
            // SELECT TOP(1) [e].[EmpId], [e].[Age], [e].[CreatedAt], [e].[DepartmentId], [e].[Email], [e].[EmployeeName], [e].[Password], [e].[PhoneNumber], [e].[Salary], [e].[SupervisorId], [e].[EmpAddress_City], [e].[EmpAddress_Country], [e].[EmpAddress_Street], [d].[DeptId], [d].[DateOfCreation], [d].[DeptManagerId], [d].[DepartmentName], [d0].[DeptId], [d0].[DateOfCreation], [d0].[DeptManagerId], [d0].[DepartmentName]
            // FROM [EmployeesTable] AS [e]
            // INNER JOIN [Sales].[Departments] AS [d] ON [e].[DepartmentId] = [d].[DeptId]
            // LEFT JOIN [Sales].[Departments] AS [d0] ON [e].[EmpId] = [d0].[DeptManagerId]
            // WHERE [e].[EmpId] = 10
            // */

            #endregion

            #region ThenInclude()
            //var employee = await dbContext.Employees.Include(x => x.EmployeeProject).ThenInclude(EP => EP.Project).FirstOrDefaultAsync(x => x.EmpId == 20);
            //if (employee != null)
            //{
            //    Console.WriteLine($"Employee Name : {employee.EmpName}"); // Ahmed
            //    Console.WriteLine($"Employee Working Project Name : {employee.EmployeeProject?.Project.PName}"); // HR
            //}
            ///*
            // SELECT TOP(1) [e].[EmpId], [e].[Age], [e].[CreatedAt], [e].[DepartmentId], [e].[Email], [e].[EmployeeName], [e].[Password], [e].[PhoneNumber], [e].[Salary], [e].[SupervisorId], [e].[EmpAddress_City], [e].[EmpAddress_Country], [e].[EmpAddress_Street], [e0].[EmpId], [e0].[ProId], [p].[Id], [p].[PName]
            // FROM [EmployeesTable] AS [e]
            // LEFT JOIN [EmployeeProject] AS [e0] ON [e].[EmpId] = [e0].[EmpId]
            // LEFT JOIN [Project] AS [p] ON [e0].[ProId] = [p].[Id]
            // WHERE [e].[EmpId] = 20
            //*/
            #endregion

            #region Filtered Include 
            //var student = await dbContext.Set<Student>().Include(e => e.StdCourse.Where(sc => sc.Grade > 50)).FirstOrDefaultAsync(s => s.StudentId == 1);
            //if (student != null)
            //{
            //    Console.WriteLine($"Student Name : {student.SName}");
            //    Console.WriteLine($"Count Of Courses With grade Above 50 : {student.StdCourse.Count}");
            //    foreach (var course in student.StdCourse)
            //    {
            //        Console.WriteLine(course.CrsId);
            //        Console.WriteLine(course.Grade);
            //    }
            //}
            ///*
            // SELECT [s1].[StudentId], [s1].[SName], [s2].[StdId], [s2].[CrsId], [s2].[Grade]
            // FROM (
            //     SELECT TOP(1) [s].[StudentId], [s].[SName]
            //     FROM [Student] AS [s]
            //     WHERE [s].[StudentId] = 1
            // ) AS [s1]
            // LEFT JOIN (
            //     SELECT [s0].[StdId], [s0].[CrsId], [s0].[Grade]
            //     FROM [StudentCourse] AS [s0]
            //     WHERE [s0].[Grade] > 50
            // ) AS [s2] ON [s1].[StudentId] = [s2].[StdId]
            // ORDER BY [s1].[StudentId], [s2].[StdId]
            // */

            #endregion

            #endregion

            #region Explicit Loading

            #region Reference()
            //var employee = await dbContext.Employees.FirstOrDefaultAsync(x => x.EmpId == 20);
            ///*
            // SELECT TOP(1) [e].[EmpId], [e].[Age], [e].[CreatedAt], [e].[DepartmentId], [e].[Email], [e].[EmployeeName], [e].[Password], [e].[PhoneNumber], [e].[Salary], [e].[SupervisorId], [e].[EmpAddress_City], [e].[EmpAddress_Country], [e].[EmpAddress_Street]
            // FROM [EmployeesTable] AS [e]
            // WHERE [e].[EmpId] = 20
            // */
            //if (employee != null)
            //{
            //    Console.WriteLine($"Employee Id : {employee.EmpId}"); // 20
            //    Console.WriteLine($"Employee Name : {employee.EmpName}"); // Ahmed
            //    Console.WriteLine($"Employee Department Id : {employee.DepartmentId}"); // 50
            //    await dbContext.Entry(employee).Reference(e => e.EmployeeDepartment).LoadAsync();
            //    /*
            //     SELECT TOP(1) [d].[DeptId], [d].[DateOfCreation], [d].[DeptManagerId], [d].[DepartmentName]
            //     FROM [Sales].[Departments] AS [d]
            //     WHERE [d].[DeptId]
            //     */
            //    Console.WriteLine($"Employee Department Id : {employee.EmployeeDepartment.DeptId}"); // 50
            //    Console.WriteLine($"Employee Department Name : {employee.EmployeeDepartment.DeptName}"); // HR
            //}
            #endregion

            #region Collection()

            //var department = await dbContext.Departments.FirstOrDefaultAsync(d => d.DeptId == 50);
            ///*
            // SELECT TOP(1) [d].[DeptId], [d].[DateOfCreation], [d].[DeptManagerId], [d].[DepartmentName]
            // FROM [Sales].[Departments] AS [d]
            // WHERE [d].[DeptId] = 50
            // */
            //if (department != null)
            //{
            //    Console.WriteLine(department.DeptName);
            //    await dbContext.Entry(department).Collection(d => d.Employees).LoadAsync();
            //    /*
            //     SELECT [e].[EmpId], [e].[Age], [e].[CreatedAt], [e].[DepartmentId], [e].[Email], [e].[EmployeeName], [e].[Password], [e].[PhoneNumber], [e].[Salary], [e].[SupervisorId], [e].[EmpAddress_City], [e].[EmpAddress_Country], [e].[EmpAddress_Street]
            //     FROM [EmployeesTable] AS [e]
            //     WHERE [e].[DepartmentId] = 50
            //    */
            //    foreach (var employee in department.Employees)
            //    {
            //        Console.WriteLine(employee.EmpName);
            //    }
            //}

            #endregion

            #region Filtered Collection with Query()

            //var department = await dbContext.Departments.FirstOrDefaultAsync(d => d.DeptId == 50);
            ///*
            // SELECT TOP(1) [d].[DeptId], [d].[DateOfCreation], [d].[DeptManagerId], [d].[DepartmentName]
            // FROM [Sales].[Departments] AS [d]
            // WHERE [d].[DeptId] = 50
            // */
            //if (department != null)
            //{
            //    Console.WriteLine($"Department Name : {department.DeptName}");
            //    await dbContext.Entry(department).Collection(d => d.Employees).Query().Where(x => x.Age < 30).LoadAsync();
            //    /*
            //     SELECT [e].[EmpId], [e].[Age], [e].[CreatedAt], [e].[DepartmentId], [e].[Email], [e].[EmployeeName], [e].[Password], [e].[PhoneNumber], [e].[Salary], [e].[SupervisorId], [e].[EmpAddress_City], [e].[EmpAddress_Country], [e].[EmpAddress_Street]
            //     FROM [EmployeesTable] AS [e]
            //     WHERE [e].[DepartmentId] = 50 AND [e].[Age] < 30      
            //     */
            //    foreach (var employee in department.Employees)
            //    {
            //        Console.WriteLine(employee.EmpName);
            //    }
            //}

            #endregion

            #endregion

            #region Lazy Loading 
            //var employee = await dbContext.Employees.FirstOrDefaultAsync(x => x.EmpId == 20);

            //if (employee != null)
            //{
            //    Console.WriteLine($"Employee Id : {employee.EmpId}"); // 20
            //    Console.WriteLine($"Employee Name : {employee.EmpName}"); // Ahmed
            //    Console.WriteLine($"Employee Department Id : {employee.DepartmentId}"); // 50
            //    Console.WriteLine($"Employee Department Id : {employee.EmployeeDepartment.DeptId}"); // Exception
            //    Console.WriteLine($"Employee Department Name : {employee.EmployeeDepartment.DeptName}"); // Exception
            //}


            //var department = await dbContext.Departments.FirstOrDefaultAsync(d => d.DeptId == 50);
            //Console.WriteLine(department?.DeptName);
            //foreach (var employee in department?.Employees ?? Enumerable.Empty<Employee>())
            //{
            //    Console.WriteLine(employee.EmpName);
            //}

            #endregion

            #endregion

            #endregion

            #region Join LINQ Category

            #region Inner Join 

            //var result = from e in dbContext.Employees
            //             join d in dbContext.Departments
            //             on e.DepartmentId equals d.DeptId
            //             select new
            //             {
            //                 EmployeeName = e.EmpName,
            //                 DepartmentName = d.DeptName
            //             };


            //result = dbContext.Employees.Join(dbContext.Departments, e => e.DepartmentId, d => d.DeptId, (e, d) => new
            //{
            //    EmployeeName = e.EmpName,
            //    DepartmentName = d.DeptName
            //});

            //foreach (var item in result)
            //    Console.WriteLine(item);





            #endregion

            #region Group Join 

            #region Example 01
            //var result = dbContext.Departments.GroupJoin(dbContext.Employees, d => d.DeptId, e => e.DepartmentId, (dept, employees) => new
            //{
            //    DepartmentName = dept.DeptName,
            //    Employees = employees
            //}).Where(x => x.Employees.Count() > 2);
            /*
            SELECT[d].[DepartmentName], [d].[DeptId], [e0].[EmpId], [e0].[Age], [e0].[CreatedAt], [e0].[DepartmentId], [e0].[Email], [e0].[EmployeeName], [e0].[Password], [e0].[PhoneNumber], [e0].[Salary], [e0].[SupervisorId], [e0].[EmpAddress_City], [e0].[EmpAddress_Country], [e0].[EmpAddress_Street]
            FROM[Sales].[Departments] AS[d]
            LEFT JOIN[EmployeesTable] AS[e0] ON[d].[DeptId] = [e0].[DepartmentId]
            WHERE( SELECT COUNT(*) FROM[EmployeesTable] AS[e] WHERE[d].[DeptId] = [e].[DepartmentId]) > 2
            ORDER BY[d].[DeptId]
             */
            //foreach (var group in result)
            //{
            //    Console.WriteLine(group.DepartmentName);
            //    Console.WriteLine("=====================");
            //    foreach (var employee in group.Employees)
            //    {
            //        Console.WriteLine(employee.EmpName);
            //    }
            //}

            #region Query Syntax

            //       var result =
            //from d in dbContext.Departments
            //join e in dbContext.Employees
            //    on d.DeptId equals e.DepartmentId
            //    into employees
            //where employees.Count() > 2
            //select new
            //{
            //    DepartmentName = d.DeptName,
            //    Employees = employees
            //};

            //       foreach (var group in result)
            //       {
            //           Console.WriteLine(group.DepartmentName);
            //           Console.WriteLine("=====================");
            //           foreach (var employee in group.Employees)
            //           {
            //               Console.WriteLine(employee.EmpName);
            //           }
            //       }
            #endregion

            #endregion

            #region Example 02

            //var result = dbContext.Departments.GroupJoin(dbContext.Employees, d => d.DeptId, e => e.DepartmentId, (dept, employees) => new
            //{
            //    DepartmentName = dept.DeptName,
            //    EmployeesCount = employees.Count(),
            //    EmployeesSalaries = employees.Sum(e => e.Salary)
            //});

            ///*
            // SELECT [d].[DepartmentName], ( SELECT COUNT(*)
            //                               FROM [EmployeesTable] AS [e]
            //                               WHERE [d].[DeptId] = [e].[DepartmentId]) AS [EmployeesCount], 
            //                               (SELECT COALESCE(SUM([e0].[Salary]), 0.0)
            //                                FROM [EmployeesTable] AS [e0]
            //                                WHERE [d].[DeptId] = [e0].[DepartmentId]) AS [EmployeesSalaries]
            // FROM [Sales].[Departments] AS [d]
            // */



            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion

            #endregion

            #region Left Join 

            //var result = dbContext.Employees.LeftJoin(dbContext.Departments, e => e.DepartmentId, d => d.DeptId, (e, d) => new
            //{
            //    EmployeeName = e.EmpName,
            //    DepartmentName = d == null ? "No Department" : d.DeptName
            //});
            //// Specified method is not supported Upgrade to .Net 10

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}

            #region Left Join Pre .Net 10

            //var result = dbContext.Employees.GroupJoin(dbContext.Departments, e => e.DepartmentId, d => d.DeptId, (e, departments) => new
            //{
            //    Employee = e,
            //    Departments = departments
            //}).SelectMany(x => x.Departments.DefaultIfEmpty(),
            //                           (x, d) => new
            //                           {
            //                               EmployeeName = x.Employee.EmpName,
            //                               DepartmentName = d == null ? "No Department" : d.DeptName
            //                           });
            ///*
            // SELECT [e].[EmployeeName], CASE
            // WHEN [d].[DeptId] IS NULL THEN 'No Department'
            // ELSE [d].[DepartmentName]
            // END AS [DepartmentName]
            // FROM [EmployeesTable] AS [e]
            // LEFT JOIN [Sales].[Departments] AS [d] ON [e].[DepartmentId] = [d].[DeptId]
            // */

            //result = from e in dbContext.Employees
            //         join d in dbContext.Departments
            //         on e.DepartmentId equals d.DeptId
            //         into DepartmentGroups
            //         from d in DepartmentGroups.DefaultIfEmpty()
            //         select new
            //         {
            //             EmployeeName = e.EmpName,
            //             DepartmentName = d == null ? "No Department" : d.DeptName
            //         };

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion




            #endregion

            #endregion

            #region Local And Find() 
            //// 1) Load ALL employees into the DbContext's memory (Change Tracker)
            //await dbContext.Employees.LoadAsync();

            //// 2) Read from memory only — no database call
            //foreach (var employee in dbContext.Employees.Local)
            //{
            //    Console.WriteLine(employee.EmpName);
            //}

            //// 3) FirstOrDefaultAsync → ALWAYS sends a query to the database,
            ////    even if the employee is already loaded in memory
            //var emp = await dbContext.Employees.FirstOrDefaultAsync(e => e.EmpId == 20);
            ////
            //// 4) FindAsync → checks memory (Local) first by Primary Key;
            ////    queries the database ONLY if not found
            //emp = await dbContext.Employees.FindAsync(20);

            #endregion

            #endregion

        }
    }
}
