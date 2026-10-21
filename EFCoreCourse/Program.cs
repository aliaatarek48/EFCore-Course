using EFCoreCourse.Models;
using Microsoft.EntityFrameworkCore;

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
            //var employee = dbContext.Employees.FirstOrDefault(x => x.EmpId == 20);

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
            //var employee = dbContext.Employees.Select(E => new
            //{
            //    EmployeeId = E.EmpId,
            //    EmployeeName = E.EmpName,
            //    DepartmentId = E.DepartmentId,
            //    DepartmentName = E.EmployeeDepartment.DeptName
            //}).FirstOrDefault(x => x.EmployeeId == 20);

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
            //var employee = dbContext.Employees.Include(x => x.EmployeeDepartment).FirstOrDefault(x => x.EmpId == 10);
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

            //var employee = dbContext.Employees.Include(x => x.EmployeeDepartment).Include(x => x.ManagedDepartment).FirstOrDefault(x => x.EmpId == 10);
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
            //var employee = dbContext.Employees.Include(x => x.EmployeeProject).ThenInclude(EP => EP.Project).FirstOrDefault(x => x.EmpId == 20);
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
            //var student = dbContext.Set<Student>().Include(e => e.StdCourse.Where(sc => sc.Grade > 50)).FirstOrDefault(s => s.StudentId == 1);
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
            //var employee = dbContext.Employees.FirstOrDefault(x => x.EmpId == 20);
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

            var department = dbContext.Departments.FirstOrDefault(d => d.DeptId == 50);
            if (department != null)
            {
                Console.WriteLine(department.DeptName);
                await dbContext.Entry(department).Collection(d => d.Employees).LoadAsync();
                foreach (var employee in department.Employees)
                {
                    Console.WriteLine(employee.EmpName);
                }
            }

            #endregion

            #region Filtered Collection with Query()

            //var customer = dbContext.Customers.FirstOrDefault(x => x.Id == 1);

            //if (customer != null)
            //{
            //    Console.WriteLine($"Customer Name : {customer.Name}"); // Ahmed Mohamed

            //    dbContext.Entry(customer).Collection(c => c.Orders).Query().Where(x => x.Number >= 2).Load();

            //    foreach (var order in customer.Orders) // Orders loaded after calling Load()
            //    {
            //        Console.WriteLine($"Order Number : {order.Number}");
            //    }
            //}

            #endregion

            #endregion

            #region Lazy Loading 

            //var order = dbContext.Orders.FirstOrDefault(x => x.Id == 1);

            //if (order != null)
            //{
            //    Console.WriteLine($"Order Number : {order.Number}"); // 1
            //    Console.WriteLine($"Order Customer Id : {order.CusId}"); // 1
            //    Console.WriteLine($"Order Customer Name : {order.OrderCustomer?.Name}"); // NULL
            //}


            //var customer = dbContext.Customers.FirstOrDefault(x => x.Id == 1);
            //if (customer != null)
            //{
            //    Console.WriteLine($"Customer Name : {customer.Name}"); // Ahmed Mohamed
            //    Console.WriteLine($"Customer Orders Count : {customer.Orders.Count}"); // 2
            //}


            #endregion

            #endregion

            #endregion

            #endregion

        }
    }
}
