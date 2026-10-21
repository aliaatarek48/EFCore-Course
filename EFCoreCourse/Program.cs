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


        }
    }
}
